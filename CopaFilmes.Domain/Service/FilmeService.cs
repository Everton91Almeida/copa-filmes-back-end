using CopaFilmes.Domain.Configuration;
using CopaFilmes.Domain.Entity;
using CopaFilmes.Domain.Interface;
using System.Collections.Generic;
using System.Linq;

namespace CopaFilmes.Domain.Service
{
    public class FilmeService : ServiceBase<Filme>, IFilmeService
    {
        public FilmeService(ApiConfiguration configuration) : base(configuration) =>
            Route = "/api/filmes";

        public IList<Filme> OrderByTitle(IList<Filme> filmes) =>
            filmes.OrderBy(f => f.Titulo).ToList();

        public IEnumerable<Filme> GetWinnersFirstStage(IList<Filme> filmes)
        {
            while (filmes.Any())
            {
                var filmeA = filmes.First();
                var filmeB = filmes.Last();
                filmes.Remove(filmeA);
                filmes.Remove(filmeB);
                yield return filmeA.GetWinner(filmeB);
            }
        }

        public IEnumerable<Filme> GetWinnersEliminatory(IList<Filme> filmes)
        {
            var winners = new List<Filme>();

            while (filmes.Any())
            {
                var filmeA = filmes.First();
                filmes.Remove(filmeA);
                var filmeB = filmes.First();
                filmes.Remove(filmeB);
                winners.Add(filmeA.GetWinner(filmeB));
            }

            if (winners.Count <= 2)
                return winners
                    .OrderByDescending(f => f.Nota)
                    .ThenBy(f => f.Titulo);
            else
                return GetWinnersEliminatory(winners);
        }
    }
}