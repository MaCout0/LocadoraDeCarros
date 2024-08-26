using LocadoraDeCarros.Dominio.ModuloGrupoDeAutomovel;

namespace LocadoraDeCarros.Testes.Integração.ModuloGrupoDeAutomoveis;

[TestClass]
[TestCategory("Unidade")]
public class GrupoAutomoveisTestes
{

    [TestMethod]
    public void Deve_Criar_Instancia_Valida()
    {
        var grupo = new GrupoDeAutomoveis("SUV");

        var erros = grupo.Validar();

        Assert.AreEqual(0, erros.Count);
    }

    [TestMethod]
    public void Deve_Criar_Instancia_Com_Erro()
    {
        var grupo = new GrupoDeAutomoveis("");

        var erros = grupo.Validar();

        List<string> errosEsperados = ["O nome é obrigatório"];

        Assert.AreEqual(1, erros.Count);
        CollectionAssert.AreEqual(errosEsperados, erros);
    }
}