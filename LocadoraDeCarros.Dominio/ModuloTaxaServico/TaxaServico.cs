using LocadoraDeCarros.Dominio.Compartilhado;

namespace LocadoraDeCarros.Dominio.ModuloTaxaServico;

public class TaxaServico : EntidadeBase
{
    public TaxaServico() {}
    
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public decimal Valor { get; set; }
    public TipoDeCobranca TipoDeCobranca { get; set; }

    public TaxaServico(string nome, string descricao, decimal valor, TipoDeCobranca tipoDeCobranca)
    {
        Nome = nome;
        Descricao = descricao;
        Valor = valor;
        TipoDeCobranca = tipoDeCobranca;
    }

    public override List<string> Validar()
    {
        List<string> erros = new List<string>();

        if (string.IsNullOrEmpty(Nome))
            erros.Add("O nome é obrigatório");

        if (string.IsNullOrEmpty(Descricao))
            erros.Add("A descrição é obrigatória");

        if (Valor <= 0)
            erros.Add("O valor deve ser maior que zero");

        if (TipoDeCobranca == null)
            erros.Add("O tipo de cobrança é obrigatório");

        return erros;
    }
}