using AutoMapper;
using LocadoraDeCarros.Aplicação.ModuloCombustivel;
using LocadoraDeCarros.Dominio.Combustivel;
using LocadoraDeCarros.WebApp.Compartilhado;
using LocadoraDeCarros.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraDeCarros.WebApp.Controllers;

public class CombustivelController : WebControllerBase
{
    private readonly ServicoCombustivel servicoCombustivel;
    private readonly IMapper mapeador;

    public CombustivelController(ServicoCombustivel servicoCombustivel, IMapper mapeador)
    {
        this.servicoCombustivel = servicoCombustivel;
        this.mapeador = mapeador;
    }

    public IActionResult Configurar()
    {
        var resultado = servicoCombustivel.ObterConfiguracao();

        if (resultado.IsFailed)
            return RedirectToAction("Index", "Home");

        var configuracaoCombustivel = resultado.Value;

        var formularioVm = mapeador.Map<FormularioConfiguracaoCombustivelViewModel>(configuracaoCombustivel);

        return View(formularioVm);
    }

    [HttpPost]
    public IActionResult Configurar(FormularioConfiguracaoCombustivelViewModel formularioVm)
    {
        var config = mapeador.Map<ConfiguracaoCombustivel>(formularioVm);

        var resultado = servicoCombustivel.SalvarConfiguracao(config);

        if (resultado.IsFailed)
            return RedirectToAction("Index", "Home");

        ApresentarMensagemSucesso("A configuração foi salva com sucesso!");

        return RedirectToAction("Index", "Home");
    }
}