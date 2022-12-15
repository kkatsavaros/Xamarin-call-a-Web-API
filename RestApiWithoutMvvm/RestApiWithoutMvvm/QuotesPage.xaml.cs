using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestApiWithoutMvvm
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuotesPage : ContentPage
    {
        public QuotesPage()
        {
            InitializeComponent();
            LoadQuotes();
        }


        public async void LoadQuotes()
        {
            var httpClient = new HttpClient();

            var response = await httpClient.GetStringAsync("https://quotessamplerestfulwebapi.azurewebsites.net/api/quotes");

            var quotes = JsonConvert.DeserializeObject<List<Quote>>(response);

            LvQuotes.ItemsSource = quotes;
        }

    }
}