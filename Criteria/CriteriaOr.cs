using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Criteria
{
    public class CriteriaOr<E> : ICriteria<E>
    {
        private ICriteria<E> criteria;
        private ICriteria<E> otherCriteria;

        public CriteriaOr(ICriteria<E> criteria, ICriteria<E> otherCriteria)
        {
            this.criteria = criteria;
            this.otherCriteria = otherCriteria;
        }

        public IEnumerable<E> meetCriteria()
        {
            List<E> firstCriteriaElements = criteria.meetCriteria().ToList();
            IEnumerable<E> otherCriteriaElements = otherCriteria.meetCriteria();

            foreach (E element in otherCriteriaElements)
            {
                if (!firstCriteriaElements.Contains(element))
                {
                    firstCriteriaElements.Add(element);
                }
            }
            return firstCriteriaElements;
        }
    }
}
