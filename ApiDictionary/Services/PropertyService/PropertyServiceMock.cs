using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiDictionary.Models;

namespace ApiDictionary.Services.PropertyService
{
    public class PropertyServiceMock : IPropertyService
    {
        public PropertyModel CreateProperty(PropertyModel property)
        {
            throw new NotImplementedException();
        }
    }
}
