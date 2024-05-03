using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Frozen;
using MauiCollectionViewOptimized.Models;
using MauiCollectionViewOptimized.Services.Interfaces;
using AsyncAwaitBestPractices;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Adapters;

namespace MauiCollectionViewOptimized.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        private IDispatcher _dispatcher;
        private IMainService _mainService;

        public MainPageViewModel(IDispatcher dispatcher, IMainService mainService)
        {
            _dispatcher = dispatcher;
            _mainService = mainService;

            InitializeAsync().SafeFireAndForget();
        }


        [ObservableProperty]
        private FrozenSet<Person> _people;

        [ObservableProperty]
        private bool _refreshing;

        [ObservableProperty]
        private ObservableCollectionAdapter<Person> _adapter;

        async Task InitializeAsync()
        {
            _adapter = new([]);
            await _dispatcher.DispatchAsync(async () =>
            {
                Refreshing = true;
                var data = await _mainService.GetPeopleAsync();
                People = data;
                _adapter = new([.. data]);
                Refreshing = false;
            }).ConfigureAwait(false);
        }

        [RelayCommand]
        async Task Refresh()
        {
            await InitializeAsync().ConfigureAwait(false);
        }
    }
}
