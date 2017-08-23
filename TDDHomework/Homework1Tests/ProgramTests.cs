using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homework1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpectedObjects;
using NSubstitute;

namespace Homework1.Tests
{
    
    [TestClass()]
    public class ProgramTests
    {
        //1	3筆一組，取Cost總和	6,15,24,21
        [TestMethod()]
        public void GetSumOfCollectionTest_field_is_cost_first_is_1_offset_is_3_sum_should_be_6()
        {
            //arrange
            Calculator calculator = new Calculator();
            var expected = 6;

            //act
            var actul = calculator.GetSumOfCollectionByFieldAndFirstAndOffset<IList<Employee>>("Cost", 1, 3);
            
            //assert
            expected.ToExpectedObject().ShouldEqual(actul);
        }

        [TestMethod()]
        public void GetSumOfCollectionTest_field_is_cost_first_is_4_offset_is_3_should_be_15()
        {

           
        }

        [TestMethod()]
        public void GetSumOfCollectionTest_field_is_cost_first_is_7_offset_is_3_should_be_24()
        {

            Assert.Fail();
        }

        [TestMethod()]
        public void GetSumOfCollectionTest_field_is_cost_first_is_10_offset_is_3_should_be_21()
        {

            Assert.Fail();
        }
        //2	4筆一組，取Revenue總和	50,66,60
        [TestMethod()]
        public void GetSumOfCollectionTest_field_is_revenue_first_is_1_offset_is_4_should_be_50()
        {

            Assert.Fail();
        }
    }
}