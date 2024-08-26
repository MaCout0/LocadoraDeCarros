using System.Reflection;
using LocadoraDeCarros.Aplicação.ModuloAutomovel;
using LocadoraDeCarros.Aplicação.ModuloPlanoCobranca;
using LocadoraDeCarros.Aplicação.ModuloTaxaServico;
using LocadoraDeCarros.Aplicação.Servicos;
using LocadoraDeCarros.Dominio.ModuloGrupoDeAutomovel;
using LocadoraDeCarros.Dominio.ModuloTaxaServico;
using LocadoraDeCarros.Dominio.ModuoAutomovel;
using LocadoraDeCarros.Dominio.PlanoCobranca;
using LocadoraDeCarros.Infra.Orm.Compartilhado;
using LocadoraDeCarros.Infra.Orm.ModuloAutomovel;
using LocadoraDeCarros.Infra.Orm.ModuloGrupoDeAutomovel;
using LocadoraDeCarros.Infra.Orm.ModuloPlanoCobranca;
using LocadoraDeCarros.Infra.Orm.ModuloTaxaServico;

namespace LocadoraDeCarros.WebApp;
    
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<LocadoraDbContext>();

        builder.Services.AddScoped<IRepositorioGrupoDeAutomovel, RepositorioGrupoDeAutomovelEmOrm>();
        builder.Services.AddScoped<IRepositorioAutomovel, RepositorioAutomovelEmOrm>();
        builder.Services.AddScoped<IRepositorioPlanoCobranca, RepositorioPlanoCobrancaEmOrm>();
        builder.Services.AddScoped<IRepositorioTaxaServico, RepositorioTaxaServicoEmOrm>();
        
        builder.Services.AddScoped<ServicoGrupoDeAutomoveis>();
        builder.Services.AddScoped<ServicoAutomovel>();
        builder.Services.AddScoped<ServicoPlanoCobranca>();
        builder.Services.AddScoped<ServicoTaxaServico>();

        builder.Services.AddAutoMapper(cfg =>
        {
            cfg.AddMaps(Assembly.GetExecutingAssembly());
        });

        builder.Services.AddControllersWithViews();

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}