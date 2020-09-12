using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MvvmLoginRegister.Models
{
    public class UserService
    {
        private static ObservableCollection<UserDTO> ObjUserList;
        MvvmDemoDbEntities ObjContext;
        public UserService()
        {
            ObjContext = new MvvmDemoDbEntities();
        }

        public ObservableCollection<UserDTO> GetAll()
        {
            ObservableCollection<UserDTO> ObjUserList = new ObservableCollection<UserDTO>();
            try
            {
                var ObjQuery = from user in ObjContext.Users
                               select user;
                foreach (var user in ObjQuery)
                {
                    ObjUserList.Add(new UserDTO(user.UserName, user.Password, user.Id));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjUserList;
        }

        public bool Add(UserDTO objNewUser)
        {
            bool IsAdded = false;
            if (objNewUser.Id > 1000) throw new ArgumentException("Short pw");

            try
            {
                var ObjUser = new User();
                ObjUser.Id = objNewUser.Id;
                ObjUser.UserName = objNewUser.UserName;
                ObjUser.Password = objNewUser.Password;
                ObjContext.Users.Add(ObjUser);
                var NoOfRowsAffected = ObjContext.SaveChanges();
                IsAdded = NoOfRowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return IsAdded;
        }
    }
}
