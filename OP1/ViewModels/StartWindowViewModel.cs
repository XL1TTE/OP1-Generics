using OP1.Commands;
using OP1.Services;
using OP1.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OP1.ViewModels
{
    public class StartWindowViewModel: ViewModelBase
    {
        public ICommand SEenrollCommand { get; }

        public ICommand PEenrollCommand { get; }

        public ICommand MEDenrollCommand { get; }


        public StartWindowViewModel(NavigationService navigationService)
        {
            SEenrollCommand = new NavigateCommand(navigationService, navigationService._createViewModel["SE"]);
            MEDenrollCommand = new NavigateCommand(navigationService, navigationService._createViewModel["MED"]);
            PEenrollCommand = new NavigateCommand(navigationService, navigationService._createViewModel["PE"]);
        }
    }   
}
