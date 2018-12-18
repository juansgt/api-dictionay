using System;
using System.Collections.Generic;
using System.Text;
using ApiDictionary.Model.DataAccess.Entities;
using ApiDictionary.Model.DataAccess.PropertyDao;

namespace ApiDictionary.Model.Services.DictionaryService
{
    public class DictionaryService : IDictionaryService
    {
        private readonly IPropertyDao propertyDao;

        public DictionaryService(IPropertyDao propertyDao)
        {
            this.propertyDao = propertyDao;
        }

        public Property CreateProperty(Property property)
        {
            throw new NotImplementedException();
        }
    }
}
