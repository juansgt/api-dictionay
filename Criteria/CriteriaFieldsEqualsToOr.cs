using System;
using System.Collections.Generic;
using System.Text;

namespace Criteria
{
    public class CriteriaFieldsEqualsToOr<E> : ICriteria<E>
    {
        public (string fieldToCompare, string valueToCompare)[] DataToCompare { get; set; }

        public CriteriaFieldsEqualsToOr(params (string fieldToCompare, string valueToCompare)[] dataToCompare)
        {
            DataToCompare = dataToCompare;
        }

        public IEnumerable<E> MeetCriteria(IEnumerable<E> items)
        {
            List<E> result = new List<E>();
            string valueInDataSource;
            string valueToCompare;

            foreach (E item in items)
            {
                foreach ((string fieldToCompare, string valueToCompare) dataToCompare in DataToCompare)
                {
                    valueInDataSource = item.GetType().GetProperty(dataToCompare.fieldToCompare).GetValue(item).ToString();
                    valueToCompare = dataToCompare.valueToCompare;

                    if (valueInDataSource != valueToCompare)
                    {
                        result.Add(item);
                        break;
                    }
                }
            }

            return result;
        }
    }
}
