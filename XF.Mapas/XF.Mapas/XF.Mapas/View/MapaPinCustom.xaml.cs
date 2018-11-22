using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;
using XF.Mapas.App_Code;

namespace XF.Mapas.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapaPinCustom : ContentPage
    {
        Location locationTemp;

        public MapaPinCustom()
        {
            InitializeComponent();
            GetLocalizacaoAtual();

            tryagain:
            while (locationTemp == null)
            {
                Thread.Sleep(1000);
                goto tryagain;
            }

            var pin = new PinCustomizado
            {
                Type = PinType.Place,
                Position = new Position(locationTemp.Latitude, locationTemp.Longitude),
                Label = "Fiap",
                Address = "Av. Lins de Vasconcelos, 1264, Aclimação",
                Id = "Fiap",
                Localizacao = "https://www.fiap.com.br/"
            };
            meuMapa.MoveToRegion(
                MapSpan.FromCenterAndRadius(
                    new Position(locationTemp.Latitude, locationTemp.Longitude), Distance.FromMiles(1.0)));

            meuMapa.PinCustomizados = new List<PinCustomizado> { pin };
            meuMapa.Pins.Add(pin);
        }

        public void GetLocalizacaoAtual()
        {
            var Precisao = (int)GeolocationAccuracy.Lowest;
            var requisicao = new GeolocationRequest((GeolocationAccuracy)Precisao);
            var cts = new CancellationTokenSource();            
            var retorno = Geolocation.GetLocationAsync(requisicao, cts.Token).Result;
            locationTemp = retorno;
        }
    }
}