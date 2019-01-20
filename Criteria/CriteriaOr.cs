using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Criteria
{
    public class CriteriaOr<F, E> : ICriteria<F, E>
    {
        private ICriteria<F, E> criteria;
        private ICriteria<F, E> otherCriteria;

        public CriteriaOr(ICriteria<F, E> criteria, ICriteria<F, E> otherCriteria)
        {
            this.criteria = criteria;
            this.otherCriteria = otherCriteria;
        }

        public IEnumerable<E> MeetCriteria(IEnumerable<E> items)
        {
            List<E> firstCriteriaElements = criteria.MeetCriteria(items).ToList();
            IEnumerable<E> otherCriteriaElements = otherCriteria.MeetCriteria(items);

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
