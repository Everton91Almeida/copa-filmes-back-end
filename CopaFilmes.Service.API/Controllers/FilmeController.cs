using CopaFilmes.Application.Interface;
using CopaFilmes.Application.Model;

namespace CopaFilmes.Service.API.Controllers
{
    public class FilmeController : ControllerBase<FilmeModel>
    {
        public FilmeController(IFilmeAppService application) : base(application) { }
    }
}