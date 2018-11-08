using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XF.LocalDB.View.Professor
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            App.ProfessorVM.Carregar();
        }                    
    }
}
