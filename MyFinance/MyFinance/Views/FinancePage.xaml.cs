using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyFinance.Models;
using MyFinance.Views;

namespace MyFinance.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FinancePage : ContentPage
    {

        private List<Finance> financeList = new List<Finance>();
        private Random RND = new Random();
        
        public FinancePage()
        {
            InitializeComponent();
            Finance finance = new Finance();
            financeList = finance.ReadFinance(financeList);
            RandomViewFinance(financeList);
        }

        private void RandomViewFinance(List<Finance> financeList1)
        {
            try
            {
                int[] mas = new int[financeList1.Count];
                mas = Enumerable.Range(1, financeList1.Count - 1)
                .OrderBy(_ => RND.NextDouble())
                .Take(5).ToArray();

                for (int i = 0; i < 5; i++)
                {
                    if (i == 0)
                    {
                        NameLabel_1.Text =financeList1[mas[i]].text;
                        DiscriptionLabel_1.Text = (Convert.ToString(financeList1[mas[i]].digit)+"руб.");
                        DateLabel_1.Text = financeList1[mas[i]].date;
                        if (financeList1[mas[i]].dohodOrRashod == 1)
                        {
                            check1.Color = Color.Red;
                        }
                        else { check1.Color = Color.Green; }

                    }
                    if (i == 1)
                    {
                        NameLabel_2.Text = financeList1[mas[i]].text;
                        DiscriptionLabel_2.Text = Convert.ToString(financeList1[mas[i]].digit + "руб.");
                        DateLabel_2.Text = financeList1[mas[i]].date;
                        if (financeList1[mas[i]].dohodOrRashod == 1)
                        {
                            check2.Color = Color.Red;
                        }
                        else { check2.Color = Color.Green; }

                    }
                    if (i == 2)
                    {
                        NameLabel_3.Text = financeList1[mas[i]].text;
                        DiscriptionLabel_3.Text = Convert.ToString(financeList1[mas[i]].digit) + "руб.";
                        DateLabel_3.Text = financeList1[mas[i]].date;
                        if (financeList1[mas[i]].dohodOrRashod == 1)
                        {
                            check3.Color = Color.Red;
                        }
                        else { check3.Color = Color.Green; }
                    }
                    if (i == 3)
                    {
                        NameLabel_4.Text = financeList1[mas[i]].text;
                        DiscriptionLabel_4.Text = Convert.ToString(financeList1[mas[i]].digit) + "руб.";
                        DateLabel_4.Text = financeList1[mas[i]].date;
                        if (financeList1[mas[i]].dohodOrRashod == 1)
                        {
                            check4.Color = Color.Red;
                        }
                        else { check4.Color = Color.Green; }
                    }
                    if (i == 4)
                    {
                        NameLabel_5.Text = financeList1[mas[i]].text;
                        DiscriptionLabel_5.Text = Convert.ToString(financeList1[mas[i]].digit) + "руб.";
                        DateLabel_5.Text = financeList1[mas[i]].date;
                        if (financeList1[mas[i]].dohodOrRashod == 1)
                        {
                            check5.Color = Color.Red;
                        }
                        else { check5.Color = Color.Green; }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ERROR!!!");
            }
        }

        private void refresh_Refreshing(object sender, EventArgs e)
        {
            List<Finance> financeList1 = new List<Finance>();
            Finance finance1 = new Finance();
            financeList1 = finance1.ReadFinance(financeList1);
            InputFinance(financeList1.OrderByDescending(x => x.id).ToList());
            refresh.IsRefreshing = false;
        }

        private void picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (picker.SelectedIndex == 0)
                RandomViewFinance(financeList);
            if (picker.SelectedIndex == 1)
                DigitUpViewFinance();
            if (picker.SelectedIndex == 2)
                DigitDownViewFinance();
            if (picker.SelectedIndex == 3)
                NewViewFinance();
            if (picker.SelectedIndex == 4)
                OldViewFinance();

        }
        private async void configButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Configure());
        }

        private async void InputFinance(List<Finance> sortedFinance)
        {
            if (sortedFinance.Count >= 5)
            {
                for (int i = 0; i < 6; i++)
                {
                    if (i == 0)
                    {
                        NameLabel_1.Text = sortedFinance[i].text;
                        DiscriptionLabel_1.Text = Convert.ToString(sortedFinance[i].digit) + "руб.";
                        DateLabel_1.Text = Convert.ToString(sortedFinance[i].date);
                        if (sortedFinance[i].dohodOrRashod == 1)
                        {
                            check1.Color = Color.Red;
                        }
                        else { check1.Color = Color.Green; }
                    }
                    if (i == 1)
                    {
                        NameLabel_2.Text = sortedFinance[i].text;
                        DiscriptionLabel_2.Text = Convert.ToString(sortedFinance[i].digit) + "руб.";
                        DateLabel_2.Text = Convert.ToString(sortedFinance[i].date);
                        if (sortedFinance[i].dohodOrRashod == 1)
                        {
                            check2.Color = Color.Red;
                        }
                        else { check2.Color = Color.Green; }
                    }
                    if (i == 2)
                    {
                        NameLabel_3.Text = sortedFinance[i].text;
                        DiscriptionLabel_3.Text = Convert.ToString(sortedFinance[i].digit) + "руб.";
                        DateLabel_3.Text = Convert.ToString(sortedFinance[i].date);
                        if (sortedFinance[i].dohodOrRashod == 1)
                        {
                            check3.Color = Color.Red;
                        }
                        else { check3.Color = Color.Green; }
                    }
                    if (i == 3)
                    {
                        NameLabel_4.Text = sortedFinance[i].text;
                        DiscriptionLabel_4.Text = Convert.ToString(sortedFinance[i].digit) + "руб.";
                        DateLabel_4.Text = Convert.ToString(sortedFinance[i].date);
                        if (sortedFinance[i].dohodOrRashod == 1)
                        {
                            check4.Color = Color.Red;
                        }
                        else { check4.Color = Color.Green; }
                    }
                    if (i == 4)
                    {
                        NameLabel_5.Text = sortedFinance[i].text;
                        DiscriptionLabel_5.Text = Convert.ToString(sortedFinance[i].digit) + "руб.";
                        DateLabel_5.Text = Convert.ToString(sortedFinance[i].date);
                        if (sortedFinance[i].dohodOrRashod == 1)
                        {
                            check5.Color = Color.Red;
                        }
                        else { check5.Color = Color.Green; }
                    }

                }
            }
            else if (sortedFinance.Count == 4)
            {
                for (int i = 0; i < 6; i++)
                {
                    if (i == 0)
                    {
                        NameLabel_1.Text = sortedFinance[i].text;
                        DiscriptionLabel_1.Text = Convert.ToString(sortedFinance[i].digit) + "руб.";
                        DateLabel_1.Text = Convert.ToString(sortedFinance[i].date);
                        if (sortedFinance[i].dohodOrRashod == 1)
                        {
                            check1.Color = Color.Red;
                        }
                        else { check1.Color = Color.Green; }
                    }
                    if (i == 1)
                    {
                        NameLabel_2.Text = sortedFinance[i].text;
                        DiscriptionLabel_2.Text = Convert.ToString(sortedFinance[i].digit) + "руб.";
                        DateLabel_2.Text = Convert.ToString(sortedFinance[i].date);
                        if (sortedFinance[i].dohodOrRashod == 1)
                        {
                            check2.Color = Color.Red;
                        }
                        else { check2.Color = Color.Green; }
                    }
                    if (i == 2)
                    {
                        NameLabel_3.Text = sortedFinance[i].text;
                        DiscriptionLabel_3.Text = Convert.ToString(sortedFinance[i].digit) + "руб.";
                        DateLabel_3.Text = Convert.ToString(sortedFinance[i].date);
                        if (sortedFinance[i].dohodOrRashod == 1)
                        {
                            check3.Color = Color.Red;
                        }
                        else { check3.Color = Color.Green; }
                    }
                    if (i == 3)
                    {
                        NameLabel_4.Text = sortedFinance[i].text;
                        DiscriptionLabel_4.Text = Convert.ToString(sortedFinance[i].digit) + "руб.";
                        DateLabel_4.Text = Convert.ToString(sortedFinance[i].date);
                        if (sortedFinance[i].dohodOrRashod == 1)
                        {
                            check4.Color = Color.Red;
                        }
                        else { check4.Color = Color.Green; }
                    }
                }

            }
            else if (sortedFinance.Count == 3)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (i == 0)
                    {
                        NameLabel_1.Text = sortedFinance[i].text;
                        DiscriptionLabel_1.Text = Convert.ToString(sortedFinance[i].digit) + "руб.";
                        DateLabel_1.Text = Convert.ToString(sortedFinance[i].date);
                        if (sortedFinance[i].dohodOrRashod == 1)
                        {
                            check1.Color = Color.Red;
                        }
                        else { check1.Color = Color.Green; }
                    }
                    if (i == 1)
                    {
                        NameLabel_2.Text = sortedFinance[i].text;
                        DiscriptionLabel_2.Text = Convert.ToString(sortedFinance[i].digit) + "руб.";
                        DateLabel_2.Text = Convert.ToString(sortedFinance[i].date);
                        if (sortedFinance[i].dohodOrRashod == 1)
                        {
                            check2.Color = Color.Red;
                        }
                        else { check2.Color = Color.Green; }
                    }
                    if (i == 2)
                    {
                        NameLabel_3.Text = sortedFinance[i].text;
                        DiscriptionLabel_3.Text = Convert.ToString(sortedFinance[i].digit) + "руб.";
                        DateLabel_3.Text = Convert.ToString(sortedFinance[i].date);
                        if (sortedFinance[i].dohodOrRashod == 1)
                        {
                            check3.Color = Color.Red;
                        }
                        else { check3.Color = Color.Green; }
                    }
                }
            }
            else if (sortedFinance.Count == 2)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (i == 0)
                    {
                        NameLabel_1.Text = sortedFinance[i].text;
                        DiscriptionLabel_1.Text = Convert.ToString(sortedFinance[i].digit) + "руб.";
                        DateLabel_1.Text = Convert.ToString(sortedFinance[i].date);
                        if (sortedFinance[i].dohodOrRashod == 1)
                        {
                            check1.Color = Color.Red;
                        }
                        else { check1.Color = Color.Green; }
                    }
                    if (i == 1)
                    {
                        NameLabel_2.Text = sortedFinance[i].text;
                        DiscriptionLabel_2.Text = Convert.ToString(sortedFinance[i].digit) + "руб.";
                        DateLabel_2.Text = Convert.ToString(sortedFinance[i].date);
                        if (sortedFinance[i].dohodOrRashod == 1)
                        {
                            check2.Color = Color.Red;
                        }
                        else { check2.Color = Color.Green; }
                    }
                }
            }
            else if (sortedFinance.Count == 1)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (i == 0)
                    {
                        NameLabel_1.Text = sortedFinance[i].text;
                        DiscriptionLabel_1.Text = Convert.ToString(sortedFinance[i].digit) + "руб.";
                        DateLabel_1.Text = Convert.ToString(sortedFinance[i].date);
                        if (sortedFinance[i].dohodOrRashod == 1)
                        {
                            check1.Color = Color.Red;
                        }
                        else { check1.Color = Color.Green; }
                    }
                }
            }
            else
                await DisplayAlert("⚠ Ошибка!", "Вы не ввели ещё ничего или произошла ошибка", "OK");
        }

        private void OldViewFinance()
        {
            List<Finance> financeList1 = new List<Finance>();
            Finance finance1 = new Finance();
            financeList1 = finance1.ReadFinance(financeList1);
            List<Finance> sortedFinance = financeList1.OrderBy(x => x.id).ToList();
            InputFinance(sortedFinance);
        }

        private void NewViewFinance()
        {
            List<Finance> financeList1 = new List<Finance>();
            Finance finance1 = new Finance();
            financeList1 = finance1.ReadFinance(financeList1);
            List<Finance> sortedFinance = financeList1.OrderByDescending(x => x.id).ToList();
            InputFinance(sortedFinance);
        }
        private void DigitUpViewFinance()
        {
            List<Finance> financeList1 = new List<Finance>();
            Finance finance1 = new Finance();
            financeList1 = finance1.ReadFinance(financeList1);
            List<Finance> sortedFinance = financeList1.OrderBy(x => x.digit).ToList();
            InputFinance(sortedFinance);
        }


        private void DigitDownViewFinance()
        {
            List<Finance> financeList1 = new List<Finance>();
            Finance finance1 = new Finance();
            financeList1 = finance1.ReadFinance(financeList1);
            List<Finance> sortedFinance = financeList1.OrderByDescending(x => x.digit).ToList();
            InputFinance(sortedFinance);
        }

        private void nextFrames_Clicked(object sender, EventArgs e)
        {
            RandomViewFinance(financeList);
            List.ScrollToAsync(0, 140, true);
        }


        ///
        private async void AddButton_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(FinanceAddingPage));
        }

    }
}