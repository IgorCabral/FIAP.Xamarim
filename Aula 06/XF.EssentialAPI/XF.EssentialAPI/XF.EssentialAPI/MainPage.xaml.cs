using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XF.EssentialAPI
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnPhone_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new View.PhoneView());
        }

        private void Conectividade_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new View.ConectividadeView());
        }

        private void Compartilhar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new View.CompartilharView());
        }

        private void Bateria_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new View.BateriaView());
        }

        private void Bussola_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new View.CompassoView());
        }
    }
}
