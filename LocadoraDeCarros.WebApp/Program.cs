using System.Reflection;
using LocadoraDeCarros.Aplicação.ModuloAutenticacao;
using LocadoraDeCarros.Aplicação.ModuloAutomovel;
using LocadoraDeCarros.Aplicação.ModuloCombustivel;
using LocadoraDeCarros.Aplicação.ModuloCondutor;
using LocadoraDeCarros.Aplicação.ModuloLocacao;
using LocadoraDeCarros.Aplicação.ModuloPlanoCobranca;
using LocadoraDeCarros.Aplicação.ModuloTaxaServico;
using LocadoraDeCarros.Aplicação.Servicos;
using LocadoraDeCarros.Aplicacao.Servicos;
using LocadoraDeCarros.Dominio.Combustivel;
using LocadoraDeCarros.Dominio.ModuloAutenticacao;
using LocadoraDeCarros.Dominio.ModuloCliente;
using LocadoraDeCarros.Dominio.ModuloCondutor;
using LocadoraDeCarros.Dominio.ModuloGrupoDeAutomovel;
using LocadoraDeCarros.Dominio.ModuloLocacao;
using LocadoraDeCarros.Dominio.ModuloTaxaServico;
using LocadoraDeCarros.Dominio.ModuoAutomovel;
using LocadoraDeCarros.Dominio.ModuloPlanoCobranca;
using LocadoraDeCarros.Infra.Orm.Compartilhado;
using LocadoraDeCarros.Infra.Orm.ModuloAutomovel;
using LocadoraDeCarros.Infra.Orm.ModuloCliente;
using LocadoraDeCarros.Infra.Orm.ModuloCombustivel;
using LocadoraDeCarros.Infra.Orm.ModuloCondutor;
using LocadoraDeCarros.Infra.Orm.ModuloGrupoDeAutomovel;
using LocadoraDeCarros.Infra.Orm.ModuloLocacao;
using LocadoraDeCarros.Infra.Orm.ModuloPlanoCobranca;
using LocadoraDeCarros.Infra.Orm.ModuloTaxaServico;
using LocadoraDeCarros.WebApp.Mapping.Resolvers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;

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
        builder.Services.AddScoped<IRepositorioCliente, RepositorioClienteEmOrm>();
        builder.Services.AddScoped<IRepositorioCondutor, RepositorioCondutorEmOrm>();
        builder.Services.AddScoped<IRepositorioConfiguracaoCombustivel, RepositorioConfiguracaoCombustivelEmOrm>();
        builder.Services.AddScoped<IRepositorioLocacao, RepositorioLocacaoEmOrm>();
        
        builder.Services.AddScoped<ServicoGrupoDeAutomoveis>();
        builder.Services.AddScoped<ServicoAutomovel>();
        builder.Services.AddScoped<ServicoPlanoCobranca>();
        builder.Services.AddScoped<ServicoTaxaServico>();
        builder.Services.AddScoped<ServicoCliente>();
        builder.Services.AddScoped<ServicoCondutor>();
        builder.Services.AddScoped<ServicoCombustivel>();
        builder.Services.AddScoped<ServicoLocacao>();

        builder.Services.AddScoped<FotoValueResolver>();
        builder.Services.AddScoped<GrupoAutomoveisValuesResolver>();
        builder.Services.AddScoped<TaxasSelecionadasValueResolver>();

        builder.Services.AddScoped<TaxasValueResolver>();
        builder.Services.AddScoped<CondutoresValueResolver>();
        builder.Services.AddScoped<AutomoveisValueResolver>();
        builder.Services.AddScoped<ValorParcialValueResolver>();
        builder.Services.AddScoped<ValorTotalValueResolver>();
        

        builder.Services.AddAutoMapper(cfg =>
        {
            cfg.AddMaps(Assembly.GetExecutingAssembly());
        });

        builder.Services.AddScoped<ServicoAutenticacao>();
        
        builder.Services.AddIdentity<Usuario, Perfil>()
            .AddEntityFrameworkStores<LocadoraDbContext>()
            .AddDefaultTokenProviders();

        builder.Services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequiredLength = 3;
            options.Password.RequiredUniqueChars = 1;
        });
        
        builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.Cookie.Name = "AspNetCore.Cookies";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
                options.SlidingExpiration = true;
            });

        builder.Services.ConfigureApplicationCookie(options =>
        {
            options.LoginPath = "/Autenticacao/Login";
            options.AccessDeniedPath = "/Autenticacao/AcessoNegado";
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