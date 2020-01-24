using AutoMapper;
using CopaFilmes.Application.Interface;
using CopaFilmes.Application.Model;
using CopaFilmes.Domain.Entity;
using CopaFilmes.Domain.Interface;
using System.Collections.Generic;
using System.Linq;

namespace CopaFilmes.Application.Service
{
    public class FilmeAppService : AppServiceBase<Filme, FilmeModel>, IFilmeAppService
    {
        public FilmeAppService(IMapper mapper, IFilmeService service) : base(mapper, service) { }

        public IEnumerable<FilmeModel> GetResultCup(IList<FilmeModel> filmes)
        {
            var orderedFilmes = (Service as IFilmeService).OrderByTitle(Mapper.Map<IList<Filme>>(filmes));
            var firsStageWinners = (Service as IFilmeService).GetWinnersFirstStage(orderedFilmes).ToList();
            var eliminatoryStageWinners = (Service as IFilmeService).GetWinnersEliminatory(firsStageWinners);

            return Mapper.Map<IEnumerable<FilmeModel>>(eliminatoryStageWinners);
        }
    }
}