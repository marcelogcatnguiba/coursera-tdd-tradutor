using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CourseraTDD.Tests.Validation
{
    public static class DictionaryExtensions
    {
        public static bool NotContainsKey<TKey>(this Dictionary<TKey, string> dictionary, TKey key) where TKey : notnull
        {
            if (!dictionary.ContainsKey(key))
                return true;
            return false;
        }
    }
}