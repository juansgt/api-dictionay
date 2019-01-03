using ApiDictionary.Model.DataAccess.Generic;
using ApiDictionary.Model.DataAccess.Generic.Util;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiDictionary.Model.DataAccess.PropertyDao.PropertyDaoMongo
{
    public class MongoCommandQuery : ICommandQuery<PropertyMongo>
    {
        private PropertyDaoMongoImpl propertyDaoMongoImpl;
        private PropertySearchFilter propertySearchFilter;
        private Pagination pagination;

        public MongoCommandQuery(PropertyDaoMongoImpl propertyDaoMongoImpl, PropertySearchFilter propertySearchFilter, Pagination pagination)
        {
            this.propertyDaoMongoImpl = propertyDaoMongoImpl;
            this.propertySearchFilter = propertySearchFilter;
            this.pagination = pagination;
        }

        public IEnumerable<PropertyMongo> ExecuteQuery()
        {
            return propertyDaoMongoImpl.PropertiesCollection.Find(p => p.Name == propertySearchFilter.Name)
                                       .Skip(pagination.CalculatePageNumber())
                                       .Limit(pagination.PageSize)
                                       .ToList();
        }
    }
}
