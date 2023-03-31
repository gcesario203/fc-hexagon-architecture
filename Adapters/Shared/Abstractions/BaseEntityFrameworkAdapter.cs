using Adapters.Shared.Configuration;
using Adapters.Shared.Database.InMemory;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Adapters.Shared.Abstractions
{
    public abstract class BaseEntityFrameworkAdapter
    {
        protected readonly DbContext _context;

        protected readonly IMapper _autoMapper;

        public BaseEntityFrameworkAdapter()
        {
            _context = new InMemoryDbContext();
            var configs = new MapperConfiguration(config => config.AddProfile<MappingProfile>());

            _autoMapper = new Mapper(configs);
        }

        public BaseEntityFrameworkAdapter(DbContext dbContext, IMapper mapper)
        {
            _context = dbContext;
            _autoMapper = mapper;
        }
    }
}