using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace EverPresent.Models
{
    public class StudnetModel
    {
        /// <summary>
        /// The ID for the Student, this is the key, and a required field
        /// </summary>
        [Key]
        [Display(Name = "Id", Description = "Student Id")]
        [Required(ErrorMessage = "Id is required")]
        public string Id { get; set; }

        /// <summary>
        /// The Friendly name for the student, does not need to be directly associated with the actual student name
        /// </summary>
        [Display(Name = "Name", Description = "Nick Name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        /// <summary>
        /// The ID of the Avatar the student is associated with, this will convert to an avatar picture
        /// </summary>
        [Display(Name = "AvatarId", Description = "Avatar")]
        [Required(ErrorMessage = "Avatar is required")]
        public string AvatarId { get; set; }

        /// <summary>
        /// The status of the student, for example currently logged in, out
        /// </summary>
        [Display(Name = "Current Status", Description = "Status of the Student")]
        [Required(ErrorMessage = "Status is required")]
        public StudentStatusEnum Status { get; set; }


    }
}