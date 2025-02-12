using DotNetEnv;
using JsonParser.Abstractions.Application.Interfaces;
using JsonParser.Application.Mappings;
using JsonParser.Application.Services;
using JsonParser.Persistence;
using JsonParser.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;

namespace JsonParserApp;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public static IServiceProvider ServiceProvider { get; private set; }

    public App()
    {
        Env.Load();

        var connectionString = "Data Source=objects.db";

        var services = new ServiceCollection();

        services.AddDbContext<ParseJsonDbContext>(options => options.UseSqlite(connectionString));

        services.AddScoped<IParseJsonDbContext>(provider => provider.GetRequiredService<ParseJsonDbContext>());

        services.AddSingleton<ISaveParseJsonService, SaveParseJsonService>();
        services.AddSingleton<IGetParseJsonService, GetParseJsonService>();

        services.AddSingleton<MainWindow>();

        services.AddAutoMapper(typeof(ConstructionObjectMappingProfile));

        services.AddSingleton<MainViewModel>();

        ServiceProvider = services.BuildServiceProvider();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
        mainWindow.Show();
    }
}
