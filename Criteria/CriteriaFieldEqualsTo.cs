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
        private readonly IElementProvider<E> provider;

        public CriteriaFieldEqualsTo(string fieldToCompare, string valueToCompare, IElementProvider<E> provider)
        {
            ValueToCompare = valueToCompare;
            FieldToCompare = fieldToCompare;
            this.provider = provider;
        }

        public IEnumerable<E> meetCriteria()
        {
            IEnumerable<E> elements = provider.GetElements();

            return elements.Where(element => element.GetType().GetProperty(FieldToCompare).GetValue(element).ToString() == ValueToCompare).ToList();
        }
    }
}
