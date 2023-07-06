using Mab.Domain.Base.QueryBuilder.CustomQuery.Includable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Mab.Domain.Base.QueryBuilder.CustomQuery
{
    public static class QueryableIncludeExtenssions
    {
        public static IIncludAbleQueryable<TEntity, TProperty> Include<TEntity, TProperty>(this IQueryable<TEntity> query, Expression<Func<TEntity, TProperty>> propertyPath) where TEntity : class
        {

            if (propertyPath.Body.NodeType != ExpressionType.MemberAccess)
            {
                throw new MemberAccessException();
            }
            var memberToInclude = propertyPath.Body as MemberExpression;
            string path = GetPropertyPath(memberToInclude);

            var res = new IncludAbleQueryable<TEntity, TProperty>(query)
            {
                Path = path
            };
            return res.Apply();
        }

        public static IIncludAbleQueryable<TEntity, TProperty> ThenInclude<TEntity, TPreviousProperty, TProperty>
            (
            this IIncludAbleQueryable<TEntity, IEnumerable<TPreviousProperty>> query,
            Expression<Func<TPreviousProperty, TProperty>> propertyPath) where TEntity : class
        {
            if (propertyPath.Body.NodeType != ExpressionType.MemberAccess)
            {
                throw new MemberAccessException();
            }

            var memberToInclude = propertyPath.Body as MemberExpression;
            string path = GetPropertyPath(memberToInclude);
            var res = new IncludAbleQueryable<TEntity, TProperty>(query)
            {
                Path = $"{query.Path}.{path}"
            };
            return res.Apply();
        }
        internal static string GetPropertyPath(MemberExpression body)
        {
            List<string> path = new List<string>();
            while (body != null)
            {
                string propertyName = body.Member.Name;
                path.Add(propertyName);
                body = body.Expression as MemberExpression;
            }
            path.Reverse();
            return string.Join(".", path);
        }

    }
}
