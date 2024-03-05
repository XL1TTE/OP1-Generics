using Department;
using Institutes;
using OP1.Commands;
using OP1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OP1.ViewModels
{
    public class PEViewModel: ViewModelBase
    {

        private string _name;
        public string Name
        {
            get => _name;

            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string _discipline;
        public string Discipline
        {
            get => _discipline;

            set
            {
                _discipline = value;
                OnPropertyChanged(nameof(Discipline));
            }
        }
        public Department<PEStudent> PEDepartment { get; set; }

        private PEStudent[] _students;
        public PEStudent[] Students
        {
            get
            {
                return _students;
            }
            set
            {
                _students = value;
                OnPropertyChanged(nameof(Students));
            }
        }

        public ICommand MenuCommand { get; }
        public ICommand AddPEStudentCommand { get; }
        public ICommand RemovePEStudentCommand { get; }

        public PEViewModel(NavigationService startWindowNavigationService, Department<PEStudent> _PEDepartment)
        {
            PEDepartment = _PEDepartment;
            Update();
            
            MenuCommand = new NavigateCommand(startWindowNavigationService, startWindowNavigationService._createViewModel["start"]);
            AddPEStudentCommand = new AddPEStudentCommand(this);
            RemovePEStudentCommand = new RemovePEStudentCommand(this);
        }

        private void Update()
        {
            Students = PEDepartment.GetStudentsList();
        }
    }
}
