using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using SafeApp.Utilities;

namespace SafeApp.Tests {
  [TestFixture]
  internal class AuthTest {
    // TODO use safe_authenticator encode and decode functions
    private const string AuthUri =
        "safe-bmV0Lm1haWRzYWZlLnRlc3Qud2ViYXBwLmlk:AQAAAGSv7oQAAAAAAAAAACAAAAAAAAAAGQ1zYg9iFKof2TVkAPp0R2kjU9DDWmmR_uAXBYvaeIAgAAAAAAAAAKecZc5pOSeoU53v43RdoTscGQbuAO0hF6HA_4ou9GJnIAAAAAAAAADsycX-1RCaNJxnYf6ka1pLncSez4w4PmPIS5lau_IblkAAAAAAAAAAbZdkFJ6Ydhh_OwA7mfYcnta_95k2xRazJsDSeMFGj3vsycX-1RCaNJxnYf6ka1pLncSez4w4PmPIS5lau_IbliAAAAAAAAAAx559E774w-6AWnIXBSm0NWOBW2zr8TOPThmdIeEsoFEgAAAAAAAAAHRNdser-WDOLIBGsDfRbNI304vnYILXI1JZC96tiFvzAAAAAAAAAAAAAAAAAAAAAG7Di2O1ssjN0izb88iclOKj7WD5LtaVriMIrLBbVRHimDoAAAAAAAAYAAAAAAAAAH2p2f2I4yuQPLkSJE_u9-PtM1WD7E65ZA=="
      ;

    //private AppExchangeInfo GetExchangeInfo() {
    //  return new AppExchangeInfo {Id = "net.maidsafe.example", Name = "Test App", Vendor = "Maidsafe Ltd."};
    //}

    //[Test]
    //public async Task ConnectAsRegisteredApp() {
    //  var result = await Session.DecodeIpcMessageAsync(AuthUri);
    //  Assert.AreEqual(result.GetType(), typeof(AuthIpcMsg));
    //  var ipcMsg = (AuthIpcMsg)result;
    //  await Session.AppRegisteredAsync("bmV0Lm1haWRzYWZlLnRlc3Qud2ViYXBwLmlk", ipcMsg.AuthGranted, null);
    //  // TODO implement symmetric encryption after the API is expanded
    //}

    //[Test]
    //public void EncodeAuthRequestWithEmptyContainers() {
    //  var authReq = new AuthReq {AppContainer = false, App = GetExchangeInfo(), Containers = new List<ContainerPermissions>()};
    //  Assert.DoesNotThrowAsync(async () => await Session.EncodeAuthReqAsync(authReq));
    //}

    //[Test]
    //public void EncodeAuthRequestWithEmptyContainersAndAppContainer() {
    //  var authReq = new AuthReq {AppContainer = true, App = GetExchangeInfo(), Containers = new List<ContainerPermissions>()};
    //  Assert.DoesNotThrowAsync(async () => await Session.EncodeAuthReqAsync(authReq));
    //}

    //[Test]
    //public void EncodeAuthRequestWithInvalidExchangeInfoThrowsException() {
    //  var authReq = new AuthReq {AppContainer = false, App = new AppExchangeInfo(), Containers = new List<ContainerPermissions>()};
    //  Assert.CatchAsync(async () => await Session.EncodeAuthReqAsync(authReq));
    //}
  }
}
