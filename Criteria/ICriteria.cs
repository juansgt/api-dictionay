using System;
using System.Collections.Generic;
using System.Text;

namespace Criteria
{
    public interface ICriteria<E>
    {
        IEnumerable<E> meetCriteria();
    }
}
