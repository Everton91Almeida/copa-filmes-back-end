using System.Linq;

namespace CopaFilmes.Domain.Entity
{
    public class Filme : EntityBase
    {
        public string Titulo { get; set; }
        public short Ano { get; set; }
        public float Nota { get; set; }

        public Filme GetWinner(Filme filme) =>
            (Nota != filme.Nota) ?
            GetWinnerByRating(filme) :
            GetWinnerByAlphabetical(filme);

        private Filme GetWinnerByRating(Filme filme) =>
            new[] { this, filme }.OrderByDescending(f => f.Nota)
            .FirstOrDefault();

        private Filme GetWinnerByAlphabetical(Filme filme) =>
           new[] { this, filme }.OrderBy(f => f.Titulo)
           .FirstOrDefault();
    }
}