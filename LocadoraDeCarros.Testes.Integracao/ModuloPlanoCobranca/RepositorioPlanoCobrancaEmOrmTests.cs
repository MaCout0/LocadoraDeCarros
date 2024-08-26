using FizzWare.NBuilder;
using LocadoraDeCarros.Dominio.ModuloGrupoDeAutomovel;
using LocadoraDeCarros.Dominio.PlanoCobranca;
using LocadoraDeCarros.Infra.Orm.Compartilhado;
using LocadoraDeCarros.Infra.Orm.ModuloGrupoDeAutomovel;
using LocadoraDeCarros.Infra.Orm.ModuloPlanoCobranca;

namespace LocadoraDeCarros.Tests.ModuloPlanoCobranca;

[TestClass]
[TestCategory("Integração")]
public class RepositorioPlanoCobrancaEmOrmTests
{
    private LocadoraDbContext dbContext;
    private RepositorioPlanoCobrancaEmOrm repositorio;
    private RepositorioGrupoDeAutomovelEmOrm repositorioGrupos;

    [TestInitialize]
    public void Inicializar()
    {
        dbContext = new LocadoraDbContext();

        dbContext.PlanosCobranca.RemoveRange(dbContext.PlanosCobranca);
        dbContext.Automoveis.RemoveRange(dbContext.Automoveis);
        dbContext.GrupoAutomoveis.RemoveRange(dbContext.GrupoAutomoveis);

        repositorio = new RepositorioPlanoCobrancaEmOrm(dbContext);
        repositorioGrupos = new RepositorioGrupoDeAutomovelEmOrm(dbContext);

        BuilderSetup.SetCreatePersistenceMethod<PlanoCobranca>(repositorio.Inserir);
        BuilderSetup.SetCreatePersistenceMethod<GrupoDeAutomoveis>(repositorioGrupos.Inserir);
    }

    [TestMethod]
    public void Deve_Inserir_PlanoCobranca()
    {
        var grupo = Builder<GrupoDeAutomoveis>
            .CreateNew()
            .With(g => g.Id = 0)
            .Persist();

        var planoCobranca = Builder<PlanoCobranca>
            .CreateNew()
            .With(p => p.Id = 0)
            .With(p => p.GrupoAutomoveisId = grupo.Id)
            .Build();

        repositorio.Inserir(planoCobranca);

        var planoCobrancaSelecionado = repositorio.SelecionarPorId(planoCobranca.Id);

        Assert.IsNotNull(planoCobrancaSelecionado);
        Assert.AreEqual(planoCobranca, planoCobrancaSelecionado);
    }

    [TestMethod]
    public void Deve_Editar_PlanoCobranca()
    {
        var grupo = Builder<GrupoDeAutomoveis>
            .CreateNew()
            .With(g => g.Id = 0)
            .Persist();

        var planoCobranca = Builder<PlanoCobranca>
            .CreateNew()
            .With(p => p.Id = 0)
            .With(p => p.GrupoAutomoveisId = grupo.Id)
            .Persist();

        planoCobranca.PrecoDiarioPlanoDiario = 200.0m;

        repositorio.Editar(planoCobranca);

        var planoCobrancaSelecionado = repositorio.SelecionarPorId(planoCobranca.Id);

        Assert.IsNotNull(planoCobrancaSelecionado);
        Assert.AreEqual(planoCobranca, planoCobrancaSelecionado);
    }

    [TestMethod]
    public void Deve_Excluir_PlanoCobranca()
    {
        var grupo = Builder<GrupoDeAutomoveis>
            .CreateNew()
            .With(g => g.Id = 0)
            .Persist();

        var planoCobranca = Builder<PlanoCobranca>
            .CreateNew()
            .With(p => p.Id = 0)
            .With(p => p.GrupoAutomoveisId = grupo.Id)
            .Persist();

        repositorio.Excluir(planoCobranca);

        var planoCobrancaSelecionado = repositorio.SelecionarPorId(planoCobranca.Id);

        var planosCobranca = repositorio.SelecionarTodos();

        Assert.IsNull(planoCobrancaSelecionado);
        Assert.AreEqual(0, planosCobranca.Count);
    }
}