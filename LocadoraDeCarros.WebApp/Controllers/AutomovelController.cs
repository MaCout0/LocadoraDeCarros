using AutoMapper;
using LocadoraDeCarros.Aplicação.ModuloAutomovel;
using LocadoraDeCarros.Aplicação.Servicos;
using LocadoraDeCarros.Dominio.ModuoAutomovel;
using LocadoraDeCarros.WebApp.Compartilhado;
using LocadoraDeCarros.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LocadoraDeCarros.WebApp.Controllers;

public class AutomovelController : WebControllerBase
{
    private readonly ServicoAutomovel servico;
    private readonly ServicoGrupoDeAutomoveis servicoGrupos;
    private readonly IMapper mapeador;
    
    public AutomovelController(ServicoAutomovel servico, ServicoGrupoDeAutomoveis servicoGrupos, IMapper mapeador)
    {
        this.servico = servico;
        this.servicoGrupos = servicoGrupos;
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

        var automoveis = resultado.Value;

        var listarAutomoveisVm = mapeador.Map<IEnumerable<ListarAutomovelViewModel>>(automoveis);

        return View(listarAutomoveisVm);
    }
    
    public IActionResult Inserir()
    {
        return View(CarregarDadosFormulario());
    }

    [HttpPost]
    public IActionResult Inserir(InserirAutomovelViewModel inserirVm)
    {
        if (!ModelState.IsValid)
            return View(CarregarDadosFormulario(inserirVm));

        var automovel = mapeador.Map<Automovel>(inserirVm);

        var resultado = servico.Inserir(automovel);


        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());

            return RedirectToAction(nameof(Listar));
        }

        ApresentarMensagemSucesso($"O registro ID [{automovel.Id}] foi inserido com sucesso!");

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

        var resultadoGrupos = servicoGrupos.SelecionarTodos();

        if (resultadoGrupos.IsFailed)
        {
            ApresentarMensagemFalha(resultadoGrupos.ToResult());

            return null;
        }

        var automovel = resultado.Value;

        var editarVm = mapeador.Map<EditarAutomovelViewModel>(automovel);

        var gruposDisponiveis = resultadoGrupos.Value;

        editarVm.GruposAutomoveis = gruposDisponiveis
            .Select(g => new SelectListItem(g.Nome, g.Id.ToString()));

        return View(editarVm);
    }

    [HttpPost]
    public IActionResult Editar(EditarAutomovelViewModel editarVm)
    {
        if (!ModelState.IsValid)
            return View(CarregarDadosFormulario(editarVm));

        var automovelAtualizado = mapeador.Map<Automovel>(editarVm);

        var resultado = servico.Editar(automovelAtualizado);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());

            return RedirectToAction(nameof(Listar));
        }

        ApresentarMensagemSucesso($"O registro ID [{automovelAtualizado.Id}] foi editado com sucesso!");

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

        var automovel = resultado.Value;

        var detalhesVm = mapeador.Map<DetalhesAutomovelViewModel>(automovel);

        return View(detalhesVm);
    }

    [HttpPost]
    public IActionResult Excluir(DetalhesAutomovelViewModel detalhesVm)
    {
        var resultado = servico.Excluir(detalhesVm.Id);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());

            return RedirectToAction(nameof(Listar));
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

        var automovel = resultado.Value;

        var detalhesVm = mapeador.Map<DetalhesAutomovelViewModel>(automovel);

        return View(detalhesVm);
    }

    private FormularioAutomovelViewModel? CarregarDadosFormulario(
        FormularioAutomovelViewModel? dadosPrevios = null)
    {
        var resultadoGrupos = servicoGrupos.SelecionarTodos();

        if (resultadoGrupos.IsFailed)
        {
            ApresentarMensagemFalha(resultadoGrupos.ToResult());

            return null;
        }

        var gruposDisponiveis = resultadoGrupos.Value;

        if (dadosPrevios is null)
        {
            var formularioVm = new FormularioAutomovelViewModel
            {
                GruposAutomoveis = gruposDisponiveis
                    .Select(g => new SelectListItem(g.Nome, g.Id.ToString()))
            };

            return formularioVm;
        }

        dadosPrevios.GruposAutomoveis = gruposDisponiveis
            .Select(g => new SelectListItem(g.Nome, g.Id.ToString()));

        return dadosPrevios;
    }
}