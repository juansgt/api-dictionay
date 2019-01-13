using System;
using System.Collections.Generic;
using System.Text;

namespace Criteria
{
    public interface IElementProvider<E>
    {
        IEnumerable<E> GetElements();
    }
}
