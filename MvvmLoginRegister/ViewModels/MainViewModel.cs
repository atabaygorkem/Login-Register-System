using System;
using System.Collections.Generic;
using MvvmLoginRegister.Commands;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MvvmLoginRegister.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public ICommand UpdateViewCommand { get; set; }
        public MainViewModel()
        {
            UpdateViewCommand = new UpdateViewCommand(this);
        }

        private BaseViewModel _selectedViewModel;
        public BaseViewModel SelectedViewModel
        {
            get { return _selectedViewModel; }
            set
            {
                _selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }
    }
}
