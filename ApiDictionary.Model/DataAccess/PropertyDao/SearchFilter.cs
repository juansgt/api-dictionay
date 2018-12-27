using System;
using System.Collections.Generic;
using System.Text;

namespace ApiDictionary.Model.DataAccess.PropertyDao
{
    public class SearchFilter
    {
        public string Name { get; set; }
        public string PropertyType { get; set; }

        public SearchFilter(string name, string propertyType)
        {
            Name = name;
            PropertyType = propertyType;
        }
    }
}
