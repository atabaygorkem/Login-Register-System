using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MvvmLoginRegister.Models
{
    public class UserDTO : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public UserDTO() { }
        public UserDTO(string userName, string password, int id)
        {
            this.password = password;
            this.userName = userName;
            this.id = id;
        }

        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged("Id"); }
        }

        private string userName;
        public string UserName
        {
            get { return userName; }
            set { userName = value; OnPropertyChanged("UserName"); }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; OnPropertyChanged("Password"); }
        }
    }
}
