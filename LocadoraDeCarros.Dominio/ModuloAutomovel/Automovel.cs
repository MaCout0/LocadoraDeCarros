using LocadoraDeCarros.Dominio.Compartilhado;
using LocadoraDeCarros.Dominio.ModuloGrupoDeAutomovel;

namespace LocadoraDeCarros.Dominio.ModuoAutomovel;

public class Automovel : EntidadeBase
{
    protected Automovel() { }
    
    public string Modelo { get; set; }
    public string Marca { get; set; }
    public TipoCombustivel TipoCombustivel { get; set; }
    public int CapacidadeTanque { get; set; }
    public byte[] Foto { get; set; }
    public int GrupoDeAutomoveisId { get; set; }
    public GrupoDeAutomoveis? GrupoAutomoveis { get; set; }
    
    
    public Automovel(string modelo, string marca, TipoCombustivel tipoCombustivel, int capacidadeTanque, int grupoDeAutomoveisId)
    {
        Modelo = modelo;
        Marca = marca;
        TipoCombustivel = tipoCombustivel;
        CapacidadeTanque = capacidadeTanque;
        GrupoDeAutomoveisId = grupoDeAutomoveisId;
    }
    
    public override List<string> Validar()
    {
        List<string> erros = [];

        if (string.IsNullOrEmpty(Modelo))
            erros.Add("O modelo é obrigatório");

        if (string.IsNullOrEmpty(Marca))
            erros.Add("A marca é obrigatória");

        if (CapacidadeTanque == 0)
            erros.Add("A capacidade do tanque precisa ser informada");

        if (GrupoDeAutomoveisId == 0)
            erros.Add("O grupo de automóveis é obrigatório");

        return erros;
    }
}