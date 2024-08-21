using LocadoraDeCarros.Dominio.ModuloGrupoDeAutomovel;
using LocadoraDeCarros.Infra.Orm.Compartilhado;
using LocadoraDeCarros.Infra.Orm.ModuloGrupoDeAutomovel;

namespace LocadoraDeCarros.Testes.Integracao.Orm;

[TestClass]
public class RepositorioGrupoDeAutomoveisEmOrmTests
{
    private LocadoraDeCarrosDbContext db;
    private RepositorioGrupoDeAutomovelEmOrm repositorioGrupo;

    [TestInitialize]
    public void ConfigurarTestes()
    {
        db = new LocadoraDeCarrosDbContext();
        
        db.GrupoAutomoveis.RemoveRange(db.GrupoAutomoveis);

        db.SaveChanges();

        repositorioGrupo = new RepositorioGrupoDeAutomovelEmOrm(db);
    }

    [TestMethod]
    public void Deve_Inserir_Grupo()
    {
        var novoGrupo = new GrupoDeAutomoveis("SUV");
        
        repositorioGrupo.Inserir(novoGrupo);

        var grupoEncontrado = repositorioGrupo.SelecionarPorId(novoGrupo.Id);
        
        Assert.IsNotNull(grupoEncontrado);
        Assert.AreEqual(novoGrupo.Id, grupoEncontrado.Id);
        Assert.AreEqual(novoGrupo.Nome, grupoEncontrado.Nome);
    }

    [TestMethod]
    public void Deve_Editar_Grupo()
    {
        var novoGrupo = new GrupoDeAutomoveis("SUV");
        repositorioGrupo.Inserir(novoGrupo);

        novoGrupo.Nome = "Economico";
        
        repositorioGrupo.Editar(novoGrupo);

        var grupoEncontrado = repositorioGrupo.SelecionarPorId(novoGrupo.Id);
        
        Assert.IsNotNull(grupoEncontrado);
        Assert.AreEqual(novoGrupo, grupoEncontrado);
    }

    [TestMethod]
    public void Deve_Excluir_Grupo()
    {
        var novoGrupo = new GrupoDeAutomoveis("SUV");
        repositorioGrupo.Inserir(novoGrupo);
        
        repositorioGrupo.Excluir(novoGrupo);

        var grupoEncontrado = repositorioGrupo.SelecionarPorId(novoGrupo.Id);
        
        Assert.IsNull(grupoEncontrado);
    }

    [TestMethod]
    public void Deve_Selecionar_Grupos()
    {
        GrupoDeAutomoveis[] gruposParaInserir =
        [
            new GrupoDeAutomoveis("SUV"),
            new GrupoDeAutomoveis("Econominco"),
            new GrupoDeAutomoveis("Luxo")
        ];

        foreach (var grupo in gruposParaInserir)
        {
            repositorioGrupo.Inserir(grupo);
        }

        var gruposSelecionados = repositorioGrupo.SelecionarTodos();
        
        CollectionAssert.AreEqual(gruposParaInserir, gruposSelecionados);
    }
}