using DotNetEnv;
using JsonParser.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Data;
using System.Windows;

namespace JsonParserApp;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public App()
    {
        Env.Load();

        var connectionString = Env.GetString("DATABASE_CONNECTION");

        var optionsBuilder = new DbContextOptionsBuilder<ParseJsonDbContext>();
        optionsBuilder.UseSqlite(connectionString);


        InitializeComponent();
    }
}

