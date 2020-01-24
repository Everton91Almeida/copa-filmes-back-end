using CopaFilmes.Domain.Service;
using System.Linq;
using Xunit;

namespace CandidateTesting.EvertonRodrigoLimaDeAlmeida.Test
{
    [Collection(nameof(FilmeServiceCollection))]
    public class FilmeServiceTest
    {
        private readonly FilmeServiceFixture ServiceFixture;
        private readonly FilmeService FilmeService;

        public FilmeServiceTest(FilmeServiceFixture serviceFixture)
        {
            ServiceFixture = serviceFixture;
            FilmeService = ServiceFixture.GetFilmeService();
        }

        [Fact(DisplayName = "Check alphabetical order by titulo")]
        [Trait("Service", "FilmeService")]
        public void FilmeService_OrderByTitle_ReturnOrderedListByTitulo()
        {
            var filmes = ServiceFixture.GetFilmes();
            var orderedFilmes = ServiceFixture.GetAlphabeticalOrderedFilmes();

            var result = FilmeService.OrderByTitle(filmes);

            Assert.Equal(orderedFilmes, result);
        }

        [Fact(DisplayName = "Check first stage winner filmes")]
        [Trait("Service", "FilmeService")]
        public void FilmeService_GetWinnersFirstStage_ReturnWinnersFirstStage()
        {
            var filmes = ServiceFixture.GetAlphabeticalOrderedFilmes();
            var winnerFilmes = ServiceFixture.GetFirstStageWinnerFilmes();

            var result = FilmeService.GetWinnersFirstStage(filmes).ToList();

            Assert.Equal(winnerFilmes, result);
        }

        [Fact(DisplayName = "Check eliminatory winner filmes")]
        [Trait("Service", "FilmeService")]
        public void FilmeService_GetWinnersEliminatory_ReturnEliminatoryStage()
        {
            var filmes = ServiceFixture.GetFirstStageWinnerFilmes();
            var winnerFilmes = ServiceFixture.GetEliminatoryWinnerFilmes();

            var result = FilmeService.GetWinnersEliminatory(filmes).ToList();

            Assert.Equal(winnerFilmes, result);
        }

        [Fact(DisplayName = "Check winner filme")]
        [Trait("Service", "FilmeService")]
        public void FilmeService_GetWinnersEliminatory_ReturnWinner()
        {
            var filmes = ServiceFixture.GetFirstStageWinnerFilmes();
            var winner = ServiceFixture.GetWinner();

            var result = FilmeService.GetWinnersEliminatory(filmes).First();

            Assert.Equal(winner, result);
        }
    }
}
