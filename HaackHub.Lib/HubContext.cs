using System;
using System.Linq;
using System.Linq.Expressions;

namespace HaackHub
{
    /// <summary>
    /// This is pretending to be an EF Core DbContext, but it's
    /// not good enough, nor smart enough.
    /// </summary>
    public class HubContext
    {
        public IQueryable<Issue> Issues { get; set; }
    }
    
#region Fake stuff so I don't have to set up a full EF setup

public static class HubContextExtensions
{
    public static IIncludeQueryable<TSource, TProperty> Include<TSource, TProperty>(
        this IQueryable<TSource> queryable,
        Expression<Func<TSource, TProperty>> propertyExpression)
    {
        return (IIncludeQueryable<TSource, TProperty>)queryable;
    }

    public static IQueryable<TSource> ThenInclude<TSource, TProperty, TSubProperty>(
        this IIncludeQueryable<TSource, TProperty> queryable,
        Expression<Func<TProperty, TSubProperty>> propertyExpression)
    {
        return queryable;
    }
}

public interface IIncludeQueryable<TSource, TProperty> : IQueryable<TSource>
{
}

#endregion
}