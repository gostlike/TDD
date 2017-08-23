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
        //3筆一組，取Cost總和	6,15,24,21
        [TestMethod()]
        public void GetSumOfListTest_property_is_cost_offset_is_3_sum_should_be_6_15_24_21_of_list()
        {
            //arrange
            var mockData = new MockData();
            var employeeList = mockData.GetMockEmployeesList();
            var expected = new List<int>() {6,15,24,21};
            var calculator = new Calculator();

            //act
            var actual = calculator.GetSumOfList(employeeList,"Cost", 3);

            //assert
            expected.ToExpectedObject().ShouldEqual(actual);
        }

        //4筆一組，取Revenue總和	50,66,60
        [TestMethod()]
        public void GetSumOfListTest_property_is_revenue_offset_is_4_sum_should_be_55_66_60_of_list()
        {
            //arrange
            var mockData = new MockData();
            var employeeList = mockData.GetMockEmployeesList();
            var expected = new List<int>() { 50,66,60 };
            var calculator = new Calculator();

            //act
            var actual = calculator.GetSumOfList(employeeList, "Revenue", 4);

            //assert
            expected.ToExpectedObject().ShouldEqual(actual);
        }

        //筆數輸入負數，預期會拋 ArgumentException
        [TestMethod()]
        public void GetSumOfListTest_offset_is_negative_1_should_throw_ArgumentException()
        {
            //arrange
            var mockData = new MockData();
            var employeeList = mockData.GetMockEmployeesList();
            var calculator = new Calculator();

            //act
            Action actual = () => calculator.GetSumOfList(employeeList, "Revenue", -1);

            //assert
            actual.ShouldThrow<ArgumentException>();
        }

        //筆數若輸入為0, 則傳回0
        [TestMethod()]
        public void GetSumOfListTest_offset_is_0_sum_should_be_0()
        {
            //arrange
            var mockData = new MockData();
            var employeeList = mockData.GetMockEmployeesList();
            var expected = new List<int>() { 0 };
            var calculator = new Calculator();

            //act
            var actual = calculator.GetSumOfList(employeeList, "Revenue", 0);

            //assert
            expected.ToExpectedObject().ShouldEqual(actual);
        }
        
        //尋找的欄位若不存在，預期會拋 ArgumentException
        [TestMethod()]
        public void GetSumOfListTest_property_is_not_exixt_should_throw_ArgumentException()
        {
            //arrange
            var mockData = new MockData();
            var employeesList = mockData.GetMockEmployeesList();
            var calculator = new Calculator();
  
            //act
            Action actual = () => calculator.GetSumOfList(employeesList, "Revenue2", 4);

            //assert
            actual.ShouldThrow<ArgumentException>();
        }

        ///希望這個API可以給其他 domain entity 用，例如 Employee,Department
        [TestMethod()]
        public void GetSumOfListTest_entity_is_Department_property_is_budget_offset_is_3_sum_should_be_6_9_of_list()
        {
            //arrange
            var mockData = new MockData();
            var departmentList = mockData.GetMockDepartmentList();
            var expected = new List<int>() { 6, 9 };
            var calculator = new Calculator();

            //act
            var actual = calculator.GetSumOfList(departmentList, "Budget", 3);

            //assert
            expected.ToExpectedObject().ShouldEqual(actual);
        }



    }
}