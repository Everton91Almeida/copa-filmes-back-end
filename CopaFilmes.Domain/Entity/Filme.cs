using System.Linq;

namespace CopaFilmes.Domain.Entity
{
    public class Filme : EntityBase
    {
        public Filme() { }

        public Filme(string id, string titulo, short ano, float nota)
        {
            Id = id;
            Titulo = titulo;
            Ano = ano;
            Nota = nota;
        }

        public string Titulo { get; set; }
        public short Ano { get; set; }
        public float Nota { get; set; }

        public Filme GetWinner(Filme filme) =>
            Nota != filme.Nota ?
            GetWinnerByRating(filme) :
            GetWinnerByAlphabetical(filme);

        private Filme GetWinnerByRating(Filme filme) =>
            Nota > filme.Nota ? this : filme;

        private Filme GetWinnerByAlphabetical(Filme filme) =>
           new[] { this, filme }.OrderBy(f => f.Titulo)
           .FirstOrDefault();

        public override string ToString() => $"{GetType().Name} [Título={Titulo}]";
    }
}