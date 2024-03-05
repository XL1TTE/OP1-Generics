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
    public class RemovePEStudentCommand: CommandBase
    {
        public PEViewModel _PEViewModel;
        public Department<PEStudent> _department;
        public RemovePEStudentCommand(PEViewModel PEViewModel)
        {
            _PEViewModel = PEViewModel;
            _department = PEViewModel.PEDepartment;
        }

        public override void Execute(object? parameter)
        {
            foreach (var item in _department._studentsList)
            {
                if (item.FIO == _PEViewModel.Name && item.SportDiscipline == _PEViewModel.Discipline)
                {
                    _department.ExpelStudent(item);
                }
            }
            _PEViewModel.Students = _department.GetStudentsList();
        }
    }
}
