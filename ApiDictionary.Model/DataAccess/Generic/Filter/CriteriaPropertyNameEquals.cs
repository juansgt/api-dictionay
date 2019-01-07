using ApiDictionary.Model.DataAccess.Entities;
using ApiDictionary.Model.DataAccess.Generic.Util;
using ApiDictionary.Model.DataAccess.PropertyDao;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiDictionary.Model.DataAccess.Generic.Filter
{
    public class CriteriaPropertyNameEquals : ICriteria<Property>
    {
        public string NameToCompare { get; private set; }
        private readonly IPropertyDao propertyDao;

        public CriteriaPropertyNameEquals(string nameToCompare, IPropertyDao propertyDao)
        {
            NameToCompare = nameToCompare;
            this.propertyDao = propertyDao;
        }

        public IEnumerable<Property> meetCriteria(Pagination pagination)
        {
            return propertyDao.FindAllByName(NameToCompare, pagination);
        }
    }
}
