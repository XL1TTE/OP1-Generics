using OP1.Stores;
using OP1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP1.Services
{
    public class NavigationService
    {

        private readonly NavigationStore _navigationStore;
        public Dictionary<string, Func<ViewModelBase>> _createViewModel;

        public NavigationService(NavigationStore navigationStore, Dictionary<string, Func<ViewModelBase>> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }

        public void Navigate(Func<ViewModelBase> navfunc)
        {
            _navigationStore.CurrentViewModel = navfunc();
        }
    }
}
