using System;
using System.Collections.Generic;
using System.Text;

namespace ApiDictionary.Model.DataAccess.Generic.Util
{
    public class PaginationMongo : Pagination
    {
        public PaginationMongo(int pageSize, int pageNumber)
        {
            PageSize = pageSize;
            PageNumber = pageNumber;
        }

        public override int CalculatePageNumber()
        {
            return PageNumber > 0 ? ((PageNumber - 1) * PageSize) : 0;
        }
    }
}
