using AutoMapper;
using CopaFilmes.Application.Interface;
using CopaFilmes.Application.Model;
using CopaFilmes.Domain.Entity;
using CopaFilmes.Domain.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CopaFilmes.Application.Service
{
    public class AppServiceBase<TEntity, TModel> : IAppServiceBase<TModel>
         where TEntity : EntityBase
         where TModel : ModelBase
    {
        protected readonly IMapper Mapper;
        protected readonly IServiceBase<TEntity> Service;

        public AppServiceBase(IMapper mapper,
            IServiceBase<TEntity> service)
        {
            Service = service;
            Mapper = mapper;
        }

        public async Task<IEnumerable<TModel>> Get() =>
            Mapper.Map<IEnumerable<TModel>>(await Service.Get());
    }
}
