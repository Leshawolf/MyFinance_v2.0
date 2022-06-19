using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyFinance.Views;
using MyFinance.Models;

namespace MyFinance
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Exit();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
