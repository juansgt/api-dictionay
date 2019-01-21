using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Criteria
{
    public class CriteriaIsNull<F, E> : ICriteria<E>
    {
        public string FieldToCompare { get; set; }

        public CriteriaIsNull(string fieldToCompare)
        {
            FieldToCompare = fieldToCompare;
        }

        public IEnumerable<E> MeetCriteria(IEnumerable<E> items)
        {
            return items.Where(item => item.GetType().GetProperty(FieldToCompare).GetValue(item) == null).ToList();
        }
    }
}
