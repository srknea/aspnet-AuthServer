using AutoMapper;
using AuthServer.Service.Mapping;

namespace UdemyAuthServer.Service
{
    public static class ObjectMapper
    {
        private static readonly Lazy<IMapper> lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MapProfile>();
            });

            return config.CreateMapper();
        });

        public static IMapper Mapper => lazy.Value;
    }
}