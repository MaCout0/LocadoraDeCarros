using FizzWare.NBuilder;
using LocadoraDeCarros.Dominio.Combustivel;
using LocadoraDeCarros.Dominio.ModuloCliente;
using LocadoraDeCarros.Dominio.ModuloCondutor;
using LocadoraDeCarros.Dominio.ModuloGrupoDeAutomovel;
using LocadoraDeCarros.Dominio.ModuloLocacao;
using LocadoraDeCarros.Dominio.ModuloPlanoCobranca;
using LocadoraDeCarros.Dominio.ModuloTaxaServico;
using LocadoraDeCarros.Dominio.ModuoAutomovel;
using LocadoraDeCarros.Infra.Orm.Compartilhado;
using LocadoraDeCarros.Infra.Orm.ModuloAutomovel;
using LocadoraDeCarros.Infra.Orm.ModuloCliente;
using LocadoraDeCarros.Infra.Orm.ModuloCombustivel;
using LocadoraDeCarros.Infra.Orm.ModuloCondutor;
using LocadoraDeCarros.Infra.Orm.ModuloGrupoDeAutomovel;
using LocadoraDeCarros.Infra.Orm.ModuloLocacao;
using LocadoraDeCarros.Infra.Orm.ModuloPlanoCobranca;
using LocadoraDeCarros.Infra.Orm.ModuloTaxaServico;

namespace LocadoraDeCarros.Tests.Compartilhado;

public abstract class RepositorioEmOrmTestesBase
{
    protected LocadoraDbContext DbContext;

    protected RepositorioLocacaoEmOrm repositorioLocacao;
    protected RepositorioConfiguracaoCombustivelEmOrm repositorioCombustivel;
    protected RepositorioTaxaServicoEmOrm repositorioTaxa;
    protected RepositorioClienteEmOrm repositorioCliente;
    protected RepositorioCondutorEmOrm repositorioCondutor;
    protected RepositorioAutomovelEmOrm repositorioVeiculo;
    protected RepositorioGrupoDeAutomovelEmOrm repositorioGrupo;
    protected RepositorioPlanoCobrancaEmOrm repositorioPlano;

    [TestInitialize]
    public void Inicializar()
    {
        DbContext = new LocadoraDbContext();

        DbContext.Locacoes.RemoveRange(DbContext.Locacoes);
        DbContext.ConfiguracoesCombustiveis.RemoveRange(DbContext.ConfiguracoesCombustiveis);
        DbContext.TaxaServicos.RemoveRange(DbContext.TaxaServicos);
        DbContext.PlanosCobranca.RemoveRange(DbContext.PlanosCobranca);
        DbContext.Condutores.RemoveRange(DbContext.Condutores);
        DbContext.Clientes.RemoveRange(DbContext.Clientes);
        DbContext.Automoveis.RemoveRange(DbContext.Automoveis);
        DbContext.GrupoAutomoveis.RemoveRange(DbContext.GrupoAutomoveis);

        DbContext.SaveChanges();

        repositorioTaxa = new RepositorioTaxaServicoEmOrm(DbContext);
        repositorioPlano = new RepositorioPlanoCobrancaEmOrm(DbContext);
        repositorioCliente = new RepositorioClienteEmOrm(DbContext);
        repositorioCondutor = new RepositorioCondutorEmOrm(DbContext);
        repositorioVeiculo = new RepositorioAutomovelEmOrm(DbContext);
        repositorioGrupo = new RepositorioGrupoDeAutomovelEmOrm(DbContext);
        repositorioLocacao = new RepositorioLocacaoEmOrm(DbContext);
        repositorioCombustivel = new RepositorioConfiguracaoCombustivelEmOrm(DbContext);

        BuilderSetup.SetCreatePersistenceMethod<Locacao>(repositorioLocacao.Inserir);
        BuilderSetup.SetCreatePersistenceMethod<ConfiguracaoCombustivel>(repositorioCombustivel.GravarConfiguracao);
        BuilderSetup.SetCreatePersistenceMethod<TaxaServico>(repositorioTaxa.Inserir);
        BuilderSetup.SetCreatePersistenceMethod<PlanoCobranca>(repositorioPlano.Inserir);
        BuilderSetup.SetCreatePersistenceMethod<Condutor>(repositorioCondutor.Inserir);
        BuilderSetup.SetCreatePersistenceMethod<Cliente>(repositorioCliente.Inserir);
        BuilderSetup.SetCreatePersistenceMethod<Automovel>(repositorioVeiculo.Inserir);
        BuilderSetup.SetCreatePersistenceMethod<GrupoDeAutomoveis>(repositorioGrupo.Inserir);
    }
}