using NUnit.Framework;
using TestStack.BDDfy;
namespace FirewallTests
{
    using lab4.Network;
    class PhysicalAddressTest
    {
        PhysicalAddress _validAddr1;
        PhysicalAddress _validAddr2;
        PhysicalAddress _comparedAddr;
        PhysicalAddress _notSameAddr;

        void GivenThePhysicalAddressBroadcastIsArrayOf6Bytes() {
            byte[] b = { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff };
            _validAddr1 = new PhysicalAddress(b);
        }

        void AndGivenThePhysicalAddressBroadcastIsArrayOf10BytesWhereFrom2To7bytesThereIsAddress() {
            byte[] b = { 0, 1, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 8, 9 };
            _validAddr2 = new PhysicalAddress(b, 2);
        }

        void GivenThePhysicalAddressBroadcastIsOtherObjectPhysicalAddress() {
            byte[] b = { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff };
            PhysicalAddress othrAddr = new PhysicalAddress(b);
            _comparedAddr = new PhysicalAddress(othrAddr);
        }

        void WhenTheUserRequestsTheAddress() {
        }

        void WhenTheUserInitializesPhysicalAddresOthersAddress() {
            _notSameAddr = new PhysicalAddress(_comparedAddr);
        }

        void ThenTheAllAddressShouldBeBroadcast() {
            byte[] b = { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff };
            PhysicalAddress addr = new PhysicalAddress(b);
            Assert.AreEqual(_validAddr1, addr);
            Assert.AreEqual(_validAddr2, addr);
            Assert.AreEqual(_comparedAddr, addr);
        }

        void ThenTheAddressBroadcastNotSameOtherAddressBroadcast() {
            Assert.AreNotSame(_comparedAddr, _notSameAddr);
        }

        [Test]
        public void TestConstructorsOnEqualsAddress() {
            this.Given(s => s.GivenThePhysicalAddressBroadcastIsArrayOf6Bytes())
                    .And(s => s.AndGivenThePhysicalAddressBroadcastIsArrayOf10BytesWhereFrom2To7bytesThereIsAddress())
                    .And(s => s.GivenThePhysicalAddressBroadcastIsOtherObjectPhysicalAddress())
                .When(s => s.WhenTheUserRequestsTheAddress())
                .Then(s => s.ThenTheAllAddressShouldBeBroadcast())
                .BDDfy();
        }

        [Test]
        public void TestConstructorWithArgumentTypeIsPhysicalAddressOnSame() {
            this.Given(s => s.GivenThePhysicalAddressBroadcastIsOtherObjectPhysicalAddress())
                .When(s => s.WhenTheUserInitializesPhysicalAddresOthersAddress())
                .Then(s => s.ThenTheAddressBroadcastNotSameOtherAddressBroadcast())
                .BDDfy();
        }
    }
}
