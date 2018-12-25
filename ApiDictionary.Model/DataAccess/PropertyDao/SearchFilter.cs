using System;
using System.Collections.Generic;
using System.Text;

namespace ApiDictionary.Model.DataAccess.PropertyDao
{
    public class SearchFilter
    {
        public string Name { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }

        public SearchFilter(string name, int pageSize, int pageNumber)
        {
            Name = name;
            PageSize = pageSize;
            PageNumber = pageNumber;
        }
    }
}
