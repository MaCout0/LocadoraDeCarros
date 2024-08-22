using LocadoraDeCarros.Dominio.Compartilhado;
using LocadoraDeCarros.Dominio.ModuloGrupoDeAutomovel;

namespace LocadoraDeCarros.Dominio.ModuoAutomovel;

public class Automovel : EntidadeBase
{
    protected Automovel() { }
    public string Modelo { get; set; }
    public string Placa { get; set; }
    public string Marca { get; set; }
    public string Cor { get; set; }
    public string TipoCombustivel { get; set; }
    public int Ano { get; set; }
    public GrupoDeAutomoveis Grupo { get; set; }
    public string Foto { get; set; }
    
    
    public Automovel(string modelo, string placa, string marca, string cor, string tipoCombustivel, int ano, GrupoDeAutomoveis grupo, string foto)
    {
        Modelo = modelo;
        Placa = placa;
        Marca = marca;
        Cor = cor;
        TipoCombustivel = tipoCombustivel;
        Ano = ano;
        Grupo = grupo;
        Foto = foto;
    }
    
    public override List<string> Validar()
    {
        List<string> erros = new System.Collections.Generic.List<string>();

        if (string.IsNullOrWhiteSpace(Placa))
            erros.Add("A placa é obrigatória.");

        if (Placa.Length < 7)
            erros.Add("A placa deve ter pelo menos 7 caracteres.");

        if (string.IsNullOrWhiteSpace(Marca))
            erros.Add("A marca é obrigatória.");

        if (string.IsNullOrWhiteSpace(Modelo))
            erros.Add("O modelo é obrigatório.");

        if (string.IsNullOrWhiteSpace(Cor))
            erros.Add("A cor é obrigatória.");

        if (Ano < 2001 || Ano > DateTime.Now.Year) 
            erros.Add("O ano do automóvel é inválido.");

        if (string.IsNullOrWhiteSpace(TipoCombustivel))
            erros.Add("O tipo de combustível é obrigatório.");
        

        if (Grupo == null)
            erros.Add("O grupo de automóveis é obrigatório.");

        return erros;
    }
}