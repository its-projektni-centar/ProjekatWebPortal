using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekat.Models
{
    public class SmerPoSkoli
    {
        /// <summary>
        /// Gets or sets the skola identifier.
        /// </summary>
        /// <value>
        /// The skola identifier.
        /// </value>
        [Key, ForeignKey("SkolaModel"), Column(Order = 0)]
        public int skolaId { get; set; }

        /// <summary>
        /// Gets or sets the smer identifier.
        /// </summary>
        /// <value>
        /// The smer identifier.
        /// </value>
        [Key, ForeignKey("SmerModel"), Column(Order = 1)]
        public int smerId { get; set; }

        /// <summary>
        /// Gets or sets the skola model.
        /// </summary>
        /// <value>
        /// The skola model.
        /// </value>
        public SkolaModel SkolaModel { get; set; }

        /// <summary>
        /// Gets or sets the smer model.
        /// </summary>
        /// <value>
        /// The smer model.
        /// </value>
        public SmerModel SmerModel { get; set; }
    }
}