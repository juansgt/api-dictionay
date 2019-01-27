using ApiDictionary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ApiDictionary.Services.PropertyService.PropertyFilter;

namespace ApiDictionary.Services.PropertyService
{
    public interface IPropertyService
    {
        PropertyModel Find(string id);
        IEnumerable<PropertyModel> FindAllFilter(PropertyFilter propertyFilter, Operand operand);
        IEnumerable<PropertyModel> FindAllByName(string name);
        PropertyModel CreateProperty(PropertyModel propertyModel);
    }
}
