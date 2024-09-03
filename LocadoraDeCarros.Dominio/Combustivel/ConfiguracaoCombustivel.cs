using LocadoraDeCarros.Dominio.ModuoAutomovel;

namespace LocadoraDeCarros.Dominio.Combustivel;

public class ConfiguracaoCombustivel
{
    public int Id { get; set; }
    public DateTime DataCriacao { get; set; }

    public decimal ValorGasolina { get; set; }
    public decimal ValorGas { get; set; }
    public decimal ValorDiesel { get; set; }
    public decimal ValorAlcool { get; set; }

    protected ConfiguracaoCombustivel() { }

    public ConfiguracaoCombustivel(
        decimal valorGasolina,
        decimal valorGas,
        decimal valorDiesel,
        decimal valorAlcool
    ) : this()
    {
        ValorGasolina = valorGasolina;
        ValorGas = valorGas;
        ValorDiesel = valorDiesel;
        ValorAlcool = valorAlcool;
    }

    public decimal ObterValorCombustivel(TipoCombustivel tipoCombustivel)
    {
        return tipoCombustivel switch
        {
            TipoCombustivel.Alcool => ValorAlcool,
            TipoCombustivel.Diesel => ValorDiesel,
            TipoCombustivel.Gas => ValorGas,
            _ => ValorGasolina
        };
    }
}