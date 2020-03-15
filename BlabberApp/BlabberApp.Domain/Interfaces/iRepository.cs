using System.Collections.Generic;
using BlabberApp.Domain.Entities;

namespace BlabberApp.Domain.Interfaces
{
    public interface iRepository<T> where T : BaseEntity
    {
        void Add(T entity);

        void Remove(T entity);

        void Update(T entity);

        IEnumerable<T> GetAll();

        T GetBySysId(string sysId);

        T GetByUserId(string userId);
    }
}