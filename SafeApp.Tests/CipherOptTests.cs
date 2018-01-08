using System.Threading.Tasks;
using NUnit.Framework;
using SafeApp.Misc;

namespace SafeApp.Tests {
  [TestFixture]
  internal class CipherOptTests {
    //[Test]
    //public async Task CreatePlainCipherOpt() {
    //  Utils.InitialiseSessionForRandomTestApp();
    //  using (var handle = await CipherOpt.NewPlaintextAsync()) {
    //    Assert.NotNull(handle);
    //  }
    //}

    //[Test]
    //public async Task NewAssymmetric() {
    //  Utils.InitialiseSessionForRandomTestApp();
    //  var encKeyPairTuple = await Crypto.EncGenerateKeyPairAsync();
    //  using (var handle = await CipherOpt.NewAsymmetricAsync(encKeyPairTuple.Item1)) {
    //    Assert.NotNull(handle);
    //  }
    //  await Crypto.EncPubKeyFreeAsync(encKeyPairTuple.Item1);
    //  await Crypto.EncSecretKeyFreeAsync(encKeyPairTuple.Item2);
    //}

    //[Test]
    //public async Task NewSymmetric() {
    //  Utils.InitialiseSessionForRandomTestApp();
    //  using (var handle = await CipherOpt.NewSymmetricAsync()) {
    //    Assert.NotNull(handle);
    //  }
    //}
  }
}
