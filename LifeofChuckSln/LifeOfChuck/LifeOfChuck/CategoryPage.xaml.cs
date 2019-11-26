using ChuckNorrisJokesLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LifeOfChuck
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoryPage : ContentPage
    {
        public CategoryPage()
        {
            InitializeComponent();
        }

        public string[] Categories { get; set; }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var jokeGen = new JokeGenerator();
            Categories = await jokeGen.GetCategories();
            BindingContext = this;

        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var jokeGenerator = new JokeGenerator();
            string haha = await jokeGenerator.GetSpecifiedJoke(e.Item.ToString());
            await DisplayAlert("Joke", haha, "Ok");
        }
    }
    }
