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
    public class RemoveSEStudentCommand: CommandBase
    {
        public SEViewModel _PEViewModel;
        public Department<SEStudent> _department;
        public RemoveSEStudentCommand(SEViewModel SEViewModel)
        {
            _PEViewModel = SEViewModel;
            _department = SEViewModel.SEDepartment;
        }

        public override void Execute(object? parameter)
        {
            foreach (var item in _department._studentsList)
            {
                if (item.FIO == _PEViewModel.Fio && item.ProgrammingLanguage == _PEViewModel.ProgrammingLanguage)
                {
                    _department.ExpelStudent(item);
                }
            }
            _PEViewModel.Students = _department.GetStudentsList();
        }
    }
}
