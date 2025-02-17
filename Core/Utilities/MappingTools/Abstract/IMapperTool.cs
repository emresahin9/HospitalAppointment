namespace Core.Utilities.MappingTools.Abstract
{
    public interface IMapperTool
    {
        TDestination Map<TSource, TDestination>(TSource source);
        THedef Map<TKaynak, THedef>(TKaynak kaynak, THedef hedef);
    }
}
