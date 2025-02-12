using JsonParser.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace JsonParserApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly MainViewModel _viewModel;

    public MainWindow() : this(App.ServiceProvider.GetRequiredService<MainViewModel>())
    {
    }

    public MainWindow(MainViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        DataContext = _viewModel;
    }

    private void SelectJsonFile_Click(object sender, RoutedEventArgs e)
    {
        _viewModel.SelectJsonFile();
    }

    private void LoadJson_Click(object sender, RoutedEventArgs e)
    {
        _viewModel.LoadDataAsync();
    }
}