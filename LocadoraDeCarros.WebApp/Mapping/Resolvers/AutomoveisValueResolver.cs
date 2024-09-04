using AutoMapper;
using LocadoraDeCarros.Aplicação.ModuloAutomovel;
using LocadoraDeCarros.Dominio.ModuloLocacao;
using LocadoraDeCarros.WebApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LocadoraDeCarros.WebApp.Mapping.Resolvers;

public class AutomoveisValueResolver : IValueResolver<Locacao, FormularioLocacaoViewModel, IEnumerable<SelectListItem>?>
{
    private readonly ServicoAutomovel _servicoVeiculo;

    public AutomoveisValueResolver(ServicoAutomovel servicoVeiculo)
    {
        _servicoVeiculo = servicoVeiculo;
    }

    public IEnumerable<SelectListItem>? Resolve(Locacao source, FormularioLocacaoViewModel destination, IEnumerable<SelectListItem>? destMember,
        ResolutionContext context)
    {
        if (destination is RealizarDevolucaoViewModel or ConfirmarAberturaLocacaoViewModel or ConfirmarDevolucaoLocacaoViewModel)
        {
            var veiculoSelecionado = _servicoVeiculo.SelecionarPorId(source.AutomovelId).Value;

            return [new SelectListItem(veiculoSelecionado!.Modelo, veiculoSelecionado.Id.ToString())];
        }

        return _servicoVeiculo
            .SelecionarTodos()
            .Value
            .Select(v => new SelectListItem(v.Modelo, v.Id.ToString()));
    }
}