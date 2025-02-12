using JsonParser.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using System.Windows.Controls;

namespace JsonParserApp;

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

    private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
    {
        if (e.PropertyName == "Knotes" ||
            e.PropertyName == "MessageFormates" ||
            e.PropertyName == "References")
        {
            e.Cancel = true; 
        }
    }
}