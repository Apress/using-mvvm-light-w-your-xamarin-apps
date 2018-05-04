using System;
using System.Threading.Tasks;

namespace OnlineUnitTesting
{
    public interface IWebAPI<T>
    {
        Task<T> GetRequestAsync(string apiUrl);

        Task<T> PostRequestAsync(string apiUrl, T postObject);

        Task PutRequestAsync(string apiUrl, T putObject);

        Task DeleteRequestAsync(string apiUrl);

        Task<V> PostRequestAsync<V>(string apiUrl, T postObject) where V : class;
    }
}
