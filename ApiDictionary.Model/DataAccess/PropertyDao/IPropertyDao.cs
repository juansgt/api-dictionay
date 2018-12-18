using ApiDictionary.Model.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiDictionary.Model.DataAccess.PropertyDao
{
    public interface IPropertyDao
    {
        Property CreateProperty(Property property);
    }
}
