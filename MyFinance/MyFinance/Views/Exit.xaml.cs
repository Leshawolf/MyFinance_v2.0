using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFinance.Views;
using MyFinance.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyFinance.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Exit : ContentPage
    {
        public Exit()
        {
            InitializeComponent();

        }


        private async void Registration_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new RegistrationPage());
        }

        private async void Authorization_Clicked(object sender, EventArgs e)
        {
            if (Users.Authorization(LbLogin.Text, LbPassword.Text))
            {
                (Application.Current).MainPage = new Main();
            }
            else
            {
                await DisplayAlert("⚠ Ошибка!", "Введены неверные данные!", "OK");
            };
        }
    }
}