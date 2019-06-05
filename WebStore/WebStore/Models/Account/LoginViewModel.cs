using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WebStore.DomainNew.Entities.Base.Interfaces;

namespace WebStore.Models.Account
{
    public class LoginViewModel
    {
        [Required, MaxLength(256)]
        public string UserName { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        //[Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Запомнить на сайте")]
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}
