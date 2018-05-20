using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace _5051.Models
{
    /// <summary>
    /// Mogwai for the system
    /// </summary>
    public class MogwaiModel
    {
        [Display(Name = "Id", Description = "Mogwai Id")]
        [Required(ErrorMessage = "Id is required")]
        public string Id { get; set; }

        [Display(Name = "Uri", Description = "Picture to Show")]
        [Required(ErrorMessage = "Picture is required")]
        public string Uri { get; set; }

        [Display(Name = "Name", Description = "Mogwai Name")]
        [Required(ErrorMessage = "Mogwai Name is required")]
        public string Name { get; set; }

        [Display(Name = "Description", Description = "Mogwai Description")]
        [Required(ErrorMessage = "Mogwai Description is required")]
        public string Description { get; set; }

        /// <summary>
        /// Create the default values
        /// </summary>
        public void Initialize()
        {
            Id = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// New Mogwai
        /// </summary>
        public MogwaiModel()
        {
            Initialize();
        }

        /// <summary>
        /// Make an Mogwai from values passed in
        /// </summary>
        /// <param name="uri">The Picture path</param>
        /// <param name="name">Mogwai Name</param>
        /// <param name="description">Mogwai Description</param>
        public MogwaiModel(string uri, string name, string description)
        {
            Initialize();

            Uri = uri;
            Name = name;
            Description = description;
        }
    }
}