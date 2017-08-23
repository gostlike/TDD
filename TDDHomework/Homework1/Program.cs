using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Homework1
{
    public class MockData
    {
        public List<Employee> GetMockEmployeesList()
        {
            var list = new List<Employee>(); 
            list.Add(new Employee() { Id = 1, Cost = 1, Revenue = 11, Sellprice = 21, Sellprice2 = 31});
            list.Add(new Employee() { Id = 2, Cost = 2, Revenue = 12, Sellprice = 22 });
            list.Add(new Employee() { Id = 3, Cost = 3, Revenue = 13, Sellprice = 23 });
            list.Add(new Employee() { Id = 4, Cost = 4, Revenue = 14, Sellprice = 24 });
            list.Add(new Employee() { Id = 5, Cost = 5, Revenue = 15, Sellprice = 25 });
            list.Add(new Employee() { Id = 6, Cost = 6, Revenue = 16, Sellprice = 26 });
            list.Add(new Employee() { Id = 7, Cost = 7, Revenue = 17, Sellprice = 27 });
            list.Add(new Employee() { Id = 8, Cost = 8, Revenue = 18, Sellprice = 28 });
            list.Add(new Employee() { Id = 9, Cost = 9, Revenue = 19, Sellprice = 29 });
            list.Add(new Employee() { Id = 10, Cost = 10, Revenue = 20, Sellprice = 30 });
            list.Add(new Employee() { Id = 11, Cost = 11, Revenue = 21, Sellprice = 31 });
            return list;
        }

        public List<Deparment> GetMockDepartmentList()
        {
            var list = new List<Deparment>();
            list.Add(new Deparment() { Name = "1", Budget = 1 });
            list.Add(new Deparment() { Name = "2", Budget = 2 });
            list.Add(new Deparment() { Name = "3", Budget = 3 });
            list.Add(new Deparment() { Name = "4", Budget = 4 });
            list.Add(new Deparment() { Name = "5", Budget = 5 });
            return list;
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            var mockData  = new MockData();
            var list = mockData.GetMockEmployeesList();
            var calculator = new Calculator();
            
            foreach (var obj in calculator.GetSumOfList<Employee>(list, "Cost", 3))
            {
                Console.WriteLine(obj);
            }
            foreach (var obj in calculator.GetSumOfList<Employee>(list, "Revenue", 4))
            {
                Console.WriteLine(obj);
            }
            Console.ReadLine();

        }
    }
    public  class Calculator
    {
        public List<int> GetSumOfList<T>(
             List<T> list, string propertyName, int offset)
        {
            var result = new List<int>();
            var property = typeof(T).GetProperty(propertyName,typeof(int));
            if (property == null ||  offset <0)
                throw  new ArgumentException();

            if (offset.Equals(0))
            {
                result.Add(0);
                return result;
            }
                
          
            var first = 0;
            
            var length = list.Count;
            while (first < length)
            {
                offset = ((length - first)<offset) ? length - first : offset;
                result.Add(list.GetRange(first, offset).
                    Sum<T>(x => Convert.ToInt32(property.GetValue(x, null))));
                first += offset;
            }
            return result;
        }
    }
    public class Employee
    {
        public int Cost { get; set; }

        public int Id { get; set; }

        public int Revenue { get; set; }

        public int Sellprice { get; set; }

        public int Sellprice2 { get; set; }
    }

    public class Deparment
    {
        public string Name { get; set; }
        public int Budget { get; set; }
    }
}
