using LocadoraDeCarros.Dominio.ModuloCliente;

namespace LocadoraDeCarros.Testes.Integração.ModuloCliente;

[TestClass]
[TestCategory("Unidade")]
public class ClienteTests
{
    [TestMethod]
    public void Deve_Criar_Instancia_Valida()
    {
        var cliente = new Cliente
        (
            "João Silva",
            "12345678901",
            "Rua A, 123",
            "11999999999",
            "joao.silva@example.com"
        );

        var erros = cliente.Validar();

        Assert.AreEqual(0, erros.Count);
    }

    [TestMethod]
    public void Deve_Criar_Instancia_Com_Erros()
    {
        var cliente = new Cliente
        (
            "",
            "12345678",
            "",
            "",
            ""
        );

        var erros = cliente.Validar();

        List<string> errosEsperados = new List<string>
        {
            "O nome é obrigatório",
            "O CPF é obrigatório e deve conter 11 dígitos",
            "O endereço é obrigatório",
            "O telefone é obrigatório",
            "O email é obrigatório"
        };

        Assert.AreEqual(errosEsperados.Count, erros.Count);
        CollectionAssert.AreEqual(errosEsperados, erros);
    }
}