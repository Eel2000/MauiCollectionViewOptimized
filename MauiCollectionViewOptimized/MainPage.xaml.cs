using MauiCollectionViewOptimized.ViewModels;

namespace MauiCollectionViewOptimized
{
    public partial class MainPage : ContentPage
    {

        public MainPage(MainPageViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }

}
