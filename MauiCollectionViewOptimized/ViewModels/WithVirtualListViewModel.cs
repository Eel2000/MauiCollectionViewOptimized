using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Adapters;
using MauiCollectionViewOptimized.Models;
using MauiCollectionViewOptimized.Services.Interfaces;
using AsyncAwaitBestPractices;

namespace MauiCollectionViewOptimized.ViewModels
{
    public partial class WithVirtualListViewModel : ObservableObject
    {
        private IDispatcher _dispatcher;
        private IMainService _mainService;

        [ObservableProperty]
        private bool _refreshing;

        [ObservableProperty]
        private ObservableCollectionAdapter<Person> _adapter;

        public WithVirtualListViewModel(IDispatcher dispatcher, IMainService mainService)
        {
            _dispatcher = dispatcher;
            _mainService = mainService;

            _adapter = new([]);
            InitializeAsync().SafeFireAndForget();

        }

        async Task InitializeAsync()
        {
            await _dispatcher.DispatchAsync(async () =>
            {
                Refreshing = true;
                var data = await _mainService.GetPeopleAsync();
                Adapter = new([.. data]);
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
