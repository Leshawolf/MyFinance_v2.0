using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Xamarin.Forms;
using MyFinance.Views;
using MyFinance.Models;
using Xamarin.Forms.Xaml;
using MyFinance;

namespace MyFinance.Views
{
    public partial class FinanceAddingPage : ContentPage
    {

        public FinanceAddingPage()
        {
            InitializeComponent();

            BindingContext = new Finance();
        }

        private async void OnSaveRashod_Clicked(object sender, EventArgs e)
        {
            if(LbDigit.Text!="" || LbText.Text!="")
            {
                Users.SetState(File.ReadAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "accountInfo")), Convert.ToDouble(LbDigit.Text), 1);
                bool add = Finance.AddFinance(Convert.ToDouble(LbDigit.Text),LbText.Text,1);
            }
            else
            {
                await DisplayAlert("⚠Ошибка!", "Одно из полей не заполнено", "OK");
            }
        }

        private async void OnSaveDohod_Clicked(object sender, EventArgs e)
        {
            if (LbDigit.Text != "" || LbText.Text != "")
            {
                Users.SetState(File.ReadAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "accountInfo")), Convert.ToDouble(LbDigit.Text), 0);
                bool add = Finance.AddFinance(Convert.ToDouble(LbDigit.Text), LbText.Text, 0);
            }
            else
            {
                await DisplayAlert("⚠Ошибка!", "Одно из полей не заполнено", "OK");
            }
        }



    }
}