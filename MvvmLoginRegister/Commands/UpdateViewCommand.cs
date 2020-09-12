using MvvmLoginRegister.ViewModels;
using MvvmLoginRegister.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MvvmLoginRegister.Commands
{
    public class UpdateViewCommand : ICommand
    {

        private HomeViewModel viewModel2;
        public UpdateViewCommand(HomeViewModel viewModel2)
        {
            this.viewModel2 = viewModel2;
        }

        private MainViewModel viewModel;
        public UpdateViewCommand(MainViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter.ToString() == "Home")
            {
                viewModel.SelectedViewModel = new HomeViewModel();
            }
            else if (parameter.ToString() == "Account")
            {
                viewModel.SelectedViewModel = new AccountViewModel();
            }
            else if (parameter.ToString() != null)
            {
                viewModel2.TempUser.Password = parameter.ToString();
                if (viewModel2.SearchByName())
                {

                    NotesView win1 = new NotesView();
                    win1.DataContext = new NotesViewModel(viewModel2.TempUser);
                    win1.Show();
                    System.Windows.Application.Current.MainWindow.Close();
                }
            }
        }
    }
}
