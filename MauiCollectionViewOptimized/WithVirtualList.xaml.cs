using MauiCollectionViewOptimized.ViewModels;

namespace MauiCollectionViewOptimized;

public partial class WithVirtualList : ContentPage
{
    public WithVirtualList(WithVirtualListViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}