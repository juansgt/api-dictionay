using ApiDictionary.Model.DataAccess.Generic.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiDictionary.Model.DataAccess.Generic.Filter
{
    public interface ICriteria<E>
    {
        IEnumerable<E> meetCriteria(Pagination pagination);
    }
}
