using CopaFilmes.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CopaFilmes.Domain.Interface
{
    public interface IFilmeService : IServiceBase<Filme>
    {
        Task<IEnumerable<Filme>> Get();
    }
}