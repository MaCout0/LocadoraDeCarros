using LocadoraDeCarros.Dominio.ModuloGrupoDeAutomovel;
using FluentResults;

namespace LocadoraDeCarros.Aplicação.Servicos;

public class GrupoDeAutomoveisService
{
    private readonly IRepositorioGrupoDeAutomovel repositorioGrupo;

    public GrupoDeAutomoveisService(IRepositorioGrupoDeAutomovel repositorioGrupo)
    {
        this.repositorioGrupo = this.repositorioGrupo;
    }

    public Result<GrupoDeAutomoveis> Inserir(GrupoDeAutomoveis grupoDeAutomoveis)
    {
        repositorioGrupo.Inserir(grupoDeAutomoveis);

        return Result.Ok(grupoDeAutomoveis);
    }

    public Result<GrupoDeAutomoveis> Editar(GrupoDeAutomoveis grupoAtualizado)
    {
        var grupo = repositorioGrupo.SelecionarPorId(grupoAtualizado.Id);

        if (grupo is null)
            return Result.Fail("O grupo não foi encontrado");

        grupo.Nome = grupoAtualizado.Nome;
        
        repositorioGrupo.Editar(grupo);

        return Result.Ok(grupo);
    }

    public Result Excluir(int grupoId)
    {
        var grupo = repositorioGrupo.SelecionarPorId(grupoId);

        if (grupo is null)
            return Result.Fail("O grupo não foi Encontrado!");
        
        repositorioGrupo.Excluir(grupo);

        return Result.Ok();
    }

    public Result<GrupoDeAutomoveis> SeleCionarPorId(int grupoId)
    {
        var grupo = repositorioGrupo.SelecionarPorId(grupoId);

        if (grupo is null)
            return Result.Fail("O grupo não foi Encontrado!");
        
        return Result.Ok(grupo);
    }

    public Result<List<GrupoDeAutomoveis>> SelecionarTodos(int usuarioId)
    {
        //var grupos = repositorioGrupo
        //    .Filtrar(f => f.Nome == usuarioId);
        return Result.Ok();
    }

}