using Projekat.Models;
using System.Collections.Generic;

namespace Projekat.ViewModels
{
    /// <summary>
    /// Dodaj predmet view model
    /// </summary>
    public class DodajPremetViewModel
    {
        /// <summary>
        /// Gets or sets the predmet.
        /// </summary>
        /// <value>
        /// The predmet.
        /// </value>
        public PredmetModel predmet { get; set; }

        /// <summary>
        /// Gets or sets the materijalTipId.
        /// </summary>
        /// <value>
        /// The predmet.
        /// </value>
        public TipPredmetaModel tipPred { get; set; }

        /// <summary>
        /// Gets or sets the tipovi.
        /// </summary>
        /// <value>
        /// The predmet.
        /// </value>
        public IEnumerable<TipPredmetaModel> tipoviPredmeta { get; set; } //Za citanje

        /// <summary>
        /// Gets or sets the smer ids.
        /// </summary>
        /// <value>
        /// The smer ids.
        /// </value>
        public List<int> smerIds { get; set; } //Za upisivanje u bazu

        /// <summary>
        /// Gets or sets the smerovi.
        /// </summary>
        /// <value>
        /// The smerovi.
        /// </value>
        public IEnumerable<SmerModel> smerovi { get; set; } //Za citanje

        /// <summary>
        /// Gets or sets the skola ids.
        /// </summary>
        /// <value>
        /// The skola ids.
        /// </value>
        public int skolaId { get; set; } //Za upisivanje u bazu

        /// <summary>
        /// Gets or sets the smerovi.
        /// </summary>
        /// <value>
        /// The smerovi.
        /// </value>
        public IEnumerable<SkolaModel> skole { get; set; } //Za citanje

        /// <summary>
        /// Gets or sets the tipIds.
        /// </summary>
        /// <value>
        /// The tipIds.
        /// </value>
        public List<int> tipIds { get; set; } //Za upisivanje u bazu

        /// <summary>
        /// Gets or sets the tipPredmetas.
        /// </summary>
        /// <value>
        /// The tipPredmetas.
        /// </value>
        public TipPredmetaModel tipId { get; set; }

        /// <summary>
        /// Gets or sets the tips.
        /// </summary>
        /// <value>
        /// The tip.
        /// </value>
        public int tip { get; set; }
    }
}