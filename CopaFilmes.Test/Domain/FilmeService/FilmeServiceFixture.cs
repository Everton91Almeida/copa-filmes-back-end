using CopaFilmes.Domain.Entity;
using CopaFilmes.Domain.Service;
using Moq.AutoMock;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CandidateTesting.EvertonRodrigoLimaDeAlmeida.Test
{
    public class FilmeServiceFixture : IDisposable
    {
        public FilmeService FilmeService;
        public AutoMocker Mocker;

        public FilmeService GetFilmeService() =>
            new AutoMocker().CreateInstance<FilmeService>();

        public IList<Filme> GetFilmes() =>
            new List<Filme> {
                new Filme("tt3606756", "Os Incríveis 2", 2018, 8.5f),
                new Filme("tt4881806", "Jurassic World: Reino Ameaçado", 2018, 6.7f),
                new Filme("tt5164214", "Oito Mulheres e um Segredo", 2018, 6.3f),
                new Filme("tt7784604", "Hereditário", 2018, 7.8f),
                new Filme("tt4154756", "Vingadores: Guerra Infinita", 2018, 8.8f),
                new Filme("tt5463162", "Deadpool 2", 2018, 8.1f),
                new Filme("tt3778644", "Han Solo: Uma História Star Wars", 2018, 7.2f),
                new Filme("tt3501632", "Thor: Ragnarok", 2017, 7.9f)
            };

        public IList<Filme> GetAlphabeticalOrderedFilmes() =>
            new List<Filme> {
                new Filme("tt5463162", "Deadpool 2", 2018, 8.1f),
                new Filme("tt3778644", "Han Solo: Uma História Star Wars", 2018, 7.2f),
                new Filme("tt7784604", "Hereditário", 2018, 7.8f),
                new Filme("tt4881806", "Jurassic World: Reino Ameaçado", 2018, 6.7f),
                new Filme("tt5164214", "Oito Mulheres e um Segredo", 2018, 6.3f),
                new Filme("tt3606756", "Os Incríveis 2", 2018, 8.5f),
                new Filme("tt3501632", "Thor: Ragnarok", 2017, 7.9f),
                new Filme("tt4154756", "Vingadores: Guerra Infinita", 2018, 8.8f)
            };

        public IList<Filme> GetFirstStageWinnerFilmes() =>
            new List<Filme> {
                new Filme("tt4154756", "Vingadores: Guerra Infinita", 2018, 8.8f),
                new Filme("tt3501632", "Thor: Ragnarok", 2017, 7.9f),
                new Filme("tt3606756", "Os Incríveis 2", 2018, 8.5f),
                new Filme("tt4881806", "Jurassic World: Reino Ameaçado", 2018, 6.7f)
            };

        public IList<Filme> GetEliminatoryWinnerFilmes() =>
            new List<Filme> {
                new Filme("tt4154756", "Vingadores: Guerra Infinita", 2018, 8.8f),
                new Filme("tt3606756", "Os Incríveis 2", 2018, 8.5f)
            };

        public Filme GetWinner() =>
            new Filme("tt4154756", "Vingadores: Guerra Infinita", 2018, 8.8f);

        public void Dispose() =>
            GC.SuppressFinalize(this);
    }

    [CollectionDefinition(nameof(FilmeServiceCollection))]
    public class FilmeServiceCollection : ICollectionFixture<FilmeServiceFixture> { }
}