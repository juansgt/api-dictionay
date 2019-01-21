using System;
using System.Collections.Generic;
using System.Text;

namespace Criteria
{
    public class CriteriaFilterAttribute : Attribute
    {
        public string FilterPropertyName { get; private set; }

        public CriteriaFilterAttribute(string filterPropertyName)
        {
            this.FilterPropertyName = filterPropertyName;
        }
    }
}
