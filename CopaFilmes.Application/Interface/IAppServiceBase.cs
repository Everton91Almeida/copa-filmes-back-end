using CopaFilmes.Application.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CopaFilmes.Application.Interface
{
    public interface IAppServiceBase<TModel> where TModel : ModelBase
    {
        Task<IEnumerable<TModel>> Get();
    }
}
