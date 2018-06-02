using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace EverPresent.Models
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

        [Display(Name = "Family", Description = "Mogwai Family")]
        [Required(ErrorMessage = "Mogwai Family is required")]
        public string Family { get; set; }

        [Display(Name = "Description", Description = "Mogwai Description")]
        [Required(ErrorMessage = "Mogwai Description is required")]
        public string Description { get; set; }

        [Display(Name = "Cost", Description = "Mogwai Cost")]
        [Required(ErrorMessage = "Mogwai Cost is required")]
        public int Cost { get; set; }

        [Display(Name = "Rarity Level", Description = "Mogwai Rarity Level")]
        [Required(ErrorMessage = "Mogwai rarity is required")]
        public int Rarity { get; set; }

        [Display(Name = "Level", Description = "Mogwai level")]
        [Required(ErrorMessage = "Mogwai level is required")]
        public int Level { get; set; }

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
        /// <param name="uri">Image for the Mogwai</param>
        /// <param name="name">Name of the Mogwai</param>
        /// <param name="family">Family of the Mogwai</param>
        /// <param name="cost">Token cost of Mogwai</param>
        /// <param name="rarity">Rarity level of Mogwai (1 common, 5 rare) </param>
        public MogwaiModel(string uri, string name, string family, int cost, int rarity, int level)
        {
            Initialize();

            Uri = uri;
            Name = name;
            Family = family;
            Cost = cost;
            Rarity = rarity;
            Level = level;
            Description = "Mogwai are cute little aliens";
        }
    }
}