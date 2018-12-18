using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDictionary.Models
{
    public class PropertyModel
    {
        public string Id { get; set; }
        public string PropertyType { get; set; }
        public string Name { get; set; }
        public IEnumerable<string> Examples { get; set; }
    }
}
