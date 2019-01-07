using System;
using System.Collections.Generic;
using System.Text;

namespace ApiDictionary.Model.DataAccess.PropertyDao
{
    public class PropertySearchFilter
    {
        public string Name { get; set; }
        public string PropertyType { get; set; }

        public PropertySearchFilter(string name, string propertyType)
        {
            Name = name == null ? string.Empty : name;
            PropertyType = propertyType == null ? string.Empty : name;
        }
    }
}
