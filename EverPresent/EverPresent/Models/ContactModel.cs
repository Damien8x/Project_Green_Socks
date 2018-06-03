using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using EverPresent.Models.Enums;
using EverPresent.Backend;

namespace EverPresent.Models
{
    public class ContactModel
    {
        /// <summary>
        /// Model Id (unique key) tracks message Id for reference
        /// </summary>
        [Key]
        [Display(Name = "Id", Description = "Message Id")]
        [Required(ErrorMessage = "Id is required")]
        public string Id { get; set; }

        /// <summary>
        /// Used to store value of user's name for submitted messages
        /// </summary>
        [Display(Name = "Name", Description = "Sender's Name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        /// <summary>
        /// Store's user email for Admin response to user
        /// </summary>
        [Display(Name = "Email", Description = "Sender's Email")]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        /// <summary>
        /// Holds value of user's message on contact form
        /// </summary>
        [Display(Name = "Message", Description = "Sender's Message")]
        [Required(ErrorMessage = "Message is required")]
        public string Message { get; set; }

        /// <summary>
        /// Default Constructor for ContactModel
        /// </summary>
        public ContactModel() {
            this.Id = "1";
            this.Name = "";
            this.Email = "";
            this.Message = "";
        }

        /// <summary>
        /// ContactModel Constructor. Accepts parameters for all Model attributes
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="message"></param>
        public ContactModel(string id, string name, string email, string message)
        {
            this.Id = id;
            this.Name = name;
            this.Email = email;
            this.Message = message;
        }
    }
}