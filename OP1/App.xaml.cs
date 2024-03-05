using OP1.Stores;
using OP1.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using OP1.Services;
using Department;
using Institutes;

namespace OP1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NavigationStore _navigationStore;
        private Department<MedicalStudent> _Meddepartment;
        private Department<PEStudent> _PEdepartment;
        private Department<SEStudent>  _SEdepartment;

        public App()
        {
            _navigationStore = new NavigationStore();
            _Meddepartment = new Department<MedicalStudent>();
            _PEdepartment = new Department<PEStudent>();
            _SEdepartment = new Department<SEStudent>();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            _navigationStore.CurrentViewModel = MakeStartWindowViewModel();

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }



        private SEViewModel MakeSEViewModel()
        {
            Dictionary<string, Func<ViewModelBase>> commands = new Dictionary<string, Func<ViewModelBase>>()
            {
                {"start",  MakeStartWindowViewModel},
            };
            return new SEViewModel(new NavigationService(_navigationStore, commands), _SEdepartment);
        }
        private PEViewModel MakePEViewModell()
        {
            Dictionary<string, Func<ViewModelBase>> commands = new Dictionary<string, Func<ViewModelBase>>()
            {
                {"start",  MakeStartWindowViewModel},
            };
            return new PEViewModel(new NavigationService(_navigationStore, commands), _PEdepartment);
        }
        private MedicalViewModel MakeMedicalViewModel()
        {
            Dictionary<string, Func<ViewModelBase>> commands = new Dictionary<string, Func<ViewModelBase>>()
            {
                {"start",  MakeStartWindowViewModel},
            };
            return new MedicalViewModel(new NavigationService(_navigationStore, commands), _Meddepartment);
        }

        private ViewModelBase MakeStartWindowViewModel()
        {
            Dictionary<string, Func<ViewModelBase>> commands = new Dictionary<string, Func<ViewModelBase>>()
            {
                {"SE",  MakeSEViewModel},
                {"PE",  MakePEViewModell},
                {"MED", MakeMedicalViewModel},

            };
            return new StartWindowViewModel(new NavigationService(_navigationStore, commands));
        }
    }
}
