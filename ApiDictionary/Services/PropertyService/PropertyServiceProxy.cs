using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiDictionary.Model.DataAccess.Entities;
using ApiDictionary.Model.Services.DictionaryService;
using ApiDictionary.Models;
using Microsoft.Extensions.DependencyInjection;

namespace ApiDictionary.Services.PropertyService
{
    public class PropertyServiceProxy : IPropertyService
    {
        private readonly IDictionaryService dictionaryService;

        public PropertyServiceProxy(IDictionaryService dictionaryService)
        {
            this.dictionaryService = dictionaryService;
        }

        public PropertyModel CreateProperty(PropertyModel propertyModel)
        {
            Property property = new Property();
            property.Examples = propertyModel.
            dictionaryService.CreateProperty()
        }
    }
}
