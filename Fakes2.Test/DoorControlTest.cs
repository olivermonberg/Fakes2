using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NSubstitute;

namespace Fakes2.Test
{
    [TestFixture]
    public class DoorControlTest
    {
        private DoorControl _uut;
        private IUserValidation _uv;
        private IEntryNotification _en;
        private IDoor _d;
        private IAlarm _a;

        [SetUp]
        public void Setup()
        {
            _uv = Substitute.For<IUserValidation>();
            _en = Substitute.For<IEntryNotification>();
            _d = Substitute.For<IDoor>();
            _a = Substitute.For<IAlarm>();
            
            _uut = new DoorControl(_uv, _en, _d, _a);
        }

        [Test]
        public void Test_DoorControl()
        {
            _uv.ValidateEntryRequest("1234").Returns(false);

            _uut.RequestEntry("1234");

            Assert.IsFalse(_uv.ValidateEntryRequest("1234"));
        }

        [Test]
        public void Test_DoorControl2()
        {
            _uv.ValidateEntryRequest("1234").Returns(true);

            _uut.RequestEntry("1234");
            
            _uv.Received().ValidateEntryRequest("1234");
            
            _d.Received().Open();
            _en.Received().NotifyEntryGranted();

            _uut.DoorClosed(); //Ikke muligt at lukke døren
            _uut.DoorOpened();
            
            _d.Received().Close();
        }


    }
}
