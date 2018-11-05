using NUnit.Framework;
using TestStack.BDDfy;
namespace FirewallTests
{
    using lab4.Network;
    public class NetworkAddressTest
    {
        NetworkAddress _validAddr1;
        NetworkAddress _validAddr2;
        NetworkAddress _validAddr3;
        NetworkAddress _comparedAddr;
        NetworkAddress _notSameAddr;
        
        void GivenTheNetworkAddressLocalhostIsArrayOf4Bytes() {
            byte[] b = { 127, 0, 0, 1 };
            _validAddr1 = new NetworkAddress(b);
        }
        
        void AndGivenTheNetworkAddressLocalhostIsArrayOf10BytesWhereFrom2To5bytesThereIsAddress() {
            byte[] b = { 0, 1, 127, 0, 0, 1, 6, 7, 8, 9 };
            _validAddr2 = new NetworkAddress(b, 2);
        }

        void AndGivenTheNetworkAddressLocalhostIsValidString() {
            _validAddr3 = new NetworkAddress("127.0.0.1");
        }

        void GivenTheNetworkAddressLocalhostIsOtherObjectNetworkAddress() {
            byte[] b = { 127, 0, 0, 1 };
            NetworkAddress otherAddress = new NetworkAddress(b);
            _comparedAddr = new NetworkAddress(otherAddress);
        }

        void WhenTheUserRequestsTheAddress() {
        }

        void WhenTheUserInitializesNetworkAddresOthersAddress() {
            _notSameAddr = new NetworkAddress(_comparedAddr);  
        }

        void ThenTheAllAddressShouldBeLocalhost() {
            NetworkAddress addr = new NetworkAddress("127.0.0.1");
            Assert.AreEqual(addr, _validAddr1);
            Assert.AreEqual(addr, _validAddr2);
            Assert.AreEqual(addr, _validAddr3);
            Assert.AreEqual(addr, _comparedAddr);
        }

        void ThenTheAddressLocalhostNotSameOtherAddressLocalhost() {
            Assert.AreNotSame(_comparedAddr, _notSameAddr);            
        }        

        [Test]
        public void TestConstructorsOnEqualsAddress() {
            this.Given(s => s.GivenTheNetworkAddressLocalhostIsArrayOf4Bytes())
                    .And(s =>               s.AndGivenTheNetworkAddressLocalhostIsArrayOf10BytesWhereFrom2To5bytesThereIsAddress())
                    .And(s => s.AndGivenTheNetworkAddressLocalhostIsValidString())
                    .And(s => s.GivenTheNetworkAddressLocalhostIsOtherObjectNetworkAddress())
                .When(s => s.WhenTheUserRequestsTheAddress())
                .Then(s => s.ThenTheAllAddressShouldBeLocalhost())
                .BDDfy();
        }

        [Test]
        public void TestConstructorWithArgumentTypeIsNetworkAddressOnSame() {
            this.Given(s => s.GivenTheNetworkAddressLocalhostIsOtherObjectNetworkAddress())
                .When(s => s.WhenTheUserInitializesNetworkAddresOthersAddress())
                .Then(s => s.ThenTheAddressLocalhostNotSameOtherAddressLocalhost())
                .BDDfy();
        }
    }
}
