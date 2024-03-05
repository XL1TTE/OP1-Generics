using Department;
using Institutes;
using Microsoft.VisualBasic;
using OP1.Commands;
using OP1.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OP1.ViewModels
{
    public class MedicalViewModel : ViewModelBase
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

        private string _specialization;
        public string Specialization
        {
            get => _specialization;

            set
            {
                _specialization = value;
                OnPropertyChanged(nameof(Specialization));
            }
        }
        public Department<MedicalStudent> MedDepartment { get; set; }

        private MedicalStudent[] _students;
        public MedicalStudent[] Students 
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
        public ICommand AddStudentCommand { get; }
        public ICommand RemoveMedStudentCommand { get; }

        public MedicalViewModel(NavigationService startWindowNavigationService, Department<MedicalStudent> MedicalDepartment)
        {
            MedDepartment = MedicalDepartment;
            Update();
            MenuCommand = new NavigateCommand(startWindowNavigationService, startWindowNavigationService._createViewModel["start"]);
            AddStudentCommand = new AddMedStudentCommand(this);
            RemoveMedStudentCommand = new RemoveMedStudentCommand(this);
        }


        private void Update()
        {
            Students = MedDepartment.GetStudentsList();
        }
        
    }
}
