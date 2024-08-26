using FizzWare.NBuilder;
using LocadoraDeCarros.Dominio.ModuloGrupoDeAutomovel;
using LocadoraDeCarros.Dominio.ModuoAutomovel;
using LocadoraDeCarros.Infra.Orm.Compartilhado;
using LocadoraDeCarros.Infra.Orm.ModuloAutomovel;
using LocadoraDeCarros.Infra.Orm.ModuloGrupoDeAutomovel;

namespace LocadoraDeCarros.Testes.Integracao.ModuloAutomovel;

[TestClass]
[TestCategory("Integração")]
public class RepositorioAutomovelEmOrmTests
{
    private LocadoraDbContext dbContext;
    private RepositorioAutomovelEmOrm repositorio;
    private RepositorioGrupoDeAutomovelEmOrm repositorioGrupos;

    [TestInitialize]
    public void Inicializar()
    {
        dbContext = new LocadoraDbContext();

        dbContext.Automoveis.RemoveRange(dbContext.Automoveis);
        dbContext.GrupoAutomoveis.RemoveRange(dbContext.GrupoAutomoveis);

        repositorio = new RepositorioAutomovelEmOrm(dbContext);
        repositorioGrupos = new RepositorioGrupoDeAutomovelEmOrm(dbContext);

        BuilderSetup.SetCreatePersistenceMethod<Automovel>(repositorio.Inserir);
        BuilderSetup.SetCreatePersistenceMethod<GrupoDeAutomoveis>(repositorioGrupos.Inserir);
    }

    [TestMethod]
    public void Deve_Inserir_Automovel()
    {
        var grupo = Builder<GrupoDeAutomoveis>
            .CreateNew()
            .With(g => g.Id = 0)
            .Persist();

        var automovel = Builder<Automovel>
            .CreateNew()
            .With(v => v.Id = 0)
            .With(v => v.GrupoDeAutomoveisId = grupo.Id)
            .Persist();

        var automovelSelecionado = repositorio.SelecionarPorId(automovel.Id);

        Assert.IsNotNull(automovelSelecionado);
        Assert.AreEqual(automovel, automovelSelecionado);
    }

    [TestMethod]
    public void Deve_Editar_Automovel()
    {
        var grupo = Builder<GrupoDeAutomoveis>
            .CreateNew()
            .With(g => g.Id = 0)
            .Persist();

        var automovel = Builder<Automovel>
            .CreateNew()
            .With(v => v.Id = 0)
            .With(v => v.GrupoDeAutomoveisId = grupo.Id)
            .Persist();

        automovel.Modelo = "Novo Modelo";

        repositorio.Editar(automovel);

        var automovelSelecionado = repositorio.SelecionarPorId(automovel.Id);

        Assert.IsNotNull(automovelSelecionado);
        Assert.AreEqual(automovel, automovelSelecionado);
    }

    [TestMethod]
    public void Deve_Excluir_Automovel()
    {
        var grupo = Builder<GrupoDeAutomoveis>
            .CreateNew()
            .With(g => g.Id = 0)
            .Persist();

        var automovel = Builder<Automovel>
            .CreateNew()
            .With(v => v.Id = 0)
            .With(v => v.GrupoDeAutomoveisId = grupo.Id)
            .Persist();

        repositorio.Excluir(automovel);

        var automovelSelecionado = repositorio.SelecionarPorId(automovel.Id);

        var automoveis = repositorio.SelecionarTodos();

        Assert.IsNull(automovelSelecionado);
        Assert.AreEqual(0, automoveis.Count);
    }
}