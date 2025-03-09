namespace Core.Utilities.MappingTools.Abstract
{
    public interface IMapperTool
    {
        TDestination Map<TSource, TDestination>(TSource source);
        TDestination Map<TSource, TDestination>(TSource source, TDestination destination);
    }
}
