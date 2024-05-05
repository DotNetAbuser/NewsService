namespace Client.Views;

public partial class HomeView : ContentPage
{
    public HomeView(HomeVM vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}