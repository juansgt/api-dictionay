using System;
using System.Collections.Generic;
using System.Text;

namespace Criteria
{
    public class CriteriaFieldsEqualsToAnd<F, E> : ICriteria<F, E>
    {
        public (string fieldToCompare, string valueToCompare)[] DataToCompare { get; set; }

        public CriteriaFieldsEqualsToAnd(params (string fieldToCompare, string valueToCompare)[] dataToCompare)
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
                for (int i = 0; i < DataToCompare.Length; i++) 
                {
                    valueInDataSource = item.GetType().GetProperty(DataToCompare[i].fieldToCompare).GetValue(item).ToString();
                    valueToCompare = DataToCompare[i].valueToCompare;

                    if (valueInDataSource != valueToCompare) break;

                    if (i == DataToCompare.Length - 1) result.Add(item);
                }
            }

            return result;
        }
    }
}
