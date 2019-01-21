using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Criteria
{
    public class CriteriaAnd<F, E> : ICriteria<E>
    {
        private ICriteria<E> criteria;
        private ICriteria<E> otherCriteria;

        public CriteriaAnd(ICriteria<E> criteria, ICriteria<E> otherCriteria)
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

