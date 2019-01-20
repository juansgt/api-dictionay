using System;
using System.Collections.Generic;
using System.Text;

namespace Criteria
{
    public class CriteriaAnd<F, E> : ICriteria<F, E>
    {
        private ICriteria<F, E> criteria;
        private ICriteria<F, E> otherCriteria;

        public CriteriaAnd(ICriteria<F, E> criteria, ICriteria<F, E> otherCriteria)
        {
            this.criteria = criteria;
            this.otherCriteria = otherCriteria;
        }

        public IEnumerable<E> MeetCriteria(IEnumerable<E> items)
        {
            IEnumerable<E> firstCriteriaPersons = criteria.MeetCriteria(items);

            return otherCriteria.MeetCriteria(firstCriteriaPersons);
        }
    }
}

