using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projekat.Models
{
    /// <summary>
    /// SmerModel class
    /// </summary>
    public class SmerModel
    {
        /// <summary>
        /// Gets or sets the smer identifier.
        /// </summary>
        /// <value>
        /// The smer identifier.
        /// </value>
        [Key]
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
        public string nazivFajlIts { get; set; }
        [MaxLength]
        public byte[] fajlIts { get; set; }
        [HiddenInput(DisplayValue =false)]
        public string fileMimeTypeIts { get; set; }
        public string fileEkstenzijaIts { get; set; }
        public string nazivFajlNs { get; set; }
        [MaxLength]
        public byte[] fajlNs { get; set; }
        [HiddenInput(DisplayValue = false)]
        public string fileMimeTypeNs { get; set; }
        public string fileEkstenzijaNs { get; set; }
        [MaxLength]
        public byte[] fajlMs { get; set; }
        [HiddenInput(DisplayValue = false)]
        public string fileMimeTypeMs { get; set; }
        public string fileEkstenzijaMs { get; set; }
        public string nazivFajlMs { get; set; }
        /// <summary>
        /// Gets the queryable data source for Smerovi.
        /// </summary>
        /// <value>
        /// Queryable selection of SmerModel Classes.
        /// </value>
        public IEnumerable<SmerModel> smerovi { get; set; }//ovo mozda napravi problem
        public string smerSkraceno { get; set; }
    }
}