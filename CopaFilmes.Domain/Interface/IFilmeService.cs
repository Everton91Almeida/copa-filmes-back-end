using CopaFilmes.Domain.Entity;
using System.Collections.Generic;

namespace CopaFilmes.Domain.Interface
{
    public interface IFilmeService : IServiceBase<Filme>
    {
        IList<Filme> OrderByTitle(IList<Filme> filmes);
        IEnumerable<Filme> GetWinnersFirstStage(IList<Filme> filmes);
        IEnumerable<Filme> GetWinnersEliminatory(IList<Filme> filmes);
    }
}