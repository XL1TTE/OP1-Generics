using OP1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Institutes;
using System.Collections.ObjectModel;
using Department;

namespace OP1.Commands
{
    internal class AddMedStudentCommand : CommandBase
    {

        public MedicalViewModel _medicalViewModel;
        public Department<MedicalStudent> _department;
        public AddMedStudentCommand(MedicalViewModel medicalViewModel)
        {
            _medicalViewModel = medicalViewModel;
            _department = medicalViewModel.MedDepartment;
        }

        public override void Execute(object? parameter)
        {
            if (_department.GetStudentsList().All(item => item.Name != _medicalViewModel.Name))
            {
                _department.EnrollStudent(new MedicalStudent() { Name = _medicalViewModel.Name, Specialization = _medicalViewModel.Specialization });
                _medicalViewModel.Students = _department.GetStudentsList();
            }
        }

    }
}
