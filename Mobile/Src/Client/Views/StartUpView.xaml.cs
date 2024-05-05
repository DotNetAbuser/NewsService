namespace Client.Views;

public partial class StartUpView : ContentPage
{
    public StartUpView(StartUpVM vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}