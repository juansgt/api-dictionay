﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using ApiDictionary.Model.DataAccess.Entities;
using ApiDictionary.Model.DataAccess.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace ApiDictionary.Model.DataAccess.PropertyDao
{
    public class PropertyDaoMongo : IPropertyDao
    {
        private readonly MongoClient mongoClient;
        private readonly IMongoDatabase mongoDatabase;
        private readonly IMongoCollection<PropertyMongo> propertiesCollection; 

        public PropertyDaoMongo(MongoClient mongoClient, IMongoDatabase mongoDatabase)
        {
            this.mongoClient = mongoClient;
            this.mongoDatabase = mongoDatabase;
            this.propertiesCollection = mongoDatabase.GetCollection<PropertyMongo>("properties");
        }

        public Property Find(string id)
        {
            ObjectId objectId = ObjectId.Parse(id);
            PropertyMongo propertyMongo = propertiesCollection.Find(p => p.Id == objectId).FirstOrDefault();

            return propertyMongo.ConvertToProperty();
        }

        public IEnumerable<Property> FindAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Property> FindAllByFilter(SearchFilter searchFilter, Pagination pagination)
        {
            IFindFluent<PropertyMongo, PropertyMongo> query = null;

            if (searchFilter.Name != null && searchFilter.PropertyType == null)
            {
                query = propertiesCollection.Find(p => p.Name == searchFilter.Name);
            }
            else if (searchFilter.Name == null && searchFilter.PropertyType != null)
            {
                query = propertiesCollection.Find(p => p.PropertyType == searchFilter.PropertyType);
            }
            else if (searchFilter.Name != null && searchFilter.PropertyType != null)
            {
                query = propertiesCollection.Find(p => p.Name == searchFilter.Name && p.PropertyType == searchFilter.PropertyType);
            }
            else if (searchFilter.Name == null && searchFilter.PropertyType == null)
            {
                query = propertiesCollection.Find(_ => true);
            }

            return this.ConvertAllToProperties(query.Skip(this.calculatePageNumber(pagination.PageSize, pagination.PageNumber))
                                                    .Limit(pagination.PageSize)
                                                    .ToList());
        }

        public Property CreateProperty(Property property)
        {
            PropertyMongo propertyMongo = PropertyMongo.ConvertToPropertyMongo(property);

            propertiesCollection.InsertOne(propertyMongo);
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

        protected int calculatePageNumber(int pageNumber, int pageSize)
        {
            return pageNumber > 0 ? ((pageNumber - 1) * pageSize) : 0;
        }

        protected class PropertyMongo
        {
            [BsonId]
            public ObjectId Id { get; set; }
            [BsonElement("propertyType")]
            public string PropertyType { get; set; }
            [BsonElement("name")]
            public string Name { get; set; }
            [BsonElement("examples")]
            public IEnumerable<string> Examples { get; set; }

            public Property ConvertToProperty()
            {
                Property property = new Property();

                property.Id = this.Id.ToString();
                property.Name = this.Name;
                property.PropertyType = this.PropertyType;
                property.Examples = this.Examples;

                return property;
            }

            public static PropertyMongo ConvertToPropertyMongo(Property property)
            {
                PropertyMongo propertyMongo = new PropertyMongo();

                propertyMongo.Id = property.Id == null ? ObjectId.Empty : ObjectId.Parse(property.Id);
                propertyMongo.Name = property.Name;
                propertyMongo.PropertyType = property.PropertyType;
                propertyMongo.Examples = property.Examples;

                return propertyMongo;
            }
        }
    }
}
