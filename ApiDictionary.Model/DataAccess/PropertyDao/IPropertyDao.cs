using ApiDictionary.Model.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiDictionary.Model.DataAccess.PropertyDao
{
    public interface IPropertyDao
    {
        Property Find(string id);
        IEnumerable<Property> FindAll();
        IEnumerable<Property> FindAllByName(string name, int pageSize, int pageNumber);
        Property CreateProperty(Property property);
    }
}
