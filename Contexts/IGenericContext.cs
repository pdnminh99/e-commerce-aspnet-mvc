using System;
using System.Collections.Generic;

namespace EcommerceApp2259.Contexts
{
    public interface IGenericContext<T, K>
    {
        public T Add(T item);

        public T Delete(K itemId);

        public T Edit(T newCopy, bool autoInsertIfNotExist = false);

        public T Get(K uuid);

        public List<T> Get();

        public List<T> Get(string keyword);
    }
}