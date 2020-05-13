using Projekat.Models;
using System.Collections.Generic;

namespace Projekat.ViewModels
{
    public class DodajSmerViewModel
    {
        /// <summary>
        /// Gets or sets the smer identifier.
        /// </summary>
        /// <value>
        /// The smer identifier.
        /// </value>
        public int smerId { get; set; }

        /// <summary>
        /// Gets or sets the smer name.
        /// </summary>
        /// <value>
        /// The smer name.
        /// </value>
        public string smerNaziv { get; set; }

        /// <summary>
        /// Gets or sets the smer description.
        /// </summary>
        /// <value>
        /// The smer description.
        /// </value>
        public string smerOpis { get; set; }

        /// <summary>
        /// Gets or sets the smer name abbreviated.
        /// </summary>
        /// <value>
        /// The smer name abbreviated.
        /// </value>
        public string smerSkraceno { get; set; }

        /// <summary>
        /// Gets or sets the skola identifier.
        /// </summary>
        /// <value>
        /// The skola identifier.
        /// </value>
        public int skolaId { get; set; }

        /// <summary>
        /// Gets or sets the skola collection.
        /// </summary>
        /// <value>
        /// The skola collection.
        /// </value>
        public List<SkolaModel> skole { get; set; }
    }
}