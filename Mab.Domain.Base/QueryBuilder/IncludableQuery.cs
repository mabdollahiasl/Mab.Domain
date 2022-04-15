using Mab.Domain.Base.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Mab.Domain.Base.QueryBuilder
{
    public static class IncludableQueryExtenssions
    {
        public static IIncludableQuery<TEntity, TProperty> Include<TEntity, TProperty>(this IQuery<TEntity> query, Expression<Func<TEntity, TProperty>> propertyPath) where TEntity : class
        {
            var next= new IncludableQuery<TEntity, TProperty>(propertyPath);
            query.Next=next;
            return next;
        }

        public static IIncludableQuery<TEntity, TProperty> ThenInclude<TEntity, TPreviousProperty, TProperty>
            (
            this IIncludableQuery<TEntity, IEnumerable<TPreviousProperty>> query,
            Expression<Func<TPreviousProperty, TProperty>> propertyPath) where TEntity:class
        {
           
            return null;
        }
    }
    public interface IIncludableQuery<TEntity,out TProperty> : IQuery<TEntity> where TEntity : class
    {

    }
    public class IncludableQuery<TEntity, TProperty> : IIncludableQuery<TEntity, TProperty> where TEntity : class
    {
        public IncludableQuery(Expression<Func<TEntity, TProperty>> propertyPath)
        {
            PropertyPath = propertyPath;
        }
        public Expression<Func<TEntity, TProperty>> PropertyPath { get; }
        public IQuery<TEntity> Next { get; set; }
    }
}
