using AutoMapper;
using LocadoraDeCarros.Aplicação.Servicos;
using LocadoraDeCarros.Dominio.ModuloGrupoDeAutomovel;
using LocadoraDeCarros.WebApp.Compartilhado;
using LocadoraDeCarros.WebApp.Extensions;
using LocadoraDeCarros.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraDeCarros.WebApp.Controller;

public class GrupoAutomovelController : WebControllerBase
{
    private readonly ServicoGrupoDeAutomoveis servico;
    private readonly IMapper mapeador;

    public GrupoAutomovelController(ServicoGrupoDeAutomoveis servico, IMapper mapeador)
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

        var grupos = resultado.Value;

        var listarGruposVM = mapeador.Map<IEnumerable<ListarGrupoAutomovelViewModel>>(grupos);
        
        return View(listarGruposVM);
    }
    
    public IActionResult Inserir()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Inserir(InserirGrupoAutomovelViewModel inserirVm)
    {
        if (!ModelState.IsValid)
            return View(inserirVm);

        var grupo = mapeador.Map<GrupoDeAutomoveis>(inserirVm);

        var resultado = servico.Inserir(grupo);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());

            return RedirectToAction(nameof(Listar));
        }

        ApresentarMensagemSucesso($"O registro ID [{grupo.Id}] foi inserido com sucesso!");

        return RedirectToAction(nameof(Listar));
    }

    public IActionResult Editar(int id)
    {
        var resultado = servico.SeleCionarPorId(id);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());

            return RedirectToAction(nameof(Listar));
        }

        var grupo = resultado.Value;

        var editarVm = mapeador.Map<EditarGrupoAutomovelViewModel>(grupo);

        return View(editarVm);
    }

    [HttpPost]
    public IActionResult Editar(EditarGrupoAutomovelViewModel editarVM)
    {
        if (!ModelState.IsValid)
            return View(editarVM);

        var grupo = mapeador.Map<GrupoDeAutomoveis>(editarVM);

        var resultado = servico.Editar(grupo);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());

            return RedirectToAction(nameof(Listar));
        }

        ApresentarMensagemSucesso($"O registro ID [{grupo.Id}] foi editado com sucesso!");

        return RedirectToAction(nameof(Listar));
    }

    public IActionResult Excluir(int id)
    {
        var resultado = servico.SeleCionarPorId(id);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());

            return RedirectToAction(nameof(Listar));
        }

        var grupo = resultado.Value;

        var detalhesVm = mapeador.Map<DetalhesGrupoAutomovelViewModel>(grupo);

        return View(detalhesVm);
    }

    [HttpPost]
    public IActionResult Excluir(DetalhesGrupoAutomovelViewModel detalhesVm)
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
        var resultado = servico.SeleCionarPorId(id);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());

            return RedirectToAction(nameof(Listar));
        }

        var grupo = resultado.Value;

        var detalhesVm = mapeador.Map<DetalhesGrupoAutomovelViewModel>(grupo);

        return View(detalhesVm);
    }
}