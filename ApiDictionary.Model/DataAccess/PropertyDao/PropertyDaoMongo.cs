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
        private readonly MongoClient mongoClient;
        private readonly IMongoDatabase mongoDatabase;

        public PropertyDaoMongo(MongoClient mongoClient, IMongoDatabase mongoDatabase)
        {
            this.mongoClient = mongoClient;
            this.mongoDatabase = mongoDatabase;

        }

        public Property Find(string id)
        {
            var collection = mongoDatabase.GetCollection<PropertyMongo>("properties");

            ObjectId objectId = ObjectId.Parse(id);
            PropertyMongo propertyMongo = collection.Find(p => p.Id == objectId).FirstOrDefault();

            return propertyMongo.ConvertToProperty();
        }

        public Property CreateProperty(Property property)
        {
            var collection = mongoDatabase.GetCollection<PropertyMongo>("properties");
            PropertyMongo propertyMongo = PropertyMongo.ConvertToPropertyMongo(property);

            collection.InsertOne(propertyMongo);
            property.Id = propertyMongo.Id.ToString();

            return property;
        }

        private class PropertyMongo
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
