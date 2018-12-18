using System;
using System.Collections.Generic;
using System.Text;

namespace ApiDictionary.Model.DataAccess.Entities
{
    public class Property
    {
        public string Id { get; set; }
        public string PropertyType { get; set; }
        public string Name { get; set; }
        public IEnumerable<string> Examples { get; set; }
    }
}
