using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Plugin.XamarinFormsSaveOpenPDFPackage;
using Xamarin.Forms;

namespace Base64ToPDF
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
			////ref video - https://www.youtube.com/watch?v=FqetV1Lh-9c
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var httpClient = new HttpClient();
            var stream = await httpClient.GetStreamAsync("https://gerald.verslu.is/subscribe.pdf");

            using (var memoryStream = new MemoryStream())
            {
                await stream.CopyToAsync(memoryStream);

                await CrossXamarinFormsSaveOpenPDFPackage.Current.SaveAndView("myFile.pdf", "application/pdf", memoryStream, PDFOpenContext.InApp);
            }
        }
    }
}