using System;
using System.Fakes;
using Chapter_2_IDE_Fakes.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chapter_2_IDE_Fakes.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Customer_Should_Exist()
        {
            var stub = new StubICustomerRepository
            {
                ExistsString = (email) => { return true; }
            };
            var service = new CustomerService(stub);
            Assert.IsTrue(service.DoesCustomerExist("test@test.com"));
        }


        [TestMethod]
        public void Closure_Should_Set_Value_To_Expected()
        {
            //this will get set inside our stub
            string closureToTest = "";

            var stub = new StubICustomerRepository
            {
                ExistsString = (email) =>
                                   {
                                       closureToTest = "test"; //in reality set to some variable you want to test
                                       return true;
                                   }
            };

            const string expected = "test";
            Assert.IsTrue(closureToTest == expected);
        }


        /// <summary>
        /// Note running this test via Resharper doesnt work for some reason
        /// </summary>
        [TestMethod]
        public void Should_Override_DateTime_Now()
        {
            using (ShimsContext.Create())
            {
                ShimDateTime.NowGet = () => new DateTime(2012, 1, 1, 12, 00, 00);
                Assert.IsTrue(DateTime.Now == new DateTime(2012, 1, 1, 12, 00, 00));
            }
        }

    }
}
