using MvvmLoginRegister.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MvvmLoginRegister.Commands
{
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Action DoWork;
        public RelayCommand(Action work)
        {
            DoWork = work;
        }

        public AccountViewModel aVM = null;
        public RelayCommand(Action work, AccountViewModel aVModel)
        {
            aVM = aVModel;
            DoWork = work;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            if (aVM != null)
                aVM.CurrentUser.Password = parameter.ToString();
            DoWork();
        }
    }
}
