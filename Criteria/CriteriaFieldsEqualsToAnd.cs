using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Criteria
{
    public class CriteriaFieldsEqualsToAnd<F, E> : ICriteria<F, E>
    {
        private object valueInDataSource;
        private object valueToCompare;

        public IEnumerable<E> MeetCriteria(F filter, IEnumerable<E> items)
        {
            List<E> result = new List<E>();
            int count;
            PropertyInfo[] filterProperties = filter.GetType().GetProperties();
            
            foreach (E item in items)
            {
                count = 0;
                foreach(PropertyInfo property in filterProperties)
                {
                    count++;
                    SetDataSourceValueAndValueToCompare(item, property, filter);

                    if (valueInDataSource == valueToCompare)
                    {
                        if (count == filterProperties.Length)
                            result.Add(item);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return result;
        }

        protected void SetDataSourceValueAndValueToCompare(E item, PropertyInfo property, F filter)
        {
            object objectDataSource;
            object objectToCompare;
            CriteriaFilterAttribute criteriaFilterAttribute;

            criteriaFilterAttribute = (CriteriaFilterAttribute)property.GetCustomAttribute(typeof(CriteriaFilterAttribute), false);
            objectDataSource = item.GetType().GetProperty(criteriaFilterAttribute.FilterPropertyName).GetValue(item);
            objectToCompare = property.GetValue(filter);
            Type t1 = objectDataSource.GetType();
            Type t2 = objectToCompare.GetType();
            valueInDataSource = objectDataSource;
            valueToCompare = objectToCompare;
            //Type t1 = valueToCompare.GetType();
            //Type t2 = valueInDataSource.GetType();
            //t2.ToString();

            //if (objectDataSource == null)
            //    valueInDataSource = string.Empty;
            //else
            //    valueInDataSource = objectDataSource.ToString();


            //if (objectToCompare == null)
            //    valueToCompare = string.Empty;
            //else
            //    valueToCompare = objectToCompare.ToString();
        }
    }
}
