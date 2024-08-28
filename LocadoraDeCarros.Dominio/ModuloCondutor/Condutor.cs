using LocadoraDeCarros.Dominio.Compartilhado;

namespace LocadoraDeCarros.Dominio.ModuloCondutor
{
    public class Condutor : EntidadeBase
    {
        protected Condutor() { }

        public Condutor(string nome, string cpf, string cnh, DateTime validadeCNH, string telefone)
        {
            Nome = nome;
            CPF = cpf;
            CNH = cnh;
            ValidadeCNH = validadeCNH;
            Telefone = telefone;
        }

        public string Nome { get; set; }
        public string CPF { get; set; }
        public string CNH { get; set; }
        public DateTime ValidadeCNH { get; set; }
        public string Telefone { get; set; }

        public override List<string> Validar()
        {
            List<string> erros = new();

            if (string.IsNullOrEmpty(Nome))
                erros.Add("O nome é obrigatório");

            if (string.IsNullOrEmpty(CPF) || CPF.Length != 11)
                erros.Add("O CPF é obrigatório e deve conter 11 dígitos");

            if (string.IsNullOrEmpty(CNH))
                erros.Add("A CNH é obrigatória");

            if (ValidadeCNH <= DateTime.Now)
                erros.Add("A CNH deve estar válida");

            if (string.IsNullOrEmpty(Telefone))
                erros.Add("O telefone é obrigatório");

            return erros;
        }
    }
}