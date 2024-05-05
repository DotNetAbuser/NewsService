namespace Client.Controls;

public partial class BorderSearchBar : Border
{
    public BorderSearchBar() =>
        InitializeComponent();
    
    public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(
        propertyName: nameof(Placeholder),
        returnType: typeof(string),
        declaringType: typeof(BorderSearchBar),
        defaultValue: null,
        defaultBindingMode: BindingMode.OneWay);
    
    public static readonly BindableProperty TextProperty = BindableProperty.Create(
        propertyName: nameof(Text),
        returnType: typeof(string),
        declaringType: typeof(BorderSearchBar),
        defaultValue: string.Empty,
        defaultBindingMode: BindingMode.TwoWay);
    
    public static readonly BindableProperty SearchCommandProperty = BindableProperty.Create(
        propertyName: nameof(SearchCommand),
        returnType: typeof(ICommand),
        declaringType: typeof(BorderSearchBar));
    
    public string Placeholder
    {
        get => (string)GetValue(PlaceholderProperty);
        set => SetValue(PlaceholderProperty, value);
    }
    
    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }
    
    public ICommand SearchCommand
    {
        get => (ICommand)GetValue(SearchCommandProperty);
        set => SetValue(SearchCommandProperty, value);
    }
}