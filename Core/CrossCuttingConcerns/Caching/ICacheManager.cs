using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        T Get<T>(string key); //Verilen keye karşılık bellekten data döndür.
        object Get(string key); //Generic olmayan, ancak; kullanırken type casting yapılması gereken, keye karşılık data döndüren imza.
        void Add(string key, object value, int duration);
        bool IsAdd(string key);
        void Remove(string key);
        void RemoveByPattern(string pattern);

    }
}
