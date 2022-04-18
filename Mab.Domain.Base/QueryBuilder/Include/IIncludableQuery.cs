namespace Mab.Domain.Base.QueryBuilder
{
    public interface IIncludableQuery<TEntity,out TProperty> : IQuery<TEntity> where TEntity : class
    {
        string Path { get; set; }

    }
}
