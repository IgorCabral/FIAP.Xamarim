using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XF.LocalDB.Model;

namespace XF.LocalDB.ViewModel
{
    public class ProfessorViewModel : INotifyPropertyChanged
    {
        #region Propriedades

        public Professor ProfessorModel { get; set; }
        public string ProfessorNome { get { return App.UsuarioVM.Nome; } }

        private Professor selecionado;
        public Professor ProfessorSelecionado
        {
            get { return selecionado; }
            set
            {
                selecionado = value as Professor;
                EventPropertyChanged();
            }
        }

        private string pesquisaPorNome;
        public string PesquisaProfessorPorNome
        {
            get { return pesquisaPorNome; }
            set
            {
                if (value == pesquisaPorNome) return;

                pesquisaPorNome = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PesquisaProfessorPorNome)));
                AplicarFiltro();
            }
        }

        public List<Professor> CopiaListaProfessors;
        public ObservableCollection<Professor> Professors { get; set; } = new ObservableCollection<Professor>();

        // UI Events
        public OnAdicionarProfessorCMD OnAdicionarProfessorCMD { get; }
        public OnEditarProfessorCMD OnEditarProfessorCMD { get; }
        public OnDeleteProfessorCMD OnDeleteProfessorCMD { get; }
        public ICommand OnSairProfessorCMD { get; private set; }
        public ICommand OnNovoProfessorCMD { get; private set; }

        #endregion

        public ProfessorViewModel()
        {
            OnAdicionarProfessorCMD = new OnAdicionarProfessorCMD(this);
            OnEditarProfessorCMD = new OnEditarProfessorCMD(this);
            OnDeleteProfessorCMD = new OnDeleteProfessorCMD(this);
            OnSairProfessorCMD = new Command(OnProfessorSair);
            OnNovoProfessorCMD = new Command(OnProfessorNovo);

            CopiaListaProfessors = new List<Professor>();
            Carregar();
        }

        public void Carregar()
        {
            CopiaListaProfessors = ProfessorRepository.GetProfessoresSqlAzureAsync().Result;
            AplicarFiltro();
        }

        private void AplicarFiltro()
        {
            if (PesquisaProfessorPorNome == null)
                PesquisaProfessorPorNome = "";

            var resultado = CopiaListaProfessors.Where(n => n.Nome.ToLowerInvariant()
                                .Contains(PesquisaProfessorPorNome.ToLowerInvariant().Trim())).ToList();

            var removerDaLista = Professors.Except(resultado).ToList();
            foreach (var item in removerDaLista)
            {
                Professors.Remove(item);
            }

            for (int index = 0; index < resultado.Count; index++)
            {
                var item = resultado[index];
                if (index + 1 > Professors.Count || !Professors[index].Equals(item))
                    Professors.Insert(index, item);
            }
        }

        public void Adicionar(Professor paramProfessor)
        {
            if ((paramProfessor == null) || (string.IsNullOrWhiteSpace(paramProfessor.Nome)))
                App.Current.MainPage.DisplayAlert("Atenção", "O campo nome é obrigatório", "OK");
            else if (ProfessorRepository.PostProfessorSqlAzureAsync(paramProfessor).Result)
                App.Current.MainPage.Navigation.PopAsync();
            else
                App.Current.MainPage.DisplayAlert("Falhou", "Desculpe, ocorreu um erro inesperado =(", "OK");
        }

        public async void Editar()
        {
            await App.Current.MainPage.Navigation.PushAsync(
                new View.Professor.NovoProfessorView() { BindingContext = App.ProfessorVM });
        }

        public async void Remover()
        {
            if (await App.Current.MainPage.DisplayAlert("Atenção?",
                string.Format("Tem certeza que deseja remover o {0}?", ProfessorSelecionado.Nome), "Sim", "Não"))
            {
                if (ProfessorRepository.DeleteProfessorSqlAzureAsync(ProfessorSelecionado.Id.ToString()).Result)
                {
                    CopiaListaProfessors.Remove(ProfessorSelecionado);
                    Carregar();
                }
                else
                    await App.Current.MainPage.DisplayAlert(
                            "Falhou", "Desculpe, ocorreu um erro inesperado =(", "OK");
            }
        }

        private async void OnProfessorSair()
        {
            await App.Current.MainPage.Navigation.PopAsync();
        }

        private void OnProfessorNovo()
        {
            App.ProfessorVM.ProfessorSelecionado = new Model.Professor();
            App.Current.MainPage.Navigation.PushAsync(
                new View.Professor.NovoProfessorView() { BindingContext = App.ProfessorVM });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void EventPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    public class OnAdicionarProfessorCMD : ICommand
    {
        private ProfessorViewModel ProfessorVM;
        public OnAdicionarProfessorCMD(ProfessorViewModel paramVM)
        {
            ProfessorVM = paramVM;
        }
        public event EventHandler CanExecuteChanged;
        public void AdicionarCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        public bool CanExecute(object parameter) => true;
        public void Execute(object parameter)
        {
            ProfessorVM.Adicionar(parameter as Professor);
        }
    }

    public class OnEditarProfessorCMD : ICommand
    {
        private ProfessorViewModel ProfessorVM;
        public OnEditarProfessorCMD(ProfessorViewModel paramVM)
        {
            ProfessorVM = paramVM;
        }
        public event EventHandler CanExecuteChanged;
        public void EditarCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        public bool CanExecute(object parameter) => (parameter != null);
        public void Execute(object parameter)
        {
            App.ProfessorVM.ProfessorSelecionado = parameter as Professor;
            ProfessorVM.Editar();
        }
    }

    public class OnDeleteProfessorCMD : ICommand
    {
        private ProfessorViewModel ProfessorVM;
        public OnDeleteProfessorCMD(ProfessorViewModel paramVM)
        {
            ProfessorVM = paramVM;
        }
        public event EventHandler CanExecuteChanged;
        public void DeleteCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        public bool CanExecute(object parameter) => (parameter != null);
        public void Execute(object parameter)
        {
            App.ProfessorVM.ProfessorSelecionado = parameter as Professor;
            ProfessorVM.Remover();
        }
    }
}
