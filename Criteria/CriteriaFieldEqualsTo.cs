using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Criteria
{
    public class CriteriaFieldEqualsTo<E> : ICriteria<E>
    {
        public string ValueToCompare { get; set; }
        public string FieldToCompare { get; set; }
        private readonly IEnumerable<E> items;

        public CriteriaFieldEqualsTo(string fieldToCompare, string valueToCompare, IEnumerable<E> items)
        {
            ValueToCompare = valueToCompare;
            FieldToCompare = fieldToCompare;
        }

        public IEnumerable<E> meetCriteria()
        {
            return items.Where(item => item.GetType().GetProperty(FieldToCompare).GetValue(item).ToString() == ValueToCompare).ToList();
        }
    }
}
