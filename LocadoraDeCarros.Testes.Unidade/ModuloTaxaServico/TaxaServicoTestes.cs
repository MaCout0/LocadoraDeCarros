using LocadoraDeCarros.Dominio.ModuloTaxaServico;

namespace LocadoraDeCarros.Testes.Integração.ModuloTaxaServico;

[TestClass]
[TestCategory("Unidade")]
public class TaxaServicoTestes
{
    [TestMethod]
    public void Deve_Criar_Instancia_Valida()
    {
        var taxaServico = new TaxaServico
        (
            "Taxa de Limpeza",
            "Cobrança pela limpeza do veículo",
            50.00m,
            TipoDeCobranca.Fixo
        );

        var erros = taxaServico.Validar();

        Assert.AreEqual(0, erros.Count);
    }

    [TestMethod]
    public void Deve_Criar_Instancia_Com_Erro()
    {
        var taxaServico = new TaxaServico
        (
            "",
            "",
            0,
            TipoDeCobranca.Fixo
        );

        var erros = taxaServico.Validar();

        List<string> errosEsperados = new List<string>
        {
            "O nome é obrigatório",
            "A descrição é obrigatória",
            "O valor deve ser maior que zero"
        };

        Assert.AreEqual(errosEsperados.Count, erros.Count);
        CollectionAssert.AreEqual(errosEsperados, erros);
    }
}