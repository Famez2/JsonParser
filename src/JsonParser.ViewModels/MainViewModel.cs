using JsonParser.Abstractions.Application.Interfaces;
using JsonParser.Domain.Entity;
using JsonParser.Infrastructure;
using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace JsonParser.ViewModels;

public class MainViewModel
{
    private readonly ISaveParseJsonService _saveParseJsonService;
    private readonly IGetParseJsonService _getParseJsonService;
    public string SelectedFilePath { get; set; } = string.Empty;

    public ICommand SelectJsonFileCommand { get; }
    public ICommand LoadJsonCommand { get; }

    public MainViewModel(
        ISaveParseJsonService saveParseJsonService,
        IGetParseJsonService getParseJsonService)
    {
        _saveParseJsonService = saveParseJsonService;
        _getParseJsonService = getParseJsonService;

        SelectJsonFileCommand = new RelayCommand(SelectJsonFile);
        LoadJsonCommand = new RelayCommand(LoadDataAsync);
    }

    public void SelectJsonFile()
    {
        var openFileDialog = new OpenFileDialog
        {
            Filter = "JSON файлы (*.json)|*.json|Все файлы (*.*)|*.*",
            Title = "Выберите JSON-файл"
        };

        if (openFileDialog.ShowDialog() == true)
        {
            SelectedFilePath = openFileDialog.FileName;
        }
    }

    public async void LoadDataAsync()
    {
        if (string.IsNullOrWhiteSpace(SelectedFilePath) || !File.Exists(SelectedFilePath))
        {
            MessageBox.Show("Файл не выбран или не существует!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        await _saveParseJsonService.ParseJson(SelectedFilePath);
    }
}
