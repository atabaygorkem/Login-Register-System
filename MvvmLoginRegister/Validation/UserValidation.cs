using FluentValidation;
using MvvmLoginRegister.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MvvmLoginRegister.Validation
{

    public class UserValidation : AbstractValidator<UserDTO>
    {
        public UserValidation(UserDTO user)
        {

            RuleFor(uName => user.UserName).NotNull().WithMessage("Please enter an username");
            RuleFor(uName => user.UserName).Length(2, 30).WithMessage("Your username must be between 2 and 30 characters");
            RuleFor(uName => user.UserName).Must(UserSpecialCharControl).WithMessage("Invalid username");

            RuleFor(uPassword => user.Password).NotNull().WithMessage("Please enter a password");
            RuleFor(uPassword => user.Password).Length(6, 30).WithMessage("Your password must be between 6 and 30 characters");
            RuleFor(uPassword => user.Password).Must(PwSpecialCharControl).WithMessage("Invalid password");
            RuleFor(uPassword => user.Password).Must(PwControl).WithMessage("Password must contain at least 1 uppercase character, lowercase character and digit");
            
        }

        private bool UserSpecialCharControl(string user)
        {
            var specialCharacterPattern = new Regex("^[a-z0-9]*$");
            if (user != null)
                if (specialCharacterPattern.IsMatch(user))
                    return true;
            return false;
        }

        private bool PwSpecialCharControl(string pw)
        {
            var PwSpecialCharacterPattern = new Regex("^[a-zA-Z0-9]*$");
            if (pw != null)
                if (PwSpecialCharacterPattern.IsMatch(pw))
                    return true;
            return false;
        }

        private bool PwControl(string pw)
        {
            var PwControlPattern = new Regex(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{6,30}$");

            if (pw != null)
                if (PwControlPattern.IsMatch(pw))
                    return true;
            return false;
        }
    }
}
