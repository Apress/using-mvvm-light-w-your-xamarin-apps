using TimeOfDeath.Models;

namespace TimeOfDeath.Interfaces
{
    public interface ICalculateData
    {
        void SetCalcData(CalcData data);
        CalcData GetCalcData();

        void SetData<T>(string propertyName, T value);

        T GetData<T>(string propertyName);
    }
}
