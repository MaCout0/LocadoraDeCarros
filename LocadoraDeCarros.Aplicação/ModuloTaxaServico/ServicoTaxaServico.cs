using FluentResults;
using LocadoraDeCarros.Dominio.ModuloTaxaServico;
using LocadoraDeCarros.Dominio.PlanoCobranca;

namespace LocadoraDeCarros.Aplicação.ModuloTaxaServico;

public class ServicoTaxaServico
{
    private readonly IRepositorioTaxaServico repositorioTaxa;

    public ServicoTaxaServico(IRepositorioTaxaServico repositorioTaxa)
    {
        this.repositorioTaxa = repositorioTaxa;
    }

    public Result<TaxaServico> Inserir(TaxaServico taxa)
    {
        var errosValidacao = taxa.Validar();

        if (errosValidacao.Count > 0)
            return Result.Fail(errosValidacao);

        repositorioTaxa.Inserir(taxa);

        return Result.Ok(taxa);
    }

    public Result<TaxaServico> Editar(TaxaServico taxaAtualizada)
    {
        var taxa = repositorioTaxa.SelecionarPorId(taxaAtualizada.Id);

        if (taxa is null)
            return Result.Fail("A taxa não foi encontrada!");

        var errosValidacao = taxaAtualizada.Validar();

        if (errosValidacao.Count > 0)
            return Result.Fail(errosValidacao);

        taxa.Nome = taxaAtualizada.Nome;
        taxa.Valor = taxaAtualizada.Valor;
        taxa.TipoCobranca = taxaAtualizada.TipoCobranca;

        repositorioTaxa.Editar(taxa);

        return Result.Ok(taxa);
    }

    public Result<TaxaServico> Excluir(int taxaId)
    {
        var taxa = repositorioTaxa.SelecionarPorId(taxaId);

        if (taxa is null)
            return Result.Fail("A taxa não foi encontrada!");

        repositorioTaxa.Excluir(taxa);

        return Result.Ok(taxa);
    }

    public Result<TaxaServico> SelecionarPorId(int taxaId)
    {
        var taxa = repositorioTaxa.SelecionarPorId(taxaId);

        if (taxa is null)
            return Result.Fail("A taxa não foi encontrada!");

        return Result.Ok(taxa);
    }

    public Result<List<TaxaServico>> SelecionarTodos()
    {
        var taxas = repositorioTaxa.SelecionarTodos();

        return Result.Ok(taxas);
    }
}