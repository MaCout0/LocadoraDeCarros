using LocadoraDeCarros.Dominio.PlanoCobranca;

namespace LocadoraDeCarros.Testes.Integração.ModuloPlanoCobranca;

[TestClass]
[TestCategory("Unidade")]
public class PlanoCobrancaTests
{
    [TestMethod]
    public void Deve_Criar_Instancia_Valida()
    {
        var planoCobranca = new PlanoCobranca
        (
            1,
            100.0m,
            1.0m,
            200.0m,
            80.0m,
            2.0m,
            150.0m
        );

        var erros = planoCobranca.Validar();

        Assert.AreEqual(0, erros.Count);
    }

    [TestMethod]
    public void Deve_Criar_Instancia_Com_Erro()
    {
        var planoCobranca = new PlanoCobranca
        (
            0,
            0.0m,
            0.0m,
            0.0m,
            0.0m,
            0.0m,
            0.0m
        );

        var erros = planoCobranca.Validar();

        List<string> errosEsperados =
        [
            "O grupo de veículos é obrigatório",
        ];

        Assert.AreEqual(errosEsperados.Count, erros.Count);
        CollectionAssert.AreEqual(errosEsperados, erros);
    }
}