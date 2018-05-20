using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _5051.Models
{
    /// <summary>
    /// View Model for the Mogwai Views to have the list of Mogwais
    /// </summary>
    public class MogwaiViewModel
    {
        /// <summary>
        /// The List of Mogwai
        /// </summary>
        public List<MogwaiModel> MogwaiList = new List<MogwaiModel>();
    }
}