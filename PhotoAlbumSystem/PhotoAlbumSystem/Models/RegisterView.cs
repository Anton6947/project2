﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoAlbumSystem.Models
{
    public class RegisterView
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name ="Cofirm password")]
        [Compare("Password",
               ErrorMessage = "Password and Cofirmation password do not match.")]
        public string ConfirmPassword { get; set; }




    }
}