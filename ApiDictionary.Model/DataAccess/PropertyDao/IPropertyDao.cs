using ApiDictionary.Model.DataAccess.Entities;
using ApiDictionary.Model.DataAccess.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiDictionary.Model.DataAccess.PropertyDao
{
    public interface IPropertyDao
    {
        Property Find(string id);
        IEnumerable<Property> FindAll();
        IEnumerable<Property> FindAllByFilter(SearchFilter searchFilter, Pagination pagination);
        Property CreateProperty(Property property);
    }
}
