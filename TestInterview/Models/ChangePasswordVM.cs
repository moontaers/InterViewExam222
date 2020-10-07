using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestInterview.Models
{
    public class ChangePasswordVM
    {
        public string  oldPassword { get; set; }
        public string newPassword { get; set; }
        [Compare(nameof(newPassword), ErrorMessage = "Password  mismatch")]
        public string ConfirmnewPassword { get; set; }
    }
}