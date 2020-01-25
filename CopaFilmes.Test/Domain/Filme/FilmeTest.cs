using Xunit;

namespace CandidateTesting.EvertonRodrigoLimaDeAlmeida.Test
{
    [Collection(nameof(FilmeCollection))]
    public class FilmeTest
    {
        private readonly FilmeFixture ServiceFixture;

        public FilmeTest(FilmeFixture serviceFixture) =>
            ServiceFixture = serviceFixture;

        [Fact(DisplayName = "Check winner")]
        [Trait("Entity", "Filme")]
        public void Filme_GetWinner_ReturnWinner()
        {
            var winner = ServiceFixture.CreteWinnerFilme();
            var loser = ServiceFixture.CreteLoserFilme();

            var result = winner.GetWinner(loser);

            Assert.Equal(winner, result);
        }

        [Fact(DisplayName = "Check winner when draw")]
        [Trait("Entity", "Filme")]
        public void Filme_GetWinner_ReturnWinnerByEqualRating()
        {
            var winner = ServiceFixture.CreteDrawWinnerFilme();
            var loser = ServiceFixture.CreteDrawLoserFilme();

            var result = winner.GetWinner(loser);

            Assert.Equal(winner, result);
        }        
    }
}
