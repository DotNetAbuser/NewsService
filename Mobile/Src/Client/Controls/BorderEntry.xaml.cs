using System.Windows.Input;

namespace Client.Controls;

public partial class BorderEntry : Border
{
    public BorderEntry() =>
        InitializeComponent();
    
    public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(
        propertyName: nameof(Placeholder),
        returnType: typeof(string),
        declaringType: typeof(BorderEntry),
        defaultValue: null,
        defaultBindingMode: BindingMode.OneWay);
    
    public static readonly BindableProperty TextProperty = BindableProperty.Create(
        propertyName: nameof(Text),
        returnType: typeof(string),
        declaringType: typeof(BorderEntry),
        defaultValue: string.Empty,
        defaultBindingMode: BindingMode.TwoWay);
    
    public static readonly BindableProperty IsPasswordProperty = BindableProperty.Create(
        propertyName: nameof(IsPassword),
        returnType: typeof(bool),
        declaringType: typeof(BorderEntry),
        defaultValue: false,
        defaultBindingMode: BindingMode.TwoWay);
    
    public static readonly BindableProperty IsPasswordNotVisibleProperty = BindableProperty.Create(
        propertyName: nameof(IsPasswordNotVisible),
        returnType: typeof(bool),
        declaringType: typeof(BorderEntry),
        defaultValue: false,
        defaultBindingMode: BindingMode.TwoWay);
    
    public static readonly BindableProperty ChangeIsPasswordVisibleCommandProperty = BindableProperty.Create(
        propertyName: nameof(ChangeIsPasswordVisibleCommand),
        returnType: typeof(ICommand),
        declaringType: typeof(BorderEntry));
    
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
    
    public bool IsPassword
    {
        get => (bool)GetValue(IsPasswordProperty);
        set => SetValue(IsPasswordProperty, value);
    }
    
    public bool IsPasswordNotVisible
    {
        get => (bool)GetValue(IsPasswordNotVisibleProperty);
        set => SetValue(IsPasswordNotVisibleProperty, value);
    }
    
    public ICommand ChangeIsPasswordVisibleCommand
    {
        get => (ICommand)GetValue(ChangeIsPasswordVisibleCommandProperty);
        set => SetValue(ChangeIsPasswordVisibleCommandProperty, value);
    }
}