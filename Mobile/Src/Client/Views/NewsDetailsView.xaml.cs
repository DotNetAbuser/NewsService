namespace Client.Views;

public partial class NewsDetailsView : ContentPage
{
    public NewsDetailsView(NewsDetailsVM vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}