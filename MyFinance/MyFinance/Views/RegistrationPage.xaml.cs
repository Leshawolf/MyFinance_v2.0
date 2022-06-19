using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyFinance.Models;
using MyFinance.Views;

namespace MyFinance.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {

        public RegistrationPage()
        {
            InitializeComponent();
        }

        private async void CreateNewAccountBtn_Clicked(object sender, EventArgs e)
        {
            bool reg = Users.Registration(LbLogin.Text, LbPassword.Text, LbPasswordRetry.Text);
            if (!reg)
            {
                await DisplayAlert("⚠ Ошибка!", "Введены неверные данные!\n - Аккаунт с таким логином существует.\n — Логин должен быть не короче 5 символов.\n - Пароль должен быть не короче 8 символов.\n - Пароли должны совподать.", "OK");
                LbLogin.Text = String.Empty;
                LbPassword.Text = String.Empty;
                LbPasswordRetry.Text = String.Empty;

            }
            else
            {
                await DisplayAlert("✅ Регистрация", "Регистрация прошла успешно!", "OK");
                (Application.Current).MainPage = new Main();

            }
        }

        private async void Exit_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Exit());
        }
    }
}