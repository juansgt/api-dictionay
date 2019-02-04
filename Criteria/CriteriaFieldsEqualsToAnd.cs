using System;
using System.Collections;
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
        private CriteriaFilterAttribute criteriaFilterAttribute;
        private bool ignoreNullFilterValues { get; set; }

        public CriteriaFieldsEqualsToAnd()
        {
            valueInDataSource = null;
            valueToCompare = null;
            criteriaFilterAttribute = null;
            ignoreNullFilterValues = false;
        }

        public IEnumerable<E> MeetCriteria(F filter, IEnumerable<E> items)
        {
            List<E> result = new List<E>();
            int count;
            PropertyInfo[] filterProperties = filter.GetType().GetProperties();
            List<PropertyInfo> filterPropertiesWithCriteriaFilterAttribute = new List<PropertyInfo>();

            if (ignoreNullFilterValues)
            {
                foreach (PropertyInfo filterProperty in filterProperties)
                {
                    if ((CriteriaFilterAttribute)filterProperty.GetCustomAttribute(typeof(CriteriaFilterAttribute), false) != null && filterProperty.GetValue(filter) != null)
                        filterPropertiesWithCriteriaFilterAttribute.Add(filterProperty);
                }
            }
            else
            {
                foreach (PropertyInfo filterProperty in filterProperties)
                {
                    if ((CriteriaFilterAttribute)filterProperty.GetCustomAttribute(typeof(CriteriaFilterAttribute), false) != null)
                        filterPropertiesWithCriteriaFilterAttribute.Add(filterProperty);
                }
            }

            foreach (E item in items)
            {
                count = 0;
                foreach(PropertyInfo filterProperty in filterPropertiesWithCriteriaFilterAttribute)
                {
                    count++;
                    SetDataSourceValueAndValueToCompare(item, filterProperty, filter);

                    if (valueToCompare != null)
                    {
                        if (EqualityComparer<object>.Default.Equals(valueInDataSource, valueToCompare))
                        {
                            if (count == filterPropertiesWithCriteriaFilterAttribute.Count)
                                result.Add(item);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            return result;
        }

        protected void SetDataSourceValueAndValueToCompare(E item, PropertyInfo filterProperty, F filter)
        {
            criteriaFilterAttribute = (CriteriaFilterAttribute)filterProperty.GetCustomAttribute(typeof(CriteriaFilterAttribute), false);
            valueInDataSource = item.GetType().GetProperty(criteriaFilterAttribute.FilterPropertyName).GetValue(item);
            valueToCompare = filterProperty.GetValue(filter);
        }

        void ICriteria<F, E>.IgnoreNullFilterValues()
        {
            ignoreNullFilterValues = true;
        }

        //protected void SetDataSourceValueAndValueToCompare(E item, PropertyInfo property, F filter)
        //{
        //    object objectDataSource;
        //    object objectToCompare;
        //    CriteriaFilterAttribute criteriaFilterAttribute;

        //    criteriaFilterAttribute = (CriteriaFilterAttribute)property.GetCustomAttribute(typeof(CriteriaFilterAttribute), false);
        //    objectDataSource = item.GetType().GetProperty(criteriaFilterAttribute.FilterPropertyName).GetValue(item);
        //    objectToCompare = property.GetValue(filter);
        //    valueInDataSource = objectDataSource;
        //    valueToCompare = objectToCompare;

        //    //Type t1 = valueToCompare.GetType();
        //    //Type t2 = valueInDataSource.GetType();
        //    //t2.ToString();

        //    //if (objectDataSource == null)
        //    //    valueInDataSource = string.Empty;
        //    //else
        //    //    valueInDataSource = objectDataSource.ToString();


        //    //if (objectToCompare == null)
        //    //    valueToCompare = string.Empty;
        //    //else
        //    //    valueToCompare = objectToCompare.ToString();
        //}
    }
}
