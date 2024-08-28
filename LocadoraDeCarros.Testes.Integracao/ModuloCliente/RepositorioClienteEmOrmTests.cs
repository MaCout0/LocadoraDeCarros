using LocadoraDeCarros.Dominio.ModuloCliente;
using LocadoraDeCarros.Infra.Orm.Compartilhado;
using LocadoraDeCarros.Infra.Orm.ModuloCliente;

namespace LocadoraDeCarros.Tests.ModuloCliente;

[TestClass]
public class RepositorioClienteEmOrmTests
{
    private LocadoraDbContext db;
    private RepositorioClienteEmOrm repositorio;

    [TestInitialize]
    public void ConfigurarTestes()
    {
        db = new LocadoraDbContext();

        db.Clientes.RemoveRange(db.Clientes);

        db.SaveChanges();

        repositorio = new RepositorioClienteEmOrm(db);
    }

    [TestMethod]
    public void Deve_Inserir_Cliente()
    {
        var novoCliente = new Cliente("João da Silva", "12345678900m", "Rua Exemplo, 123", "11999999999", "joao@gmail.co");

        repositorio.Inserir(novoCliente);

        var clienteEncontrado = repositorio.SelecionarPorId(novoCliente.Id);

        Assert.IsNotNull(clienteEncontrado);
        Assert.AreEqual(novoCliente, clienteEncontrado);
    }
    
    [TestMethod]
    public void Deve_Editar_Cliente()
    {
        var novoCliente = new Cliente("João da Silva", "123.456.789-00", "Rua Exemplo, 123", "11999999999", "joao@example.com");
        repositorio.Inserir(novoCliente);

        novoCliente.Nome = "João de Souza";
        novoCliente.Endereco = "Rua Nova, 456";
        
        repositorio.Editar(novoCliente);

        var clienteEncontrado = repositorio.SelecionarPorId(novoCliente.Id);
        
        Assert.IsNotNull(clienteEncontrado);
        Assert.AreEqual(novoCliente, clienteEncontrado);
    }

    [TestMethod]
    public void Deve_Excluir_Cliente()
    {
        var novoCliente = new Cliente("João da Silva", "123.456.789-00", "Rua Exemplo, 123", "11999999999", "joao@example.com");
        repositorio.Inserir(novoCliente);
        
        repositorio.Excluir(novoCliente);

        var clienteEncontrado = repositorio.SelecionarPorId(novoCliente.Id);
        
        Assert.IsNull(clienteEncontrado);
    }
}