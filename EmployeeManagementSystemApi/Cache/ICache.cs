using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;

namespace EmployeeManagementSystemApi.Cache
{
    public interface ICache
    {
        Task<T> GetObjectAsync<T>(string key);
        Task SetObjectAsync<T>(string key, T value);
    }
}