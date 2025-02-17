using AutoMapper;
using AutoMapper.EquivalencyExpression;
using Core.Utilities.MappingTools.Abstract;

namespace Business.Mappers.AutoMapper
{
    public class AutoMapper : IMapperTool
    {
        private readonly Mapper _mapper;

        public AutoMapper()
        {
            var config = MapperConfiguration;

            config.CreateMapper();

            _mapper = new Mapper(config);

        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return _mapper.Map<TDestination>(source);
        }

        public THedef Map<TKaynak, THedef>(TKaynak kaynak, THedef hedef)
        {
            return _mapper.Map(kaynak, hedef);
        }

        private static MapperConfiguration _mapperConfiguration;

        private static MapperConfiguration MapperConfiguration
        {
            get
            {
                if (_mapperConfiguration == null)
                {
                    _mapperConfiguration = new MapperConfiguration(cfg =>
                    {
                        cfg.AddCollectionMappers();

                        cfg.AddProfiles(AutoMapperProfileList.GetAllProfile());
                    });
                }
                return _mapperConfiguration;
            }
        }

    }
}
