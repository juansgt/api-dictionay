﻿using ApiDictionary.Model.DataAccess.Entities;
using ApiDictionary.Model.DataAccess.Generic;
using ApiDictionary.Model.DataAccess.Generic.Util;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiDictionary.Model.DataAccess.PropertyDao.PropertyDaoMongo
{
    public class PropertyDaoMongoImpl : IPropertyDao
    {
        private readonly MongoClient mongoClient;
        private readonly IMongoDatabase mongoDatabase;
        public IMongoCollection<PropertyMongo> PropertiesCollection { get; }

        public PropertyDaoMongoImpl(MongoClient mongoClient, IMongoDatabase mongoDatabase)
        {
            this.mongoClient = mongoClient;
            this.mongoDatabase = mongoDatabase;
            this.PropertiesCollection = mongoDatabase.GetCollection<PropertyMongo>("properties");
        }

        public Property Find(string id)
        {
            ObjectId objectId = ObjectId.Parse(id);
            PropertyMongo propertyMongo = PropertiesCollection.Find(p => p.Id == objectId).FirstOrDefault();

            return propertyMongo.ConvertToProperty();
        }

        public IEnumerable<Property> FindAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Property> FindAllByFilter(PropertySearchFilter searchFilter, Pagination pagination)
        {
            IFindFluent<PropertyMongo, PropertyMongo> query = null;

            if (searchFilter.Name != null && searchFilter.PropertyType == null)
            {
                query = PropertiesCollection.Find(p => p.Name == searchFilter.Name);
            }
            else if (searchFilter.Name == null && searchFilter.PropertyType != null)
            {
                query = PropertiesCollection.Find(p => p.PropertyType == searchFilter.PropertyType);
            }
            else if (searchFilter.Name != null && searchFilter.PropertyType != null)
            {
                query = PropertiesCollection.Find(p => p.Name == searchFilter.Name && p.PropertyType == searchFilter.PropertyType);
            }
            else if (searchFilter.Name == null && searchFilter.PropertyType == null)
            {
                query = PropertiesCollection.Find(_ => true);
            }

            return this.ConvertAllToProperties(query.Skip(pagination.CalculatePageNumber())
                                                    .Limit(pagination.PageSize)
                                                    .ToList());
        }

        public Property CreateProperty(Property property)
        {
            PropertyMongo propertyMongo = PropertyMongo.ConvertToPropertyMongo(property);

            PropertiesCollection.InsertOne(propertyMongo);
            property.Id = propertyMongo.Id.ToString();

            return property;
        }

        protected IEnumerable<Property> ConvertAllToProperties(IEnumerable<PropertyMongo> propertiesMongo)
        {
            List<Property> porperties = new List<Property>();

            foreach (PropertyMongo propertieMongo in propertiesMongo)
            {
                porperties.Add(propertieMongo.ConvertToProperty());
            }

            return porperties;
        }
    }
}
