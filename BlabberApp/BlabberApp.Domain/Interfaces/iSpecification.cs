using System;
using System.Linq.Expressions;

namespace BlabberApp.Domain.Interfaces
{
    public interface iSpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get; }
    }
}