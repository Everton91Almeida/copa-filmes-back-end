using CopaFilmes.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CopaFilmes.Domain.Interface
{
    public interface IServiceBase<TEntity> where TEntity : EntityBase
    {
        Task<IEnumerable<TEntity>> Get();
    }
}