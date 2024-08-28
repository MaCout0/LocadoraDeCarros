using LocadoraDeCarros.Dominio.ModuloCliente;
using FluentResults;

namespace LocadoraDeCarros.Aplicacao.Servicos;

public class ServicoCliente
{
    private readonly IRepositorioCliente repositorioCliente;

    public ServicoCliente(IRepositorioCliente repositorioCliente)
    {
        this.repositorioCliente = repositorioCliente;
    }

    public Result<Cliente> Inserir(Cliente cliente)
    {
        var erros = cliente.Validar();

        if (erros.Any())
            return Result.Fail(string.Join("; ", erros));

        repositorioCliente.Inserir(cliente);

        return Result.Ok(cliente);
    }

    public Result<Cliente> Editar(Cliente clienteAtualizado)
    {
        var cliente = repositorioCliente.SelecionarPorId(clienteAtualizado.Id);

        if (cliente is null)
            return Result.Fail("O cliente não foi encontrado");

        cliente.Nome = clienteAtualizado.Nome;
        cliente.CPF = clienteAtualizado.CPF;
        cliente.Endereco = clienteAtualizado.Endereco;
        cliente.Telefone = clienteAtualizado.Telefone;
        cliente.Email = clienteAtualizado.Email;
        
        var erros = cliente.Validar();

        if (erros.Any())
            return Result.Fail(string.Join("; ", erros));

        repositorioCliente.Editar(cliente);

        return Result.Ok(cliente);
    }

    public Result<Cliente> Excluir(int clienteId)
    {
        var cliente = repositorioCliente.SelecionarPorId(clienteId);

        if (cliente is null)
            return Result.Fail("O cliente não foi encontrado!");

        repositorioCliente.Excluir(cliente);

        return Result.Ok(cliente);
    }

    public Result<Cliente> SelecionarPorId(int clienteId)
    {
        var cliente = repositorioCliente.SelecionarPorId(clienteId);

        if (cliente is null)
            return Result.Fail("O cliente não foi encontrado!");

        return Result.Ok(cliente);
    }

    public Result<List<Cliente>> SelecionarTodos()
    {
        var clientes = repositorioCliente.SelecionarTodos();

        return Result.Ok(clientes);
    }
}
