using LocadoraDeCarros.Dominio.Compartilhado;

namespace LocadoraDeCarros.Dominio.ModuloTaxaServico;

public interface IRepositorioTaxaServico : IRepositorio<TaxaServico>
{
    List<TaxaServico> SelecionarMuitos(List<int> idsTaxasSelecionadas);
}