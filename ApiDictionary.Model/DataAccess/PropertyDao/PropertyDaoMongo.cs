using System;
using System.Collections.Generic;
using System.Text;
using ApiDictionary.Model.DataAccess.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace ApiDictionary.Model.DataAccess.PropertyDao
{
    public class PropertyDaoMongo : IPropertyDao
    {
        public Property CreateProperty(Property property)
        {
            var client = new MongoClient("mongodb://172.17.0.2:27017");
            var database = client.GetDatabase("dictionary");
            var collection = database.GetCollection<PropertyMongo>("properties");

            PropertyMongo propertyMongo = new PropertyMongo();
            propertyMongo.Name = property.Name;
            propertyMongo.PropertyType = property.PropertyType;
            propertyMongo.Examples = property.Examples;

            collection.InsertOne(propertyMongo);

            return property;
        }

        public class PropertyMongo
        {
            [BsonId]
            public ObjectId Id { get; set; }
            [BsonElement("propertyType")]
            public string PropertyType { get; set; }
            [BsonElement("name")]
            public string Name { get; set; }
            [BsonElement("examples")]
            public IEnumerable<string> Examples { get; set; }
        }
    }
}
