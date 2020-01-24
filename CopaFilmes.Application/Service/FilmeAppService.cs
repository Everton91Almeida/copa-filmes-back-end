using AutoMapper;
using CopaFilmes.Application.Interface;
using CopaFilmes.Application.Model;
using CopaFilmes.Domain.Entity;
using CopaFilmes.Domain.Interface;

namespace CopaFilmes.Application.Service
{
    public class FilmeAppService : AppServiceBase<Filme, FilmeModel>, IFilmeAppService
    {
        public FilmeAppService(IMapper mapper, IFilmeService service) : base(mapper, service) { }
    }
}