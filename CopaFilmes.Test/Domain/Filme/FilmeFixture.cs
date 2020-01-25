using Bogus;
using CopaFilmes.Domain.Entity;
using System;
using Xunit;

namespace CandidateTesting.EvertonRodrigoLimaDeAlmeida.Test
{
    public class FilmeFixture : IDisposable
    {

        public Filme CreteWinnerFilme() =>
            new Faker<Filme>("pt_BR")
            .RuleFor(c => c.Titulo, f => f.Lorem.Word())
            .RuleFor(c => c.Nota, f => f.Random.Float(9.5f, 10f))
            .Generate();

        public Filme CreteLoserFilme() =>
            new Faker<Filme>("pt_BR")
            .RuleFor(c => c.Titulo, f => f.Lorem.Word())
            .RuleFor(c => c.Nota, f => f.Random.Float(0.5f, 1f))
            .Generate();

        public Filme CreteDrawWinnerFilme() =>
            new Faker<Filme>("pt_BR")
            .RuleFor(c => c.Titulo, f => $"A{f.Lorem.Word()}")
            .RuleFor(c => c.Nota, f => 10)
            .Generate();

        public Filme CreteDrawLoserFilme() =>
            new Faker<Filme>("pt_BR")
            .RuleFor(c => c.Titulo, f => $"B{f.Lorem.Word()}")
            .RuleFor(c => c.Nota, f => 10)
            .Generate();


        public void Dispose() =>
            GC.SuppressFinalize(this);
    }

    [CollectionDefinition(nameof(FilmeCollection))]
    public class FilmeCollection : ICollectionFixture<FilmeFixture> { }
}