using FizzWare.NBuilder;
using LocadoraDeCarros.Dominio.ModuloTaxaServico;
using LocadoraDeCarros.Dominio.PlanoCobranca;
using LocadoraDeCarros.Infra.Orm.Compartilhado;
using LocadoraDeCarros.Infra.Orm.ModuloTaxaServico;

namespace LocadoraDeCarros.Tests.ModuloTaxaServico;

[TestClass]
[TestCategory("Integração")]
public class RepositorioTaxaEmOrmTests
{
    private LocadoraDbContext dbContext;
    private RepositorioTaxaServicoEmOrm repositorio;

    [TestInitialize]
    public void Inicializar()
    {
        dbContext = new LocadoraDbContext();

        dbContext.TaxaServicos.RemoveRange(dbContext.TaxaServicos);

        repositorio = new RepositorioTaxaServicoEmOrm(dbContext);

        BuilderSetup.SetCreatePersistenceMethod<TaxaServico>(repositorio.Inserir);
    }

    [TestMethod]
    public void Deve_Inserir_Taxa()
    {
        var taxa = Builder<TaxaServico>
            .CreateNew()
            .With(t => t.Id = 0)
            .Build();

        repositorio.Inserir(taxa);

        var taxaSelecionada = repositorio.SelecionarPorId(taxa.Id);

        Assert.IsNotNull(taxaSelecionada);
        Assert.AreEqual(taxa, taxaSelecionada);
    }

    [TestMethod]
    public void Deve_Editar_Taxa()
    {
        var taxa = Builder<TaxaServico>
            .CreateNew()
            .With(t => t.Id = 0)
            .Persist();

        taxa.Nome = "Taxa Atualizada";
        taxa.Valor = 100.0m;

        repositorio.Editar(taxa);

        var taxaSelecionada = repositorio.SelecionarPorId(taxa.Id);

        Assert.IsNotNull(taxaSelecionada);
        Assert.AreEqual(taxa, taxaSelecionada);
    }

    [TestMethod]
    public void Deve_Excluir_Taxa()
    {
        var taxa = Builder<TaxaServico>
            .CreateNew()
            .With(t => t.Id = 0)
            .Persist();

        repositorio.Excluir(taxa);

        var taxaSelecionada = repositorio.SelecionarPorId(taxa.Id);

        var taxas = repositorio.SelecionarTodos();

        Assert.IsNull(taxaSelecionada);
        Assert.AreEqual(0, taxas.Count);
    }
}