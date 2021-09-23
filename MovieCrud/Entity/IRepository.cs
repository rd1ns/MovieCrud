using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCrud.Entity
{
    public interface IRepository <T> where T:class
    {
        Task CreateAsync(T entity);
        Task<List<T>> ReadAllAsync();
    }
}
