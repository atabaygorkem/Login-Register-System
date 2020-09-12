using MvvmLoginRegister.Commands;
using MvvmLoginRegister.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MvvmLoginRegister.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        UserService ObjUserService;
        public ICommand UpdateViewCommand2 { get; set; }//property
        public HomeViewModel()
        {
            ObjUserService = new UserService();
            TempUsersList = ObjUserService.GetAll();
            tempUser = new UserDTO();
            UpdateViewCommand2 = new UpdateViewCommand(this);

        }

        private UserDTO tempUser;
        public UserDTO TempUser
        {
            get { return tempUser; }
            set { tempUser = value; OnPropertyChanged("TempUser"); }
        }

        private ObservableCollection<UserDTO> tempUsersList;
        public ObservableCollection<UserDTO> TempUsersList
        {
            get { return tempUsersList; }
            set { tempUsersList = value; OnPropertyChanged("TempUsersList"); }
        }

        public bool SearchByName()
        {
            bool isValid = false;
            foreach (var item in tempUsersList)
            {
                if (tempUser.UserName == item.UserName && tempUser.Password == item.Password)
                {
                    isValid = true;
                    tempUser.Id = item.Id;
                    break;
                }
                else
                    isValid = false;
            }
            return isValid;
        }
    }
}
