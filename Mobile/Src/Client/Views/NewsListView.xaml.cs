using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Views;

public partial class NewsListView : ContentPage
{
    public NewsListView(NewsListVM vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}