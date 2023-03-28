using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Mab.Domain.Base.QueryBuilder.CustomQuery
{
    public static class CustomQueryAppliers
    {
        public static List<Type> CustomAppliers { get; set; }
        public static ICustomQueryApplier<TEntity, TResult> GetQueryApplier<TEntity, TResult>(Type queryType) where TEntity : class
        {
            Type applier = null;
            var applierTarget = typeof(ICustomQueryApplier<TEntity, TResult>);

            var appliers = CustomAppliers.Where(t => t.GetInterfaces().Any(a => a == applierTarget)).ToList();
            if (appliers.Count == 1)
            {
                applier = appliers.First();
            }
            else if (appliers.Count > 1)
            {
                applier = appliers.FirstOrDefault(t =>
                {
                    var resolver = t.GetCustomAttribute<QueryResolverOfAttribute>();
                    return (resolver != null && resolver.CustomQueryType == queryType);
                });
            }
            if (applier == null)
            {
                throw new Exception($"Custom Query Applier for {queryType.Name} Not Found! Add applier class or override Query method on {queryType.Name} class.");
            }
            else
            {
                var applierInstanse = Activator.CreateInstance(applier);
                return applierInstanse == null
                    ? throw new Exception("Custom Query Applier cannot be created!")
                    : (ICustomQueryApplier<TEntity, TResult>)applierInstanse;
            }
        }
        internal static void InitializeTypes(params Type[] markerTypes)
        {
            List<Type> types = new List<Type>();
            var applierType = typeof(ICustomQueryApplier<,>);
            foreach (Type type in markerTypes)
            {
                var alltypes = type.Assembly.GetTypes();
                var allCustomTypes = alltypes.Where(t => t.GetInterfaces().Any(a => a.IsGenericType && a.GetGenericTypeDefinition() == applierType)).ToList();
                types.AddRange(allCustomTypes);
            }
            CustomQueryAppliers.CustomAppliers = types; 
        }
    }
}
