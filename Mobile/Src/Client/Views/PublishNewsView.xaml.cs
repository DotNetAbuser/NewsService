namespace Client.Views;

public partial class PublishNewsView : ContentPage
{
    public PublishNewsView(PublishNewsVM vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}