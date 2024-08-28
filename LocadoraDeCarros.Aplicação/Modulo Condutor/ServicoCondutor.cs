using FluentResults;
using LocadoraDeCarros.Dominio.ModuloCondutor;
using LocadoraDeCarros.Dominio.ModuloCliente;

namespace LocadoraDeCarros.Aplicação.ModuloCondutor;

    public class ServicoCondutor
    {
        private readonly IRepositorioCondutor repositorioCondutor;

        public ServicoCondutor(IRepositorioCondutor repositorioCondutor)
        {
            this.repositorioCondutor = repositorioCondutor;
        }

        public Result<Condutor> Inserir(Condutor condutor)
        {
            repositorioCondutor.Inserir(condutor);
            
            return Result.Ok(condutor);
        }

        public Result<Condutor> Editar(Condutor condutorAtualizado)
        {
            var condutor = repositorioCondutor.SelecionarPorId(condutorAtualizado.Id);

            if (condutor is null)
                return Result.Fail("O condutor não foi encontrado!");

            condutor.Nome = condutorAtualizado.Nome;
            condutor.Email = condutorAtualizado.Email;
            condutor.CPF = condutorAtualizado.CPF;
            condutor.CNH = condutorAtualizado.CNH;
            condutor.ValidadeCNH = condutorAtualizado.ValidadeCNH;
            condutor.Telefone = condutorAtualizado.Telefone;

            repositorioCondutor.Editar(condutor);
            
            return Result.Ok(condutor);
        }

        public Result<Condutor> Excluir(int condutorId)
        {
            var condutor = repositorioCondutor.SelecionarPorId(condutorId);

            if (condutor is null)
                return Result.Fail("O condutor não foi encontrado!");

            repositorioCondutor.Excluir(condutor);
            
            return Result.Ok(condutor);
        }

        public Result<Condutor> SelecionarPorId(int condutorId)
        {
            var condutor = repositorioCondutor.SelecionarPorId(condutorId);

            if (condutor is null)
                return Result.Fail("O condutor não foi encontrado!");

            return Result.Ok(condutor);
        }

        public Result<List<Condutor>> SelecionarTodos()
        {
            var condutores = repositorioCondutor.SelecionarTodos();
            return Result.Ok(condutores);
        }
    }

