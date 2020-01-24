using CopaFilmes.Domain.Configuration;
using CopaFilmes.Domain.Entity;
using CopaFilmes.Domain.Interface;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CopaFilmes.Domain.Service
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : EntityBase
    {
        private HttpClient Client;
        protected string Route;
        private readonly ApiConfiguration Configuration;
        public ServiceBase(ApiConfiguration configuration)
        {
            Configuration = configuration;
            Client = new HttpClient();
            Client.BaseAddress = Configuration.GetUri();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<TEntity>> Get()
        {
            var response = await Client.GetAsync(Route);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<TEntity>>(result);
            }

            return null;
        }
    }
}