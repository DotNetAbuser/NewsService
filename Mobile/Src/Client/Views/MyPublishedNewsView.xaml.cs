namespace Client.Views;

public partial class MyPublishedNewsView : ContentPage
{
    public MyPublishedNewsView(MyPublishedNewsVM vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}