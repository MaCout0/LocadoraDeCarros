using LocadoraDeCarros.Dominio.Compartilhado;
using LocadoraDeCarros.Dominio.ModuloCondutor;

namespace LocadoraDeCarros.Dominio.ModuloCliente;

public class Cliente : EntidadeBase
{
    public string Nome { get; set; }
    public string CPF { get; set; }
    public string Endereco { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }
    
    public List<Condutor> Condutores { get; set; } = [];

    protected Cliente() { }

    public Cliente(string nome, string cpf, string endereco, string telefone, string email)
    {
        Nome = nome;
        CPF = cpf;
        Endereco = endereco;
        Telefone = telefone;
        Email = email;
    }

    public override List<string> Validar()
    {
        List<string> erros = new();

        if (string.IsNullOrEmpty(Nome))
            erros.Add("O nome é obrigatório");

        if (string.IsNullOrEmpty(CPF) || CPF.Length != 11)
            erros.Add("O CPF é obrigatório e deve conter 11 dígitos");

        if (string.IsNullOrEmpty(Endereco))
            erros.Add("O endereço é obrigatório");

        if (string.IsNullOrEmpty(Telefone))
            erros.Add("O telefone é obrigatório");

        if (string.IsNullOrEmpty(Email))
            erros.Add("O email é obrigatório");

        return erros;
    }
}