using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homework1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpectedObjects;
using FluentAssertions;

namespace Homework1.Tests
{
    //該11筆資料，如果要3筆成一組，取得Cost的總和的話，預期結果是 6,15, 24, 21
    //該11筆資料，如果是4筆一組，取得 Revenue 總和的話，預期結果會是 50,66,60
    //筆數輸入負數，預期會拋 ArgumentException
    //尋找的欄位若不存在，預期會拋 ArgumentException
    //筆數若輸入為0, 則傳回0
    //未來可能會新增其他欄位
    //希望這個API可以給其他 domain entity 用，例如 Employee
    [TestClass()]
    public class CalculatorTests
    {
        private readonly List<Production> productList = new List<Production>
        {
            new Production() { Id = 1, Cost = 1, Revenue = 11, Sellprice = 2},
            new Production() { Id = 2, Cost = 2, Revenue = 12, Sellprice = 22 },
            new Production() { Id = 3, Cost = 3, Revenue = 13, Sellprice = 23 },
            new Production() { Id = 4, Cost = 4, Revenue = 14, Sellprice = 24 },
            new Production() { Id = 5, Cost = 5, Revenue = 15, Sellprice = 25 },
            new Production() { Id = 6, Cost = 6, Revenue = 16, Sellprice = 26 },
            new Production() { Id = 7, Cost = 7, Revenue = 17, Sellprice = 27 },
            new Production() { Id = 8, Cost = 8, Revenue = 18, Sellprice = 28 },
            new Production() { Id = 9, Cost = 9, Revenue = 19, Sellprice = 29 },
            new Production() { Id = 10, Cost = 10, Revenue = 20, Sellprice = 30 },
            new Production() { Id = 11, Cost = 11, Revenue = 21, Sellprice = 31 }
        };

        private readonly List<Employee> employeeList = new List<Employee>
        {
            new Employee() { Name = "1", Pay = 1},
            new Employee() { Name = "2", Pay = 2},
            new Employee() { Name = "3", Pay = 3},
            new Employee() { Name = "4", Pay = 4},
            new Employee() { Name = "5", Pay = 5}
        };


        //3筆一組，取Cost總和	6,15,24,21
        [TestMethod()]
        public void TestGetSum_size_is_3_SumOfProduction_Cost_should_be_6_15_24_21()
        {
            //arrange
            var expected = new List<int>() {6,15,24,21};

            //act
            var actual = productList.GetSum("Cost", 3);

            //assert
            expected.ToExpectedObject().ShouldEqual(actual);
        }

        //4筆一組，取Revenue總和	50,66,60
        [TestMethod()]
        public void TestGetSum_size_is_4_SumOfProduction_Revenue_should_be_50_66_60()
        {
            //arrange
            var expected = new List<int>() { 50,66,60 };

            //act
            var actual = productList.GetSum("Revenue", 4);

            //assert
            expected.ToExpectedObject().ShouldEqual(actual);
        }

        //筆數輸入負數，預期會拋 ArgumentException
        [TestMethod()]
        public void TestGetSum_size_is_negative_1_should_throw_ArgumentException()
        {
            //arrange

            //act
            Action actual = () => productList.GetSum("Revenue", -1);

            //assert
            actual.ShouldThrow<ArgumentException>();
        }

        //筆數若輸入為0, 則傳回0
        [TestMethod()]
        public void TestGetSum_size_is_0_SumOfProduction_Revenue_should_be_0()
        {
            //arrange
            var expected = new List<int>() { 0 };

            //act
            var actual = productList.GetSum("Revenue", 0);

            //assert
            expected.ToExpectedObject().ShouldEqual(actual);
        }
        
        //尋找的欄位若不存在，預期會拋 ArgumentException
        [TestMethod()]
        public void TestGetSum_Product_Revenue2_is_not_exixt_should_throw_ArgumentException()
        {
            //arrange
  
            //act
            Action actual = () => productList.GetSum("Revenue2", 4);

            //assert
            actual.ShouldThrow<ArgumentException>();
        }

        ///希望這個API可以給其他 domain entity 用，例如 Employee
        [TestMethod()]
        public void TestGetSum_size_is_3_SumOfEmployee_Pay_should_be_6_9_of_list()
        {
            //arrange
            var expected = new List<int>() { 6, 9 };

            //act
            var actual = employeeList.GetSum("Pay", 3);

            //assert
            expected.ToExpectedObject().ShouldEqual(actual);
        }
    }
}