﻿using ApiDictionary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDictionary.Services.PropertyService
{
    public interface IPropertyService
    {
        PropertyModel Find(string id);
        IEnumerable<PropertyModel> FindAllByName(string name, int pageSize, int pageNumber);
        PropertyModel CreateProperty(PropertyModel propertyModel);
    }
}
