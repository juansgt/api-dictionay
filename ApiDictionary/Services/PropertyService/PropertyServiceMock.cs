﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiDictionary.Models;
using static ApiDictionary.Services.PropertyService.PropertyFilter;

namespace ApiDictionary.Services.PropertyService
{
    public class PropertyServiceMock : IPropertyService
    {
        public PropertyModel Find(string id)
        {
            throw new NotImplementedException();
        }

        public PropertyModel CreateProperty(PropertyModel property)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PropertyModel> FindAllFilter(PropertyFilter propertyFilter, Operand operand)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PropertyModel> FindAllByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
