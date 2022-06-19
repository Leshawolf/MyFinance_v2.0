using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;
using MyFinance.Models;
using Xamarin.Forms;
using GemBox.Pdf;
using GemBox.Pdf.Content;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace MyFinance.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            ComponentInfo.SetLicense("FREE-LIMITED-KEY");

            InitializeComponent();
            
            Exit ex = new Exit();
            UserNameLb.Text = File.ReadAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "accountInfo"));
            CounerLb.Text = Users.CheckCounter(File.ReadAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "accountInfo")))+"руб.";
        }
        private void refresh_Refreshing(object sender, EventArgs e)
        {
            CounerLb.Text = Users.CheckCounter(File.ReadAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "accountInfo"))) + "руб.";
            refresh.IsRefreshing = false;
        }
        private static string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Otchet.pdf");
        private string CreateDocument()
        {
            var document = new PdfDocument();
            document.Pages.Add();
            document.Save(filePath);
            return filePath;
        }

        private async void otchet_Clicked(object sender, EventArgs e)
        {

            List<Finance> financeList1 = new List<Finance>();
            Finance finance1 = new Finance();
            financeList1 = finance1.ReadFinance(financeList1);

            //Ввод
            using (var document = new PdfDocument())
            {
                // Add a page.
                var page = document.Pages.Add();
                
                using (var formattedText = new PdfFormattedText())
                {
                    
                    formattedText.FontFamily = new PdfFontFamily("Times New Roman");
                    formattedText.FontSize = 20;
                    formattedText.AppendLine("User Agreement");
                    page.Content.DrawText(formattedText, new PdfPoint(200, 750));
                    formattedText.Clear();

                    formattedText.FontFamily = new PdfFontFamily("Times New Roman");
                    formattedText.FontSize = 20;
                    formattedText.MaxTextWidth = 500;
                    formattedText.AppendLine($"Using the \"My Finance\" application, the user allows you to save all the data entered on a remote MySQL database. All data is in the database in an unencrypted state except for the password. In the database, the password is encrypted for user privacy. All input data is linked to the user's login and has no secrecy. The user using this application agrees to the condition of open saving of the data entered into the database");
                    page.Content.DrawText(formattedText, new PdfPoint(50,500));
                    formattedText.Clear();


                    formattedText.FontFamily = new PdfFontFamily("Times New Roman");
                    formattedText.FontSize = 20;
                    formattedText.AppendLine($"You have performed {financeList1.Count} operations");
                    page.Content.DrawText(formattedText, new PdfPoint(20, 300));
                    formattedText.Clear();

                    formattedText.FontFamily = new PdfFontFamily("Times New Roman");
                    formattedText.FontSize = 20;
                    formattedText.AppendLine($"Amount of {Users.CheckCounter(File.ReadAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "accountInfo")))} rub.");
                    page.Content.DrawText(formattedText, new PdfPoint(20, 280));
                    formattedText.Clear();

                }

                document.Save(filePath);
                await Launcher.OpenAsync(new OpenFileRequest(Path.GetFileName(filePath), new ReadOnlyFile(filePath)));
            }
        }
    }
}