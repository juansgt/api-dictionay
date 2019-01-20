using System;
using System.Collections.Generic;
using System.Text;

namespace Criteria
{
    public interface ICriteria<F,E>
    {
        IEnumerable<E> MeetCriteria(IEnumerable<E> items);
    }
}
