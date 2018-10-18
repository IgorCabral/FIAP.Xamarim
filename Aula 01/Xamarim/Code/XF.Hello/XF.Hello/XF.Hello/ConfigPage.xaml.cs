using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XF.Hello
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ConfigPage : ContentPage
	{
        static Config _ConfigPersist;
        static Config ConfigPersist {
            get {
                if(_ConfigPersist != null)
                    return _ConfigPersist;
                else
                    _ConfigPersist = InitConfig(true, true, true, true, true);
                return _ConfigPersist;
            }
            set
            {
                _ConfigPersist = value;
            }
        }
		public ConfigPage ()
		{           
            BindingContext = ConfigPersist; // Persistente pelo runtime
			InitializeComponent ();
		}
        public static Config InitConfig(bool disponibilizarMural, bool enviarEmail, bool permitirCookies, bool rastrearLocalizacao, bool receberSms)
        {
            return new Config()
            {
                DisponibilizarMural = disponibilizarMural,
                EnviarEmail = enviarEmail,
                PermitirCookies = permitirCookies,
                RastrearLocalizacao = rastrearLocalizacao,
                ReceberSms = receberSms
            };
        }
    }         
}