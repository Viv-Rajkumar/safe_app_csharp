#if !NETSTANDARD1_2 || __DESKTOP__
using System;
using System.Collections.Generic;
using SafeApp.Utilities;

namespace SafeApp.MockAuthBindings {
  public partial class MockAuthBindings {
   public IntPtr TestCreateApp() {
      var ret = TestCreateAppNative(out IntPtr app);
      if (ret != 0) {
          throw new InvalidOperationException();
      }

      return app;
    }

    public IntPtr TestCreateAppWithAccess(List<ContainerPermissions> accessInfo) {
      var ret = TestCreateAppWithAccessNative(accessInfo.ToArray(), (ulong) accessInfo.Count, out IntPtr app);
      if (ret != 0) {
          throw new InvalidOperationException();
      }

      return app;
    }
  }
}
#endif
