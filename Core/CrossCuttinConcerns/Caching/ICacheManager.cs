using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttinConcerns.Caching
{
    public interface ICacheManager
    {
        T Get<T>(string key);
        object Get(string key);
        void Add(string key, object value, int duration);
        bool IsAss(string key);
        void Remove(string key);
        void RemoveByPattern(string pattern);
    }
}
