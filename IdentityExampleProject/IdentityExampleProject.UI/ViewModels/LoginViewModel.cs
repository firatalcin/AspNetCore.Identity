﻿using System.ComponentModel.DataAnnotations;

namespace IdentityExampleProject.UI.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Lütfen e-posta adresini boş geçmeyiniz.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Lütfen uygun formatta e-posta adresi giriniz.")]
        [Display(Name = "E-Posta ")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Lütfen şifreyi boş geçmeyiniz.")]
        [DataType(DataType.Password, ErrorMessage = "Lütfen uygun formatta şifre giriniz.")]
        [Display(Name = "Şifre")]
        public string Password { get; set; }
        /// <summary>
        /// Beni hatırla...
        /// </summary>
        [Display(Name = "Beni Hatırla")]
        public bool Persistent { get; set; }
        public bool Lock { get; set; }
    }
}
