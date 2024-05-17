namespace Client.Views;

public partial class ModerateNewsView 
    : ContentPage
{
    public ModerateNewsView(ModerateNewsVM vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}