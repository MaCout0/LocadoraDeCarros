using FizzWare.NBuilder;
using LocadoraDeCarros.Dominio.ModuloCliente;
using LocadoraDeCarros.Dominio.ModuloCondutor;
using LocadoraDeCarros.Dominio.ModuloGrupoDeAutomovel;
using LocadoraDeCarros.Dominio.ModuloTaxaServico;
using LocadoraDeCarros.Dominio.ModuoAutomovel;
using LocadoraDeCarros.Dominio.PlanoCobranca;
using LocadoraDeCarros.Infra.Orm.Compartilhado;
using LocadoraDeCarros.Infra.Orm.ModuloAutomovel;
using LocadoraDeCarros.Infra.Orm.ModuloCliente;
using LocadoraDeCarros.Infra.Orm.ModuloCondutor;
using LocadoraDeCarros.Infra.Orm.ModuloGrupoDeAutomovel;
using LocadoraDeCarros.Infra.Orm.ModuloPlanoCobranca;
using LocadoraDeCarros.Infra.Orm.ModuloTaxaServico;

namespace LocadoraDeCarros.Tests.Compartilhado;

public abstract class RepositorioEmOrmTestesBase
{
    protected LocadoraDbContext dbContext;
    protected RepositorioTaxaServicoEmOrm repositorioTaxa;
    protected RepositorioClienteEmOrm repositorioCliente;
    protected RepositorioCondutorEmOrm repositorioCondutor;
    protected RepositorioAutomovelEmOrm repositorioVeiculo;
    protected RepositorioGrupoDeAutomovelEmOrm repositorioGrupo;
    protected RepositorioPlanoCobrancaEmOrm repositorioPlano;

    [TestInitialize]
    public void Inicializar()
    {
        dbContext = new LocadoraDbContext();

        dbContext.TaxaServicos.RemoveRange(dbContext.TaxaServicos);
        dbContext.PlanosCobranca.RemoveRange(dbContext.PlanosCobranca);
        dbContext.Condutores.RemoveRange(dbContext.Condutores);
        dbContext.Clientes.RemoveRange(dbContext.Clientes);
        dbContext.Automoveis.RemoveRange(dbContext.Automoveis);
        dbContext.GrupoAutomoveis.RemoveRange(dbContext.GrupoAutomoveis);

        dbContext.SaveChanges();

        repositorioTaxa = new RepositorioTaxaServicoEmOrm(dbContext);
        repositorioPlano = new RepositorioPlanoCobrancaEmOrm(dbContext);
        repositorioCliente = new RepositorioClienteEmOrm(dbContext);
        repositorioCondutor = new RepositorioCondutorEmOrm(dbContext);
        repositorioVeiculo = new RepositorioAutomovelEmOrm(dbContext);
        repositorioGrupo = new RepositorioGrupoDeAutomovelEmOrm(dbContext);

        BuilderSetup.SetCreatePersistenceMethod<TaxaServico>(repositorioTaxa.Inserir);
        BuilderSetup.SetCreatePersistenceMethod<PlanoCobranca>(repositorioPlano.Inserir);
        BuilderSetup.SetCreatePersistenceMethod<Cliente>(repositorioCliente.Inserir);
        BuilderSetup.SetCreatePersistenceMethod<Condutor>(repositorioCondutor.Inserir);
        BuilderSetup.SetCreatePersistenceMethod<Automovel>(repositorioVeiculo.Inserir);
        BuilderSetup.SetCreatePersistenceMethod<GrupoDeAutomoveis>(repositorioGrupo.Inserir);
    }
}