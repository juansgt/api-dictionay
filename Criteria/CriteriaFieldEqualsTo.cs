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

        public CriteriaFieldEqualsTo(string fieldToCompare, string valueToCompare)
        {
            ValueToCompare = valueToCompare;
            FieldToCompare = fieldToCompare;
        }

        public IEnumerable<E> MeetCriteria(IEnumerable<E> items)
        {
            return items.Where(item => item.GetType().GetProperty(FieldToCompare).GetValue(item).ToString() == ValueToCompare).ToList();
        }
    }
}
