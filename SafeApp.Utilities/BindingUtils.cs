using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace SafeApp.Utilities {
  public class FfiException : Exception {
    public readonly int ErrorCode;

    public FfiException(int code, string description)
      : base($"Error Code: {code}. Description: {description}")
    {
      ErrorCode = code;
    }
  }

  public struct FfiResult {
    public int ErrorCode;
    [MarshalAs(UnmanagedType.LPStr)]
    public string Description;

    public FfiException ToException() {
      return new FfiException(ErrorCode, Description);
    }
  }

  internal class BindingUtils {
    public static IntPtr ToHandlePtr<T>(T obj) {
        return GCHandle.ToIntPtr(GCHandle.Alloc(obj));
    }

    public static T FromHandlePtr<T>(IntPtr ptr, bool free = true) {
      var handle = GCHandle.FromIntPtr(ptr);
      var result = (T) handle.Target;

      if (free) handle.Free();

      return result;
    }

    public static (Task<T>, IntPtr) PrepareTask<T>() {
      var tcs = new TaskCompletionSource<T>();
      var userData = ToHandlePtr(tcs);

      return (tcs.Task, userData);
    }

    public static (Task, IntPtr) PrepareTask() {
      return PrepareTask<bool>();
    }

    public static void CompleteTask<T>(TaskCompletionSource<T> tcs, FfiResult result, Func<T> arg) {
      if (result.ErrorCode != 0) {
        tcs.SetException(result.ToException());
      } else {
        try {
          var res = arg();
          tcs.SetResult(res);
        } catch (Exception e) {
          Debug.WriteLine(e);
          throw;
        }
      }
    }

    public static void CompleteTask<T>(IntPtr userData, FfiResult result, Func<T> arg) {
      var tcs = FromHandlePtr<TaskCompletionSource<T>>(userData);
      CompleteTask(tcs, result, arg);
    }

    public static void CompleteTask(IntPtr userData, FfiResult result) {
      CompleteTask(userData, result, () => true);
    }

    public static List<byte> CopyToByteList(IntPtr ptr, int len) {
      var array = new byte[len];
      Marshal.Copy(ptr, array, 0, len);

      return new List<byte>(array);
    }

    public static List<T> CopyToObjectList<T>(IntPtr ptr, int len) {
      var list = new List<T>();
      for (var i = 0; i < len; ++i) {
        list.Add(Marshal.PtrToStructure<T>(IntPtr.Add(ptr, Marshal.SizeOf<T>() * i)));
      }
      return list;
    }

    public static IntPtr CopyFromByteList(List<byte> list) {
      var array = list.ToArray();
      var size = Marshal.SizeOf(array[0]) * array.Length;
      var ptr  = Marshal.AllocHGlobal(size);
      Marshal.Copy(array, 0, ptr, array.Length);

      return ptr;
    }

    public static IntPtr CopyFromObjectList<T>(List<T> list) {
      var size = Marshal.SizeOf(list[0]) * list.Count;
      var ptr  = Marshal.AllocHGlobal(size);
      for (var i = 0; i < list.Count; ++i) {
          Marshal.StructureToPtr(list[i], IntPtr.Add(ptr, Marshal.SizeOf<T>() * i), false);
      }

      return ptr;
    }

    public static void FreeList(ref IntPtr ptr, ref ulong len) {
      if (ptr != IntPtr.Zero) {
          Marshal.FreeHGlobal(ptr);
      }

      ptr = IntPtr.Zero;
      len = 0;
    }
  }
}
