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
            var res = new IncludableQuery<TEntity, TProperty>
            {
                Path = memberToInclude.Member.Name
            };
            query.Next=res;
            return res;
        }

        public static IIncludableQuery<TEntity, TProperty> ThenInclude<TEntity, TPreviousProperty, TProperty>
            (
            this IIncludableQuery<TEntity, IEnumerable<TPreviousProperty>> query,
            Expression<Func<TPreviousProperty, TProperty>> propertyPath) where TEntity:class
        {
            if (propertyPath.Body.NodeType != ExpressionType.MemberAccess)
            {
                throw new MemberAccessException();
            }

            var memberToInclude = propertyPath.Body as MemberExpression;
            var res = new IncludableQuery<TEntity, TProperty>
            {
                Path = $"{query.Path}.{memberToInclude.Member.Name}"
            };
            query.Next = res;
            return res;
        }
    }
}
