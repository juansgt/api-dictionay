using System;
using System.Collections.Generic;
using System.Text;

namespace ApiDictionary.Model.DataAccess.Generic.Util
{
    public abstract class Pagination
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }

        public abstract int CalculatePageNumber();
    }
}
