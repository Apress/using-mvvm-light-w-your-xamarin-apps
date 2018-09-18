using System;
using System.Diagnostics;
using System.Reflection;
using TimeOfDeath.Interfaces;
using TimeOfDeath.Models;

namespace TimeOfDeath.Services
{
    public class CalcDataService : ICalculateData
    {
        CalcData calcData;

        public CalcData GetCalcData()
        {
            return calcData == null ? new CalcData() : calcData;
        }

        public void SetCalcData(CalcData data)
        {
            if (calcData == null)
                calcData = new CalcData();

            calcData = data;
        }

        public void SetData<T>(string propertyName, T value)
        {
            try
            {
                var property = calcData.GetType().GetRuntimeProperty(propertyName);
                property.SetValue(calcData, value, null);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception thrown - {0}", ex.Message);
            }
        }

        public T GetData<T>(string propertyName)
        {
            try
            {
                var property = calcData.GetType().GetRuntimeProperty(propertyName);
                return (T)property.GetValue(property, null);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception thrown - {0}", ex.Message);
                return default(T);
            }
        }
    }
}
