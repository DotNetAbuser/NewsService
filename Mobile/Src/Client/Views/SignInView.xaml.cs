namespace Client.Views;

public partial class SignInView : ContentPage
{
    public SignInView(SignInVM vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}