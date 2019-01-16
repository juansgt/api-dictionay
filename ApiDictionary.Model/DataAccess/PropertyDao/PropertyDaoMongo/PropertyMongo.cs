using ApiDictionary.Model.DataAccess.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiDictionary.Model.DataAccess.PropertyDao.PropertyDaoMongo
{
    public class PropertyMongo
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("propertyType")]
        public string PropertyType { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("name")]
        public string Description { get; set; }
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
