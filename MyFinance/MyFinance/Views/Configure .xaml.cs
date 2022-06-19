using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyFinance.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Configure : ContentPage
    {
        public Configure()
        {
            InitializeComponent();
        }
        private async void closeConfigButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}