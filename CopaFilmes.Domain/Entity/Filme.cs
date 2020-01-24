namespace CopaFilmes.Domain.Entity
{
    public class Filme : EntityBase
    {
        public string Titulo { get; set; }
        public short Ano { get; set; }
        public float Nota { get; set; }
    }
}