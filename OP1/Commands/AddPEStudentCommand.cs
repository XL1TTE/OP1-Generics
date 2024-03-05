using Department;
using Institutes;
using OP1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP1.Commands
{
    public class AddPEStudentCommand: CommandBase
    {
        public PEViewModel _PEViewModel;
        public Department<PEStudent> _department;
        public AddPEStudentCommand(PEViewModel PEViewModel)
        {
            _PEViewModel = PEViewModel;
            _department = PEViewModel.PEDepartment;
        }

        public override void Execute(object? parameter)
        {
            if (_department.GetStudentsList().All(item => item.FIO != _PEViewModel.Name))
            {
                _department.EnrollStudent(new PEStudent() { FIO = _PEViewModel.Name, SportDiscipline = _PEViewModel.Discipline });
                _PEViewModel.Students = _department.GetStudentsList();
            }

        }

    }
}

