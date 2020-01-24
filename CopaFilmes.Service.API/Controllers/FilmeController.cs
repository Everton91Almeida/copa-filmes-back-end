using CopaFilmes.Application.Interface;
using CopaFilmes.Application.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CopaFilmes.Service.API.Controllers
{
    public class FilmeController : ControllerBase<FilmeModel>
    {
        public FilmeController(IFilmeAppService application) : base(application) { }

        [HttpPost]
        [Route("winners")]
        public IActionResult Post(IList<FilmeModel> filmes) =>
            new ObjectResult((Application as IFilmeAppService).GetResultCup(filmes));
    }
}