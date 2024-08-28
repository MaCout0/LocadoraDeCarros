using LocadoraDeCarros.Dominio.ModuloCliente;
using LocadoraDeCarros.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraDeCarros.Infra.Orm.ModuloCliente;

public class RepositorioClienteEmOrm : RepositorioBaseEmOrm<Cliente>, IRepositorioCliente
{
    public RepositorioClienteEmOrm(LocadoraDbContext dbContext) : base(dbContext) { }

    protected override DbSet<Cliente> ObterRegistros()
    {
        return DbContext.Clientes;
    }
}