using Projekat.Models;
using System.Collections.Generic;

namespace Projekat.ViewModels
{
    public class DodajModulViewModel
    {
        /// <summary>
        /// Gets or sets the smerovi.
        /// </summary>
        /// <value>
        /// The smerovi.
        /// </value>
        public IEnumerable<ModulModel> moduli { get; set; } //Za citanje

        /// <summary>
        /// Gets or sets the predmet.
        /// </summary>
        /// <value>
        /// The predmet.
        /// </value>
        public ModulModel modul { get; set; }

        /// <summary>
        /// Gets or sets the smer ids.
        /// </summary>
        /// <value>
        /// The smer ids.
        /// </value>
        public List<int> modulIds { get; set; } //Za upisivanje u bazu

        /// <summary>
        /// Gets or sets the predmet po smeru.
        /// </summary>
        /// <value>
        /// The predmet po smeru.
        /// </value>
        public IEnumerable<PredmetModel> PredmetPoSmeru { get; set; }

        public IEnumerable<PredmetModel> Predmeti { get; set; }
        public IEnumerable<SmerModel> Smerovi { get; set; }

        public List<SmerModel> SmeroviPoSkolama { get; set; }
        public IEnumerable<SkolaModel> Skole { get; set; }

        public int skolaId { get; set; }
        public int smerId { get; set; }

        /// <summary>
        /// Gets or sets the predmet identifier.
        /// </summary>
        /// <value>
        /// The predmet identifier.
        /// </value>
        public int? predmetId { get; set; }
    }
}