﻿using Microsoft.AspNetCore.Identity;

namespace IdentityExampleProject.UI.CustomValidations
{
    public class CustomIdentityErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError DuplicateUserName(string userName)
        {
            return new IdentityError { Code = "DuplicateUserName", Description = $"\"{userName}\" kullanıcı adı kullanılmaktadır." };
        }

        public override IdentityError InvalidUserName(string? userName)
        {
            return new IdentityError { Code = "InvalidUserName", Description = "Geçersiz kullanıcı adı." };
        }

        public override IdentityError DuplicateEmail(string email)
        {
            return new IdentityError { Code = "DuplicateEmail", Description = $"\"{email}\" başka bir kullanıcı tarafından kullanılmaktadır." };
        }

        public override IdentityError InvalidEmail(string? email)
        {
            return new IdentityError { Code = "InvalidEmail", Description = "Geçersiz email." };
        }
    }
}
