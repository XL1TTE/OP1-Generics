using OP1.Services;
using OP1.Stores;
using OP1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OP1.Commands
{
    internal class NavigateCommand : CommandBase
    {
        private readonly NavigationService _navigationService;
        private readonly Func<ViewModelBase> _navfunc;


        public NavigateCommand(NavigationService navigationService, Func<ViewModelBase> navfunc)
        {
            _navigationService = navigationService;
            _navfunc = navfunc;
        }
        public override void Execute(object? parameter)
        {
            _navigationService.Navigate(_navfunc);

        }
    }
}
