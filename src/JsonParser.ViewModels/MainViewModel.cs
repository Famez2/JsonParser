using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.IO;
using System.Windows;
using Microsoft.Win32;
using JsonParser.Abstractions.Application.Interfaces;
using JsonParser.Contracts;
using JsonParser.Infrastructure;

namespace JsonParser.ViewModels;

public class MainViewModel : INotifyPropertyChanged
{
    private readonly ISaveConstructionObjectService _saveParseJsonService;
    private readonly IGetConstructionObjectService _getParseJsonService;

    private string _selectedFilePath = string.Empty;
    public string SelectedFilePath
    {
        get => _selectedFilePath;
        set
        {
            _selectedFilePath = value;
            OnPropertyChanged();
        }
    }

    private ObservableCollection<GetConstructionObjectsDTO.ConstructionObjectInfoModel> _constructionObjects =
        new ObservableCollection<GetConstructionObjectsDTO.ConstructionObjectInfoModel>();
    public ObservableCollection<GetConstructionObjectsDTO.ConstructionObjectInfoModel> ConstructionObjects
    {
        get => _constructionObjects;
        set
        {
            _constructionObjects = value;
            OnPropertyChanged();
        }
    }

    public ICommand SelectJsonFileCommand { get; }
    public ICommand LoadJsonCommand { get; }

    public MainViewModel(
        ISaveConstructionObjectService saveParseJsonService,
        IGetConstructionObjectService getParseJsonService)
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

        // await _saveParseJsonService.SaveParsedJson(SelectedFilePath);

        var getConstructionDto = await _getParseJsonService.GetCompaniesAsync();

        // Очистка и заполнение коллекции
        ConstructionObjects.Clear();
        foreach (var obj in getConstructionDto.ConstructionObjects)
        {
            ConstructionObjects.Add(obj);
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
