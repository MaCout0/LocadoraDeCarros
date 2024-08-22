using System.Reflection;
using LocadoraDeCarros.Aplicação.Servicos;
using LocadoraDeCarros.Dominio.ModuloGrupoDeAutomovel;
using LocadoraDeCarros.Infra.Orm.Compartilhado;
using LocadoraDeCarros.Infra.Orm.ModuloGrupoDeAutomovel;

namespace LocadoraDeCarros.WebApp;
    
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<LocadoraDbContext>();

        builder.Services.AddScoped<IRepositorioGrupoDeAutomovel, RepositorioGrupoDeAutomovelEmOrm>();
        builder.Services.AddScoped<ServicoGrupoDeAutomoveis>();

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