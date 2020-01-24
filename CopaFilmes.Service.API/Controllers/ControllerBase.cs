using CopaFilmes.Application.Interface;
using CopaFilmes.Application.Model;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CopaFilmes.Service.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ControllerBase<TModel> : Controller
       where TModel : ModelBase
    {
        protected readonly IAppServiceBase<TModel> Application;

        public ControllerBase(IAppServiceBase<TModel> application) =>
            Application = application;

        [HttpGet]
        public virtual async Task<IActionResult> Get() =>
           new ObjectResult(await Application.Get());

    }
}