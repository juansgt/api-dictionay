using System;
using System.Collections.Generic;
using System.Text;

namespace ApiDictionary.Model.DataAccess.Generic.Util
{
    public interface ICommandQuery<E>
    {
        IEnumerable<E> ExecuteQuery(); 
    }
}
