﻿using System;
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

        public Property Find(string id)
        {
            return propertyDao.Find(id);
        }

        public IEnumerable<Property> FindAllByName(string name, int pageSize, int pageNumber)
        {
            return propertyDao.FindAllByName(name);
        }

        public Property CreateProperty(Property property)
        {
            return propertyDao.CreateProperty(property);
        }
    }
}
