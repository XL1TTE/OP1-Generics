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
    public class AddSEStudentCommand: CommandBase
    {
        public SEViewModel _SEViewModel;
        public Department<SEStudent> _department;
        public AddSEStudentCommand(SEViewModel SEViewModel)
        {
            _SEViewModel = SEViewModel;
            _department = SEViewModel.SEDepartment;
        }

        public override void Execute(object? parameter)
        {
            if (_department.GetStudentsList().All(item => item.FIO != _SEViewModel.Fio))
            {
                _department.EnrollStudent(new SEStudent() { FIO = _SEViewModel.Fio, ProgrammingLanguage = _SEViewModel.ProgrammingLanguage });
                _SEViewModel.Students = _department.GetStudentsList();
            }

        }
    }
}
