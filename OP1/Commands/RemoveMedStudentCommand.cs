using Department;
using Institutes;
using OP1.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP1.Commands
{
    public class RemoveMedStudentCommand : CommandBase
    {
        public MedicalViewModel _medicalViewModel;
        public Department<MedicalStudent> _department;
        public RemoveMedStudentCommand(MedicalViewModel medicalViewModel)
        {
            _medicalViewModel = medicalViewModel;
            _department = medicalViewModel.MedDepartment;
        }

        public override void Execute(object? parameter)
        {
            foreach (var item in _department._studentsList)
            {
                if(item.Name == _medicalViewModel.Name && item.Specialization == _medicalViewModel.Specialization)
                {
                    _department.ExpelStudent(item);
                }
            }
            _medicalViewModel.Students = _department.GetStudentsList();
        }
    }
}
