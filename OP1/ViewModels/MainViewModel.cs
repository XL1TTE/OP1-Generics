using OP1.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace OP1.ViewModels
{
    public class MainViewModel: ViewModelBase
    {
        private readonly NavigationStore _navigatedStore;
        public ViewModelBase CurrentViewModel => _navigatedStore.CurrentViewModel;

        public MainViewModel(NavigationStore navigatedStore)
        {
            _navigatedStore = navigatedStore;

            _navigatedStore.CurentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
