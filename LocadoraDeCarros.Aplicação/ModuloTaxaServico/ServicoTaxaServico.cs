using FluentResults;
using LocadoraDeCarros.Dominio.ModuloTaxaServico;
using LocadoraDeCarros.Dominio.PlanoCobranca;

namespace LocadoraDeCarros.Aplicação.ModuloTaxaServico;

public class ServicoTaxaServico
{
    private readonly IRepositorioTaxaServico repositorioTaxaServico;

    public ServicoTaxaServico(IRepositorioTaxaServico repositorioTaxaServico)
    {
        this.repositorioTaxaServico = repositorioTaxaServico;
    }

    public Result<TaxaServico> Inserir(TaxaServico taxaServico)
    {
        repositorioTaxaServico.Inserir(taxaServico);

        return Result.Ok(taxaServico);
    }

    public Result<TaxaServico> Editar(TaxaServico taxaServicoAtualizado)
    {
        var taxaServico = repositorioTaxaServico.SelecionarPorId(taxaServicoAtualizado.Id);

        if (taxaServico is null)
            return Result.Fail("O plano de cobrança não foi encontrado!");

        taxaServico.Nome = taxaServicoAtualizado.Nome;
        taxaServico.Descricao = taxaServicoAtualizado.Descricao;
        taxaServico.Valor = taxaServicoAtualizado.Valor;
        taxaServico.TipoDeCobranca = taxaServicoAtualizado.TipoDeCobranca;

        repositorioTaxaServico.Editar(taxaServico);

        return Result.Ok(taxaServico);
    }

    public Result<TaxaServico> Excluir(int taxaServicoId)
    {
        var taxaServico = repositorioTaxaServico.SelecionarPorId(taxaServicoId);

        if (taxaServico is null)
            return Result.Fail("O plano de cobrança não foi encontrado!");

        repositorioTaxaServico.Excluir(taxaServico);

        return Result.Ok(taxaServico);
    }

    public Result<TaxaServico> SelecionarPorId(int taxaServicoId)
    {
        var taxaServico = repositorioTaxaServico.SelecionarPorId(taxaServicoId);

        if (taxaServico is null)
            return Result.Fail("O plano de cobrança não foi encontrado!");

        return Result.Ok(taxaServico);
    }

    public Result<List<TaxaServico>> SelecionarTodos()
    {
        var taxaServicos = repositorioTaxaServico.SelecionarTodos();

        return Result.Ok(taxaServicos);
    }
}