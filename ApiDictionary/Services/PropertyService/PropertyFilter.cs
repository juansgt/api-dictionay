﻿using Criteria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDictionary.Services.PropertyService
{
    public class PropertyFilter
    {
        [CriteriaFilter("PropertyType")]
        public string PropertyType { get; set; }

        [CriteriaFilter("Name")]
        public string Name { get; set; }

        [CriteriaFilter("Description")]
        public string Description { get; set; }

        public enum Operand { AND, OR };

        public PropertyFilter(string propertyType, string name, string description)
        {
            PropertyType = propertyType;
            Name = name;
            Description = description;
        }
    }
}