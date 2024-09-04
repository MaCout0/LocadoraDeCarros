using FizzWare.NBuilder;
using LocadoraDeCarros.Dominio.Combustivel;
using LocadoraDeCarros.Dominio.ModuloCliente;
using LocadoraDeCarros.Dominio.ModuloCondutor;
using LocadoraDeCarros.Dominio.ModuloGrupoDeAutomovel;
using LocadoraDeCarros.Dominio.ModuloLocacao;
using LocadoraDeCarros.Dominio.ModuoAutomovel;
using LocadoraDeCarros.Tests.Compartilhado;

namespace LocadoraDeCarros.Tests.ModuloLocacao;

[TestClass]
[TestCategory("Integração")]
public class RepositorioLocacaoEmOrmTests : RepositorioEmOrmTestesBase
{
    [TestMethod]
    public void Deve_Inserir_Locacao()
    {
        // Arrange
        var grupo = Builder<GrupoDeAutomoveis>
            .CreateNew()
            .With(g => g.Id = 0)
            .Persist();

        var veiculo = Builder<Automovel>
            .CreateNew()
            .With(v => v.Id = 0)
            .With(v => v.GrupoDeAutomoveisId = grupo.Id)
            .Persist();

        var cliente = Builder<Cliente>
            .CreateNew()
            .With(c => c.Id = 0)
            .Persist();

        var condutor = Builder<Condutor>
            .CreateNew()
            .With(c => c.Id = 0)
            .With(c => c.ClienteId = cliente.Id)
            .Persist();

        var configCombustivel = Builder<ConfiguracaoCombustivel>
            .CreateNew()
            .With(c => c.Id = 0)
            .Persist();

        var locacao = Builder<Locacao>
            .CreateNew()
            .With(l => l.Id = 0)
            .With(l => l.AutomovelId = veiculo.Id)
            .With(l => l.CondutorId = condutor.Id)
            .With(l => l.ConfiguracaoCombustivelId = configCombustivel.Id)
            .With(l => l.DataLocacao = DateTime.Now)
            .With(l => l.DevolucaoPrevista = DateTime.Now.AddDays(3))
            .Build();

        // Act
        repositorioLocacao.Inserir(locacao);

        // Assert
        var locacaoSelecionada = repositorioLocacao.SelecionarPorId(locacao.Id);

        Assert.IsNotNull(locacaoSelecionada);
        Assert.AreEqual(locacao, locacaoSelecionada);
    }

    [TestMethod]
    public void Deve_Editar_Locacao()
    {
        // Arrange
        var grupo = Builder<GrupoDeAutomoveis>
            .CreateNew()
            .With(g => g.Id = 0)
            .Persist();

        var veiculo = Builder<Automovel>
            .CreateNew()
            .With(v => v.Id = 0)
            .With(v => v.GrupoDeAutomoveisId = grupo.Id)
            .Persist();

        var cliente = Builder<Cliente>
            .CreateNew()
            .With(c => c.Id = 0)
            .Persist();

        var condutor = Builder<Condutor>
            .CreateNew()
            .With(c => c.Id = 0)
            .With(c => c.ClienteId = cliente.Id)
            .Persist();

        var configCombustivel = Builder<ConfiguracaoCombustivel>
            .CreateNew()
            .With(c => c.Id = 0)
            .Persist();

        var locacao = Builder<Locacao>
            .CreateNew()
            .With(l => l.Id = 0)
            .With(l => l.AutomovelId = veiculo.Id)
            .With(l => l.CondutorId = condutor.Id)
            .With(l => l.ConfiguracaoCombustivelId = configCombustivel.Id)
            .With(l => l.DataLocacao = DateTime.Now)
            .With(l => l.DevolucaoPrevista = DateTime.Now.AddDays(3))
            .Persist();

        locacao.DevolucaoPrevista = locacao.DevolucaoPrevista.AddDays(2);

        // Act
        repositorioLocacao.Editar(locacao);

        // Assert
        var locacaoSelecionada = repositorioLocacao.SelecionarPorId(locacao.Id);

        Assert.IsNotNull(locacaoSelecionada);
        Assert.AreEqual(locacao, locacaoSelecionada);
    }

    [TestMethod]
    public void Deve_Excluir_Locacao()
    {
        // Arrange
        var grupo = Builder<GrupoDeAutomoveis>
            .CreateNew()
            .With(g => g.Id = 0)
            .Persist();

        var veiculo = Builder<Automovel>
            .CreateNew()
            .With(v => v.Id = 0)
            .With(v => v.GrupoDeAutomoveisId = grupo.Id)
            .Persist();

        var cliente = Builder<Cliente>
            .CreateNew()
            .With(c => c.Id = 0)
            .Persist();

        var condutor = Builder<Condutor>
            .CreateNew()
            .With(c => c.Id = 0)
            .With(c => c.ClienteId = cliente.Id)
            .Persist();

        var configCombustivel = Builder<ConfiguracaoCombustivel>
            .CreateNew()
            .With(c => c.Id = 0)
            .Persist();

        var locacao = Builder<Locacao>
            .CreateNew()
            .With(l => l.Id = 0)
            .With(l => l.AutomovelId = veiculo.Id)
            .With(l => l.CondutorId = condutor.Id)
            .With(l => l.ConfiguracaoCombustivelId = configCombustivel.Id)
            .With(l => l.DataLocacao = DateTime.Now)
            .With(l => l.DevolucaoPrevista = DateTime.Now.AddDays(3))
            .Persist();

        // Act
        repositorioLocacao.Excluir(locacao);

        // Assert
        var locacaoSelecionada = repositorioLocacao.SelecionarPorId(locacao.Id);
        var locacoes = repositorioLocacao.SelecionarTodos();

        Assert.IsNull(locacaoSelecionada);
        Assert.AreEqual(0, locacoes.Count);
    }
}