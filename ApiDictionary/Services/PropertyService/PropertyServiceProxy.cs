using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiDictionary.Model.DataAccess.Entities;
using ApiDictionary.Model.Services.DictionaryService;
using ApiDictionary.Models;
using Criteria;
using Microsoft.Extensions.DependencyInjection;
using static ApiDictionary.Services.PropertyService.PropertyFilter;

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
            return this.ConvertToPropertyModel(dictionaryService.Find(id));
        }

        public IEnumerable<PropertyModel> FindAllFilter(PropertyFilter propertyFilter, Operand operand)
        {
            ICriteria<PropertyFilter, Property> criteriaFieldsEqualsToAnd = new CriteriaFieldsEqualsToAnd<PropertyFilter, Property>();
            IEnumerable<Property> properties = criteriaFieldsEqualsToAnd.MeetCriteria(propertyFilter, dictionaryService.FindAll());

            return this.ConvertAllToPropertyModel(properties);
        }

        public IEnumerable<PropertyModel> FindAllByName(string name)
        {
            throw new NotImplementedException();
            //ICriteria<Property> criteria = new CriteriaFieldEqualsTo<Property>("Name", name);

            //return this.ConvertAllToPropertyModel(criteria.MeetCriteria(dictionaryService.FindAll()));
        }

        public PropertyModel CreateProperty(PropertyModel propertyModel)
        {
            propertyModel.Id = dictionaryService.CreateProperty(this.ConvertToProperty(propertyModel)).Id;

            return propertyModel;
        }

        protected PropertyModel ConvertToPropertyModel(Property property)
        {
            PropertyModel propertyModel = new PropertyModel();

            propertyModel.Id = property.Id;
            propertyModel.Examples = property.Examples;
            propertyModel.Name = property.Name;
            propertyModel.PropertyType = property.PropertyType;

            return propertyModel;
        }

        protected Property ConvertToProperty(PropertyModel propertyModel)
        {
            Property property = new Property();

            property.Examples = propertyModel.Examples;
            property.Name = propertyModel.Name;
            property.PropertyType = propertyModel.PropertyType;

            return property;
        }

        protected IEnumerable<PropertyModel> ConvertAllToPropertyModel(IEnumerable<Property> properties)
        {
            List<PropertyModel> porperties = new List<PropertyModel>();

            foreach (Property property in properties)
            {
                porperties.Add(this.ConvertToPropertyModel(property));
            }

            return porperties;
        }
    }
}
