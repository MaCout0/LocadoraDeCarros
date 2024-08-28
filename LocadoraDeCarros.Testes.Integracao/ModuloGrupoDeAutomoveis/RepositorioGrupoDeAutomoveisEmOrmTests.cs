using FizzWare.NBuilder;
using LocadoraDeCarros.Dominio.ModuloGrupoDeAutomovel;
using LocadoraDeCarros.Dominio.ModuloTaxaServico;
using LocadoraDeCarros.Infra.Orm.Compartilhado;
using LocadoraDeCarros.Infra.Orm.ModuloGrupoDeAutomovel;

namespace LocadoraDeCarros.Testes.Integracao.ModuloGrupoDeAutomoveis;

[TestClass]
public class RepositorioGrupoDeAutomoveisEmOrmTests
{
    private LocadoraDbContext dbContext;
    private RepositorioGrupoDeAutomovelEmOrm repositorio;

    [TestInitialize]
    public void ConfigurarTestes()
    {
        dbContext = new LocadoraDbContext();
        
        dbContext.GrupoAutomoveis.RemoveRange(dbContext.GrupoAutomoveis);

        repositorio = new RepositorioGrupoDeAutomovelEmOrm(dbContext);
        
        BuilderSetup.SetCreatePersistenceMethod<GrupoDeAutomoveis>(repositorio.Inserir);
    }

    [TestMethod]
    public void Deve_Inserir_Grupo()
    {
        var novoGrupo = new GrupoDeAutomoveis("SUV");
        
        repositorio.Inserir(novoGrupo);

        var grupoEncontrado = repositorio.SelecionarPorId(novoGrupo.Id);
        
        Assert.IsNotNull(grupoEncontrado);
        Assert.AreEqual(novoGrupo.Id, grupoEncontrado.Id);
        Assert.AreEqual(novoGrupo.Nome, grupoEncontrado.Nome);
    }

    [TestMethod]
    public void Deve_Editar_Grupo()
    {
        var novoGrupo = new GrupoDeAutomoveis("SUV");
        repositorio.Inserir(novoGrupo);

        novoGrupo.Nome = "Economico";
        
        repositorio.Editar(novoGrupo);

        var grupoEncontrado = repositorio.SelecionarPorId(novoGrupo.Id);
        
        Assert.IsNotNull(grupoEncontrado);
        Assert.AreEqual(novoGrupo, grupoEncontrado);
    }

    [TestMethod]
    public void Deve_Excluir_Grupo()
    {
        var novoGrupo = new GrupoDeAutomoveis("SUV");
        repositorio.Inserir(novoGrupo);
        
        repositorio.Excluir(novoGrupo);

        var grupoEncontrado = repositorio.SelecionarPorId(novoGrupo.Id);
        
        Assert.IsNull(grupoEncontrado);
    }
}