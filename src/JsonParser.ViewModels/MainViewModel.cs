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
using Microsoft.EntityFrameworkCore;
using System;
using System.Text.Json;

namespace JsonParser.ViewModels;

public class MainViewModel : INotifyPropertyChanged
{
    private readonly ISaveConstructionObjectService _saveConstructionObjectService;
    private readonly IGetConstructionObjectService _getConstructionObjectsService;

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
    public ICommand ShowRecordsCommand { get; }  

    public MainViewModel(
        ISaveConstructionObjectService saveConstructionObjectService,
        IGetConstructionObjectService getConstructionObjectsService)
    {
        _saveConstructionObjectService = saveConstructionObjectService;
        _getConstructionObjectsService = getConstructionObjectsService;

        SelectJsonFileCommand = new RelayCommand(SelectJsonFile);
        LoadJsonCommand = new RelayCommand(LoadDataAsync);
        ShowRecordsCommand = new RelayCommand(ShowRecords);  
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

        try
        {
            await _saveConstructionObjectService.SaveConstructionObjectJson(SelectedFilePath);

            var getConstructionDto = await _getConstructionObjectsService.GetConstructionObjectAsync();

            ConstructionObjects.Clear();

            foreach (var obj in getConstructionDto.ConstructionObjects)
            {
                ConstructionObjects.Add(obj);
            }
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Ошибка парсинга JSON: {ex.Message}");
            MessageBox.Show($"Ошибка при обработке JSON: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
            MessageBox.Show($"Ошибка при чтении файла: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        catch (DbUpdateException ex)
        {
            Console.WriteLine($"Ошибка сохранения в базу данных: {ex.Message}");
            MessageBox.Show($"Ошибка сохранения в БД: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Неизвестная ошибка: {ex.Message}");
            MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    public async void ShowRecords()
    {
        ConstructionObjects.Clear();

        var getConstructionDto = await _getConstructionObjectsService.GetConstructionObjectAsync();

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
