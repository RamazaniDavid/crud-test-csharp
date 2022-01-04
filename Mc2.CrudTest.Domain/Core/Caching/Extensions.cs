using System;
using System.Threading.Tasks;
namespace Mc2.CrudTest.Core.Caching
{
    public static class Extensions
    {
        public static  T Get<T>(this ICacheManager cacheManager, string key, int cacheTime, Func<T> getFromDb)
        {
            if (cacheManager.IsSet(key))
            {
                return cacheManager.Get<T>(key);
            }

            var result = getFromDb();
            if (cacheTime > 0)
                cacheManager.Set(key, result, cacheTime);
            return result;
        }

        public static async Task<T> GetAsync<T>(this ICacheManager cacheManager, string key, int cacheTime, Func<Task<T>> getFromDb)
        {
            if (cacheManager.IsSet(key))
            {
                return cacheManager.Get<T>(key);
            }

            var result =await getFromDb();
            if (cacheTime > 0)
                cacheManager.Set(key, result, cacheTime);
            return result;
        }
    }
}
