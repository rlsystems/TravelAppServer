using System.Linq.Expressions;

namespace ServerApp.Domain.Common.Contracts;

public class Filter<T>
{
    public bool Condition { get; set; }
    public Expression<Func<T, bool>> Expression { get; set; }
}