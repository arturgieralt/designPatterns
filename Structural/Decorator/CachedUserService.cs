using System;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;

namespace Structural.Decorator
{
    public class CachedUserService: IUserService
    {
        private string CacheKey = "Users";
        private MemoryCacheEntryOptions CacheOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(30));
        private IUserService _userService;
        private  IMemoryCache _cache;

        public CachedUserService(IUserService userService, IMemoryCache cache)
        {
            _userService = userService;
            _cache = cache;
        }

        public IEnumerable<string> GetAll()
        {
            IEnumerable<string> users;

            if (!_cache.TryGetValue(CacheKey, out users))
            {
                users = _userService.GetAll();
                SetCache(users);
            }

            return users;
        }

        private void SetCache(IEnumerable<string> users) 
        {
            _cache.Set(CacheKey, users, CacheOptions);
        }
    }
}