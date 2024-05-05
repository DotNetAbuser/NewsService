namespace Client.Controls;

public partial class ProfileButton : ContentView
{
    public ProfileButton() =>
        InitializeComponent();

    public static readonly BindableProperty IconBackgroundColorProperty = BindableProperty.Create(
        propertyName: nameof(IconBackgroundColor),
        returnType: typeof(Color),
        declaringType: typeof(ProfileButton),
        defaultValue: null,
        defaultBindingMode: BindingMode.OneWay);

    public static readonly BindableProperty IconProperty = BindableProperty.Create(
        propertyName: nameof(Icon),
        returnType: typeof(string),
        declaringType: typeof(ProfileButton),
        defaultValue: string.Empty,
        defaultBindingMode: BindingMode.OneWay);
    
    public static readonly BindableProperty TextProperty = BindableProperty.Create(
        propertyName: nameof(Text),
        returnType: typeof(string),
        declaringType: typeof(ProfileButton),
        defaultValue: "Пусто",
        defaultBindingMode: BindingMode.OneWay);
    
    public static readonly BindableProperty ClickCommandProperty = BindableProperty.Create(
        propertyName: nameof(ClickCommand),
        returnType: typeof(ICommand),
        declaringType: typeof(ProfileButton));
    
    public Color IconBackgroundColor
    {
        get => (Color)GetValue(IconBackgroundColorProperty);
        set => SetValue(IconBackgroundColorProperty, value);
    }
    
    public string Icon
    {
        get => (string)GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }
    
    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }
    
    public ICommand ClickCommand
    {
        get => (ICommand)GetValue(ClickCommandProperty);
        set => SetValue(ClickCommandProperty, value);
    }
}