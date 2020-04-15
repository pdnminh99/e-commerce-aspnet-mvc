using System;
using System.Collections.Generic;

namespace EcommerceApp2259.Contexts
{
    public interface IGenericContext<T>
    {
        public T Add(T item);

        public T Delete(Guid itemId);

        public T Edit(T replicant, bool autoInsertIfNotExist = false);

        public T Get(Guid uuid);

        public List<T> Get();

        public List<T> Get(string keyword);
    }
}