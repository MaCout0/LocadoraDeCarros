using FizzWare.NBuilder;
using LocadoraDeCarros.Dominio.ModuloTaxaServico;
using LocadoraDeCarros.Dominio.PlanoCobranca;
using LocadoraDeCarros.Infra.Orm.Compartilhado;
using LocadoraDeCarros.Infra.Orm.ModuloTaxaServico;

namespace LocadoraDeCarros.Tests.ModuloTaxaServico;

[TestClass]
[TestCategory("Integração")]
public class RepositorioTaxaServicoEmOrmTests
{
    private LocadoraDbContext dbContext;
    private RepositorioTaxaServicoEmOrm repositorio;
    
    [TestInitialize]
    public void Inicializar()
    {
        dbContext = new LocadoraDbContext();

        dbContext.PlanosCobranca.RemoveRange(dbContext.PlanosCobranca);

        repositorio = new RepositorioTaxaServicoEmOrm(dbContext);

        BuilderSetup.SetCreatePersistenceMethod<TaxaServico>(repositorio.Inserir);
    }
    
    [TestMethod]
    public void Deve_Inserir_Taxa()
    {
        var taxaServico = new TaxaServico("Simpel", "teste", 15, tipoDeCobranca:TipoDeCobranca.PorDia);
        
        repositorio.Inserir(taxaServico);

        var taxaServicoEncontrado = repositorio.SelecionarPorId(taxaServico.Id);
        
        Assert.IsNotNull(taxaServicoEncontrado);
        Assert.AreEqual(taxaServico, taxaServicoEncontrado);
    }

    [TestMethod]
    public void Deve_Editar_Taxa()
    {
        var taxaServico = new TaxaServico("Simpel", "teste", 15, tipoDeCobranca:TipoDeCobranca.PorDia);
        repositorio.Inserir(taxaServico);

        taxaServico.Nome = "Test";
        
        repositorio.Editar(taxaServico);
        
        var taxaServicoEncontrado = repositorio.SelecionarPorId(taxaServico.Id);
        
        Assert.IsNotNull(taxaServicoEncontrado);
        Assert.AreEqual(taxaServico, taxaServicoEncontrado);
    }

    [TestMethod]
    public void Deve_Excluir_Taxa()
    {
        var taxaServico = new TaxaServico("Simpel", "teste", 15, tipoDeCobranca:TipoDeCobranca.PorDia);
        repositorio.Inserir(taxaServico);
        
        repositorio.Excluir(taxaServico);
        
        var grupoEncontrado = repositorio.SelecionarPorId(taxaServico.Id);
        
        Assert.IsNull(grupoEncontrado);
    }
}