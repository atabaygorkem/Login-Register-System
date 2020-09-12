using MvvmLoginRegister.Commands;
using MvvmLoginRegister.Models;
using MvvmLoginRegister.Validation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
//using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FluentValidation;
using FluentValidation.Results;

namespace MvvmLoginRegister.ViewModels
{
    public class AccountViewModel : BaseViewModel
    {
        UserService ObjUserService;
        public AccountViewModel()
        {
            ObjUserService = new UserService();
            LoadData();
            CurrentUser = new UserDTO();
            saveCommand2 = new RelayCommand(Save, this);
        }

        private ObservableCollection<UserDTO> usersList;
        public ObservableCollection<UserDTO> UsersList
        {
            get { return usersList; }
            set { usersList = value; OnPropertyChanged("UsersList"); }
        }

        private void LoadData()
        {
            UsersList = ObjUserService.GetAll();
        }

        private UserDTO currentUser;
        public UserDTO CurrentUser
        {
            get { return currentUser; }
            set { currentUser = value; OnPropertyChanged("CurrentUser"); }
        }

        private string message;
        public string Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged("Message"); }
        }

        private RelayCommand saveCommand2;
        public RelayCommand SaveCommand2
        {
            get { return saveCommand2; }
        }

        public void Save()
        {
            if (UserNameExist())
            {
                CurrentUser = new UserDTO(); Message = "Username Exist"; return;
            }
            bool IsSaved = false;

            UserValidation validator = new UserValidation(CurrentUser);
            ValidationResult results = validator.Validate(CurrentUser);

            if (!results.IsValid)
            {
                Message = results.Errors[0].ToString();
            }
            else
            {
                IsSaved = ObjUserService.Add(CurrentUser);
                LoadData();
            }
            CurrentUser = new UserDTO();
            if (IsSaved)
                Message = "User saved";

        }

        public bool UserNameExist()
        {
            bool isValid = false;
            foreach (var item in UsersList)
            {
                if (CurrentUser.UserName == item.UserName)
                {
                    isValid = true;
                    break;
                }
                else
                    isValid = false;
            }
            return isValid;
        }
    }
}
