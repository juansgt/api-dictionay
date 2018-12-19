using ApiDictionary.Model.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiDictionary.Model.Services.DictionaryService
{
    public interface IDictionaryService
    {
        Property Find(string id);
        Property CreateProperty(Property property);
    }
}
