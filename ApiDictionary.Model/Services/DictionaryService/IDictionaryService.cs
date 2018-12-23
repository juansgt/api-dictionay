using ApiDictionary.Model.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiDictionary.Model.Services.DictionaryService
{
    public interface IDictionaryService
    {
        Property Find(string id);
        IEnumerable<Property> FindAllByName(string name);
        Property CreateProperty(Property property);
    }
}
