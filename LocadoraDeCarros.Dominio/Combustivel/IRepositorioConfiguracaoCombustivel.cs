namespace LocadoraDeCarros.Dominio.Combustivel;

public interface IRepositorioConfiguracaoCombustivel
{
    void GravarConfiguracao(ConfiguracaoCombustivel configuracaoCombustivel);
    ConfiguracaoCombustivel? ObterConfiguracao();
}