using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

#nullable enable
namespace UserRegistrationAPI.Models

{
    public class User
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required(ErrorMessage = "FirstName is required")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "LastName is required")]
        public string? LastName { get; set; }

       
        [Remote("IsExist", "Place", ErrorMessage = "Username exist!")]
        public string? UserName { get; set; }

       
        public string? AccountNumber { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        [Remote("IsExist", "Place", ErrorMessage = "URL exist!")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;


        public DateTime ModifyDate { get; set; } = DateTime.Now;

   

    }


}

