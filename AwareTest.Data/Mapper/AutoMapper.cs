using AutoMapper;

namespace AwareTest.Data.Mapper
{
    internal class AutoMapper : IAutoMapper
    {
        private readonly IMapper _mapper;

        public AutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
            });

            _mapper = config.CreateMapper();
        }

        public T Map<T>(object obj)
        {
            return _mapper.Map<T>(obj);
        }
    }
}
