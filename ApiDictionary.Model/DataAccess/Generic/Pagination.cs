using System;
using System.Collections.Generic;
using System.Text;

namespace ApiDictionary.Model.DataAccess.Generic
{
    public class Pagination
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }

        public Pagination(int pageSize, int pageNumber)
        {
            PageSize = pageSize;
            PageNumber = pageNumber;
        }
    }
}
