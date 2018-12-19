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

        public PropertyModel Find(string id)
        {
            PropertyModel propertyModel = new PropertyModel();
            Property property = dictionaryService.Find(id);

            propertyModel.Id = property.Id;
            propertyModel.Examples = property.Examples;
            propertyModel.Name = property.Name;
            propertyModel.PropertyType = property.PropertyType;

            return propertyModel;
        }

        public PropertyModel CreateProperty(PropertyModel propertyModel)
        {
            Property property = new Property();
            property.Examples = propertyModel.Examples;
            property.Name = propertyModel.Name;
            property.PropertyType = propertyModel.PropertyType;

            propertyModel.Id = dictionaryService.CreateProperty(property).Id;

            return propertyModel;
        }
    }
}
