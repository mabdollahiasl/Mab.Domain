using Mab.Domain.Base.QueryBuilder.CustomQuery;
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

            if (propertyPath.Body.NodeType != ExpressionType.MemberAccess)
            {
                throw new MemberAccessException();
            }
            var memberToInclude = propertyPath.Body as MemberExpression;
            string path = QueryableIncludeExtenssions.GetPropertyPath(memberToInclude);

            var res = new IncludableQuery<TEntity, TProperty>
            {
                Path = path
            };
            query.Next = res;
            return res;
        }

        public static IIncludableQuery<TEntity, TProperty> ThenInclude<TEntity, TPreviousProperty, TProperty>
            (
            this IIncludableQuery<TEntity, IEnumerable<TPreviousProperty>> query,
            Expression<Func<TPreviousProperty, TProperty>> propertyPath) where TEntity : class
        {
            if (propertyPath.Body.NodeType != ExpressionType.MemberAccess)
            {
                throw new MemberAccessException();
            }

            var memberToInclude = propertyPath.Body as MemberExpression;
            string path = QueryableIncludeExtenssions.GetPropertyPath(memberToInclude);
            var res = new IncludableQuery<TEntity, TProperty>
            {
                Path = $"{query.Path}.{path}"
            };
            query.Next = res;
            return res;
        }

    }
}
