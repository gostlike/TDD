using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1
{
    public static class Calculator
    {
        public static List<int> GetSum<T>(
            this List<T> list, string propertyName, int size)
        {
            var result = new List<int>();
            if (size.Equals(0))
            {
                result.Add(0);
                return result;
            }
            var property = typeof(T).GetProperty(propertyName, typeof(int));
            if (property == null || size < 0)
                throw new ArgumentException();

            var first = 0;
            var length = list.Count;
            while (first < length)
            {
                size = ((length - first) < size) ? length - first : size;
                result.Add(list.GetRange(first, size).
                    Sum<T>(x => Convert.ToInt32(property.GetValue(x, null))));
                first += size;
            }
            return result;
        }
    }
}
