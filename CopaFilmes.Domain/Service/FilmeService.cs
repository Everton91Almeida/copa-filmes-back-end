using CopaFilmes.Domain.Configuration;
using CopaFilmes.Domain.Entity;
using CopaFilmes.Domain.Interface;

namespace CopaFilmes.Domain.Service
{
    public class FilmeService : ServiceBase<Filme>, IFilmeService
    {
        public FilmeService(ApiConfiguration configuration) : base(configuration) =>
            Route = "/api/filmes";
    }
}