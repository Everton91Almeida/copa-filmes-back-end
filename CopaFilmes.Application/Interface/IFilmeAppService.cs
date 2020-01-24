using CopaFilmes.Application.Model;
using System.Collections.Generic;

namespace CopaFilmes.Application.Interface
{
    public interface IFilmeAppService : IAppServiceBase<FilmeModel>
    {
        IEnumerable<FilmeModel> GetResultCup(IList<FilmeModel> filmes);
    }
}
