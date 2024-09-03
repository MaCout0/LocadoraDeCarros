using AutoMapper;
using LocadoraDeCarros.Aplicação.ModuloTaxaServico;
using LocadoraDeCarros.Aplicação.Servicos;
using LocadoraDeCarros.Dominio.ModuloTaxaServico;
using LocadoraDeCarros.WebApp.Compartilhado;
using LocadoraDeCarros.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LocadoraDeCarros.WebApp.Controllers;

public class TaxaServicoController : WebControllerBase
{
    private readonly ServicoTaxaServico servico;
    private readonly IMapper mapeador;

    public TaxaServicoController(ServicoTaxaServico servico, IMapper mapeador)
    {
        this.servico = servico;
        this.mapeador = mapeador;
    }

    public IActionResult Listar()
    {
        var resultado = servico.SelecionarTodos();

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());

            return RedirectToAction("Index", "Home");
        }

        var taxas = resultado.Value;

        var listarTaxasVm = mapeador.Map<IEnumerable<ListarTaxaServicoViewModel>>(taxas);

        return View(listarTaxasVm);
    }

    public IActionResult Inserir()
    {
        return View(new InserirTaxaServicoViewModel());
    }

    [HttpPost]
    public IActionResult Inserir(InserirTaxaServicoViewModel inserirVm)
    {
        if (!ModelState.IsValid)
            return View(inserirVm);

        var taxa = mapeador.Map<TaxaServico>(inserirVm);

        var resultado = servico.Inserir(taxa);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());

            return RedirectToAction(nameof(Listar));
        }

        ApresentarMensagemSucesso($"O registro ID [{taxa.Id}] foi inserido com sucesso!");

        return RedirectToAction(nameof(Listar));
    }

    public IActionResult Editar(int id)
    {
        var resultado = servico.SelecionarPorId(id);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());

            return RedirectToAction(nameof(Listar));
        }

        var taxa = resultado.Value;

        var editarVm = mapeador.Map<EditarTaxaServicoViewModel>(taxa);

        return View(editarVm);
    }

    [HttpPost]
    public IActionResult Editar(EditarTaxaServicoViewModel editarVm)
    {
        if (!ModelState.IsValid)
            return View(editarVm);

        var taxa = mapeador.Map<TaxaServico>(editarVm);

        var resultado = servico.Editar(taxa);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());

            return RedirectToAction(nameof(Listar));
        }

        ApresentarMensagemSucesso($"O registro ID [{taxa.Id}] foi editado com sucesso!");

        return RedirectToAction(nameof(Listar));
    }

    public IActionResult Excluir(int id)
    {
        var resultado = servico.SelecionarPorId(id);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());

            return RedirectToAction(nameof(Listar));
        }

        var taxa = resultado.Value;

        var detalhesVm = mapeador.Map<DetalhesTaxaServicoViewModel>(taxa);

        return View(detalhesVm);
    }

    [HttpPost]
    public IActionResult Excluir(DetalhesTaxaServicoViewModel detalhesVm)
    {
        var resultado = servico.Excluir(detalhesVm.Id);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());

            return View(detalhesVm);
        }

        ApresentarMensagemSucesso($"O registro ID [{detalhesVm.Id}] foi excluído com sucesso!");

        return RedirectToAction(nameof(Listar));
    }

    public IActionResult Detalhes(int id)
    {
        var resultado = servico.SelecionarPorId(id);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());
            return RedirectToAction(nameof(Listar));
        }

        var taxa = resultado.Value;

        var detalhesVm = mapeador.Map<DetalhesTaxaServicoViewModel>(taxa);

        return View(detalhesVm);
    }
}