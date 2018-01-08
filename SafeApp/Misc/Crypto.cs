using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using JetBrains.Annotations;
using SafeApp.AppBindings;
using SafeApp.Utilities;

// ReSharper disable ConvertToLocalFunction

namespace SafeApp.Misc {
  [PublicAPI]
  public class Crypto {
    private static readonly IAppBindings _appBindings = AppResolver.Current;
    private IntPtr _appPtr;

    public Crypto(IntPtr appPtr)
    {
      _appPtr = appPtr;
    }
    /// <summary>
    /// Get App's Public Sign Key
    /// </summary>
    /// <returns>App's Public Sign Key NativeHandle</returns>
    public async Task<NativeHandle> AppPubSignKeyAsync() {
      var appPubSignKeyH = await _appBindings.AppPubSignKeyAsync(_appPtr);
      return new NativeHandle(appPubSignKeyH, SignPubKeyFreeAsync);
    }
    /// <summary>
    /// Generate a new Sign Key Pair
    /// </summary>
    /// <returns>Tuple of Sign Public Key NativeHandle and Sign Secret Key NativeHandle</returns>
    public async Task<(NativeHandle, NativeHandle)> SignGenerateKeyPairAsync() {
      var (publicKeyHandle, secretKeyHandle) = await _appBindings.SignGenerateKeyPairAsync(_appPtr);
      return (new NativeHandle(publicKeyHandle, SignPubKeyFreeAsync), new NativeHandle(secretKeyHandle, SignSecKeyFreeAsync));
    }
    /// <summary>
    /// Get Sign Public Key Handle from a raw key
    /// </summary>
    /// <param name="rawPubSignKey">Raw Sign Public Key as List<byte></param>
    /// <returns>Public Sign Key NativeHandle</returns>
    public async Task<NativeHandle> SignPubKeyNewAsync(byte[] rawPubSignKey) {
      var handle = await _appBindings.SignPubKeyNewAsync(_appPtr, rawPubSignKey);
      return new NativeHandle(handle, SignPubKeyFreeAsync);
    }
    /// <summary>
    /// Get raw Sign Public Key
    /// </summary>
    /// <param name="pubSignKey">Sign Public Key NativeHandle</param>
    /// <returns>Raw Sign Public Key as List<byte></returns>
    public Task<byte[]> SignPubKeyGetAsync(NativeHandle pubSignKey) {
      return _appBindings.SignPubKeyGetAsync(_appPtr, pubSignKey);
    }
    /// <summary>
    /// Get New Sign Secret Key handle from a raw Sign Secret Key
    /// </summary>
    /// <param name="rawSecSignKey"></param>
    /// <returns>Secret Sign Key NativeHandle</returns>
    public async Task<NativeHandle> SignSecKeyNewAsync(byte[] rawSecSignKey)
    {
       var handle = await _appBindings.SignSecKeyNewAsync(_appPtr, rawSecSignKey);
       return new NativeHandle(handle, SignSecKeyFreeAsync);
    }
    /// <summary>
    /// Get Raw Secret Sign Key
    /// </summary>
    /// <param name="secSignKey">Secret Sign Key NativeHandle</param>
    /// <returns>Raw Secret Sign Key as List<byte></returns>
    public Task<byte[]> SignSecKeyGetAsync(NativeHandle secSignKey)
    {
       return _appBindings.SignSecKeyGetAsync(_appPtr, secSignKey);
    }
    /// <summary>
    /// Decrypt cipher text from a Sender
    /// </summary>
    /// <param name="cipherText">Cipher Text to be decrypted</param>
    /// <param name="pkHandle">Sender's Encrypt Public Key</param>
    /// <param name="skHandle">Receiver's Encrypt Secret Key</param>
    /// <returns>Decrypted data</returns>
    public Task<List<byte>> DecryptSealedBoxAsync(List<byte> cipherText, NativeHandle pkHandle, NativeHandle skHandle) {
      return _appBindings.DecryptSealedBoxAsync(_appPtr, cipherText, pkHandle, skHandle);
    }
    /// <summary>
    /// Generate New Encrypt Key Pair
    /// </summary>
    /// <returns>(Encrypt Public Key, Encrypt Secret Key)</returns>
    public async Task<(NativeHandle, NativeHandle)> EncGenerateKeyPairAsync() {
      var (encPubKeyH, encSecKeyH) = await _appBindings.EncGenerateKeyPairAsync(_appPtr);
      return (new NativeHandle(encPubKeyH, EncPubKeyFreeAsync), new NativeHandle(encSecKeyH, EncSecretKeyFreeAsync));
    }
    /// <summary>
    /// Free Encrypt Public Key Handle
    /// </summary>
    /// <param name="encPubKeyH"></param>
    /// <returns></returns>
    public Task EncPubKeyFreeAsync(ulong encPubKeyH) {
      return _appBindings.EncPubKeyFreeAsync(_appPtr, encPubKeyH);
    }

    public Task<byte[]> EncPubKeyGetAsync(NativeHandle encPubKeyH) {
      return _appBindings.EncPubKeyGetAsync(_appPtr, encPubKeyH);
    }

    public async Task<NativeHandle> EncPubKeyNewAsync(byte[] asymPublicKeyBytes) {
      var encryptPubKeyH = await _appBindings.EncPubKeyNewAsync(_appPtr, asymPublicKeyBytes);
      return new NativeHandle(encryptPubKeyH, EncPubKeyFreeAsync);
    }

    public Task<List<byte>> EncryptSealedBoxAsync(List<byte> inputData, NativeHandle pkHandle) {
      return _appBindings.EncryptSealedBoxAsync(_appPtr, inputData, pkHandle);
    }

    public Task EncSecretKeyFreeAsync(ulong encSecKeyH) {
      return _appBindings.EncSecretKeyFreeAsync(_appPtr, encSecKeyH);
    }

    public Task<byte[]> EncSecretKeyGetAsync(NativeHandle encSecKeyH) {
      return _appBindings.EncSecretKeyGetAsync(_appPtr, encSecKeyH);
    }

    public async Task<NativeHandle> EncSecretKeyNewAsync(byte[] asymSecKeyBytes) {
      var encSecKeyH = await _appBindings.EncSecretKeyNewAsync(_appPtr, asymSecKeyBytes);
      return new NativeHandle(encSecKeyH, EncSecretKeyFreeAsync);
    }

    public Task SignPubKeyFreeAsync(ulong pubSignKeyHandle) {
      return _appBindings.SignPubKeyFreeAsync(_appPtr, pubSignKeyHandle);
    }

    public Task SignSecKeyFreeAsync(ulong secSignKeyHandle) {
      return _appBindings.SignSecKeyFreeAsync(_appPtr, secSignKeyHandle);
    }

    public Task<List<byte>> SignAsync(List<byte> data, NativeHandle signSecKey) {
      return _appBindings.SignAsync(_appPtr, data, signSecKey);
    }

    public Task<List<byte>> VerifyAsync(List<byte> signedData, NativeHandle signPubKey)
    {
      return _appBindings.VerifyAsync(_appPtr, signedData, signPubKey);
    }

    public Task<List<byte>> EncryptAsync(List<byte> data, NativeHandle encPubKey, NativeHandle encSecKey)
    {
      return _appBindings.EncryptAsync(_appPtr, data, encPubKey, encSecKey);
    }

    public Task<List<byte>> DecryptAsync(List<byte> cipherText, NativeHandle encPubKey, NativeHandle encSecKey)
    {
      return _appBindings.DecryptAsync(_appPtr, cipherText, encPubKey, encSecKey);
    }

  }
}
