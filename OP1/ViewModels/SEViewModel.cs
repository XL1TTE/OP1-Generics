using Department;
using Institutes;
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
    public class SEViewModel: ViewModelBase
    {

        private string _fio;
        public string Fio
        {
            get => _fio;

            set
            {
                _fio = value;
                OnPropertyChanged(nameof(Fio));
            }
        }

        private string _programmingLanguage;
        public string ProgrammingLanguage
        {
            get => _programmingLanguage;

            set
            {
                _programmingLanguage = value;
                OnPropertyChanged(nameof(ProgrammingLanguage));
            }
        }
        public Department<SEStudent> SEDepartment { get; set; }

        private SEStudent[] _students;
        public SEStudent[] Students
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
        public ICommand AddSEStudentCommand { get; }
        public ICommand RemoveSEStudentCommand { get; }

        public SEViewModel(NavigationService startWindowNavigationService, Department<SEStudent> _SEDepartment)
        {
            SEDepartment = _SEDepartment;
            SEStudent sE = new SEStudent();
            
            Update();
            MenuCommand = new NavigateCommand(startWindowNavigationService, startWindowNavigationService._createViewModel["start"]);
            AddSEStudentCommand = new AddSEStudentCommand(this);
            RemoveSEStudentCommand = new RemoveSEStudentCommand(this);
        }

        private void Update()
        {
            Students = SEDepartment.GetStudentsList();
        }
    }

}

