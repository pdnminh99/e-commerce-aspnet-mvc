using System;
using System.Collections.Generic;

namespace EcommerceApp2259.Context
{
    public interface IGenericContext<T> where T : IComparable<T>
    {
        public T Add(T item);

        public T Delete(Guid itemId);

        public T Edit(T replicant, bool autoInsertIfNotExist = false);

        public T Get(Guid uuid);

        public List<T> Get();

        public List<T> Get(string keyword);
    }
}