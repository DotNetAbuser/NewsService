using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Views;

public partial class ProfileView : ContentPage
{
    public ProfileView(ProfileVM vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}