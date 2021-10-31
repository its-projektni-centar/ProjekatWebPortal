﻿using Projekat.ViewModels;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Projekat.Models
{
    /// <summary>
    /// MaterijalContext class
    /// </summary>
    /// <seealso cref="Projekat.Models.ApplicationDbContext" />
    /// <seealso cref="Projekat.Models.IMaterijalContext" />
    public class MaterijalContext : ApplicationDbContext, IMaterijalContext
    {
        /// <summary>
        /// Gets the queryable data source for materijali.
        /// </summary>
        /// <value>
        /// Queryable selection of MaterijalModel Classes.
        /// </value>
        public DbSet<MaterijalModel> materijali { get; set; }

        /// <summary>
        /// Gets the queryable data source for TipMaterijala.
        /// </summary>
        /// <value>
        /// The queryable selection of TipMaterijala Classes.
        /// </value>
        public DbSet<TipMaterijalModel> tipMaterijala { get; set; }

        /// <summary>
        /// Gets the queryable data source for NamenaMaterijala.
        /// </summary>
        /// <value>
        /// The queryable selection of NamenaMaterijalaModel Classes.
        /// </value>
        public DbSet<NamenaMaterijalaModel> nameneMaterijala { get; set; }

        /// <summary>
        /// Gets the queryable data source for MaterijalPoModulu.
        /// </summary>
        /// <value>
        /// The queryable selection of MaterijalPoModulu Classes.
        /// </value>
        public DbSet<MaterijalPoModulu> materijalPoModulu { get; set; }

        /// <summary>
        /// Gets the queryable data source for ModulModel.
        /// </summary>
        /// <value>
        /// The queryable selection of ModulModel Classes.
        /// </value>
        public DbSet<ModulModel> moduli { get; set; }

        /// <summary>
        /// Gets the queryable data source for predmeti.
        /// </summary>
        /// <value>
        /// The queryable selection of PredmetModelClasses.
        /// </value>
        public DbSet<PredmetModel> predmeti { get; set; }

        /// <summary>
        /// Gets the queryable data source for tipPredmeta.
        /// </summary>
        /// <value>
        /// The queryable selection of tipPredmeta Classes.
        /// </value>
        public DbSet<TipPredmetaModel> tipPredmeta { get; set; }

        /// <summary>
        /// Gets the queryable data source for PredmetiPoSmeru.
        /// </summary>
        /// <value>
        /// The queryable selection of PredmetPoSmeru Classes.
        /// </value>
        public DbSet<PredmetPoSmeru> predmetiPoSmeru { get; set; }

        /// <summary>
        /// Gets the queryable data source for smerovi.
        /// </summary>
        /// <value>
        /// The queryable selection of SmerModel Classes.
        /// </value>
        public DbSet<SmerModel> smerovi { get; set; }

        /// <summary>
        /// Gets the queryable data source for smeroviPoSkolama.
        /// </summary>
        /// <value>
        /// The queryable selection of SmerMSmerPoSkoli Classes.
        /// </value>
        public DbSet<SmerPoSkoli> smeroviPoSkolama { get; set; }

        /// <summary>
        /// Gets the queryable data source for SkolaModel.
        /// </summary>
        /// <value>
        /// The queryable selection of SkolaModel Classes.
        /// </value>
        public DbSet<SkolaModel> Skole { get; set; }

        /// <summary>
        /// Gets the queryable data source for GlobalniZahteviModel.
        /// </summary>
        /// <value>
        /// The queryable selection of GlobalniZahteviModel Classes.
        /// </value>
        public DbSet<GlobalniZahteviModel> globalniZahtevi { get; set; }

        /// <summary>
        /// Gets the queryable data source for Forum_Post.
        /// </summary>
        /// <value>
        /// The queryable selection of Forum_Post Classes.
        /// </value>
        public DbSet<Forum_Post> Forum { get; set; }

        /// <summary>
        /// Gets the queryable data source for Forum_Message.
        /// </summary>
        /// <value>
        /// The queryable selection of Forum_Message Classes.
        /// </value>
        public DbSet<Forum_Message> Message { get; set; }

        //public DbSet<AspNetUser> Users { get; set; }
        //public DbSet<MaterijalProfesorModel> Profesormaterijali { get; set; }

        IQueryable<MaterijalModel> IMaterijalContext.materijali
        {
            get { return materijali; }
        }

        IQueryable<TipMaterijalModel> IMaterijalContext.tipMaterijala
        {
            get { return tipMaterijala; }
        }

        IQueryable<NamenaMaterijalaModel> IMaterijalContext.nameneMaterijala
        {
            get { return nameneMaterijala; }
        }

        IQueryable<MaterijalPoModulu> IMaterijalContext.materijalPoModulu
        {
            get { return materijalPoModulu; }
        }

        IQueryable<ModulModel> IMaterijalContext.moduli
        {
            get { return moduli; }
        }

        IQueryable<PredmetModel> IMaterijalContext.predmeti
        {
            get { return predmeti; }
        }

        IQueryable<TipPredmetaModel> IMaterijalContext.tipPredmeta
        {
            get { return tipPredmeta; }
        }

        IQueryable<PredmetPoSmeru> IMaterijalContext.predmetiPoSmeru
        {
            get { return predmetiPoSmeru; }
        }

        IQueryable<SmerModel> IMaterijalContext.smerovi
        {
            get { return smerovi; }
        }

        IQueryable<SmerPoSkoli> IMaterijalContext.smeroviPoSkolama
        {
            get { return smeroviPoSkolama; }
        }

        IQueryable<SkolaModel> IMaterijalContext.skole
        {
            get { return Skole; }
        }

        IQueryable<GlobalniZahteviModel> IMaterijalContext.globalniZahtevi
        {
            get { return globalniZahtevi; }
        }

        T IMaterijalContext.Add<T>(T entity)
        {
            return Set<T>().Add(entity);
        }

        T IMaterijalContext.Delete<T>(T entity)
        {
            return Set<T>().Remove(entity);
        }

        MaterijalModel IMaterijalContext.pronadjiMaterijalPoId(int id)
        {
            return Set<MaterijalModel>().Find(id);
        }

        MaterijalModel IMaterijalContext.pronadjiMaterijalPoNazivu(string naziv)
        {
            MaterijalModel materijal = (from m in Set<MaterijalModel>()
                                        where m.materijalNaziv == naziv
                                        select m).FirstOrDefault();
            return materijal;
        }

        int IMaterijalContext.SaveChanges()
        {
            return SaveChanges();
        }

        public bool PostojiGlobalni(int? materijalId)
        {
            var globalPredmeti = this.predmeti.Where(x => x.tipId == 2).Select(x => x.predmetId).ToList();
            var globalModuli = this.moduli.Where(x => globalPredmeti.Contains((int)x.predmetId)).Select(x => x.modulId).ToList();

            List<MaterijalPoModulu> materijalPoModulus = this.materijalPoModulu.Where(x => x.materijalId == materijalId && globalModuli.Contains(x.modulId)).ToList();

            if (materijalPoModulus.Count > 0)
            {
                return true;
            }
            return false;
        }
        public bool PostojiGlobalniZahtev(int? materijalId)
        {
            var zahtevi = this.globalniZahtevi.Where(x => x.materijalId == materijalId).ToList();
            if (zahtevi.Count > 0)
            {
                return true;
            }
            return false;
        }

        IQueryable<OsiromaseniMaterijali> IMaterijalContext.poModulu(int? modulId)
        {
            IQueryable<OsiromaseniMaterijali> materijali;

            materijali = from mat in this.materijali
                         select new OsiromaseniMaterijali
                         {
                             namenaID = mat.namenaMaterijalaId,
                             materijalId = mat.materijalId,
                             ekstenzija = mat.materijalEkstenzija,
                             materijalNaslov = mat.materijalNaslov,
                             materijalOpis = mat.materijalOpis,
                             tipMaterijalaId = mat.tipMaterijalId
                         };

            if (modulId != null)
            {
                materijali = from mat in this.materijali
                             join matPoMod in this.materijalPoModulu
                             on mat.materijalId equals matPoMod.materijalId
                             where matPoMod.modulId == modulId
                             select new OsiromaseniMaterijali
                             {
                                 namenaID = mat.namenaMaterijalaId,
                                 materijalId = mat.materijalId,
                                 ekstenzija = mat.materijalEkstenzija,
                                 materijalNaslov = mat.materijalNaslov,
                                 materijalOpis = mat.materijalOpis,
                                 tipMaterijalaId = mat.tipMaterijalId,
                                 modulId = modulId
                             };
            }

            return materijali;
        }

        IQueryable<OsiromaseniMaterijali> IMaterijalContext.nacekanju()
        {
            IQueryable<OsiromaseniMaterijali> materijali;
            materijali = this.materijali.Where(m => m.odobreno == null).Select(m => new OsiromaseniMaterijali
            {
                namenaID = m.namenaMaterijalaId,
                materijalId = m.materijalId,
                ekstenzija = m.materijalEkstenzija,
                materijalNaslov = m.materijalNaslov,
                materijalOpis = m.materijalOpis,
                tipMaterijalaId = m.tipMaterijalId,
            });
            return materijali;
        }

        IQueryable<OsiromaseniMaterijali> IMaterijalContext.naprednaPretraga(List<string> ekstenzije, List<int> tipoviMaterijalaIds, int? modulId, int namenaID)//Dodati parametre
        {
            IMaterijalContext context = new MaterijalContext();
            // && (a => tipoviMaterijalaIds.Any(s => a.tipMaterijalaId)
            if (namenaID == 2)
            {
                IQueryable<OsiromaseniMaterijali> materijali2;

                materijali2 = from mat in this.materijali
                              where mat.namenaMaterijalaId == 2
                              select new OsiromaseniMaterijali
                              {
                                  namenaID = mat.namenaMaterijalaId,
                                  materijalId = mat.materijalId,
                                  ekstenzija = mat.materijalEkstenzija,
                                  materijalNaslov = mat.materijalNaslov,
                                  materijalOpis = mat.materijalOpis,
                                  tipMaterijalaId = mat.tipMaterijalId
                              };

                return materijali2;
            }

            var queriable = context.poModulu(modulId);
            queriable = poNameni(namenaID, queriable);

            if (ekstenzije != null && tipoviMaterijalaIds != null)
            {
                queriable = queriable.
                   Where(a => ekstenzije.Any(s => a.ekstenzija.Contains(s)));

                queriable = queriable.
                    Where(a => tipoviMaterijalaIds.Any(s => a.tipMaterijalaId.ToString().Contains(s.ToString())));

                return queriable;
            }
            else if (ekstenzije == null && tipoviMaterijalaIds != null)
            {
                queriable = queriable.
                Where(a => tipoviMaterijalaIds.Any(s => a.tipMaterijalaId.ToString().Contains(s.ToString())));

                return queriable;
            }
            else if (ekstenzije != null && tipoviMaterijalaIds == null)
            {
                queriable = queriable.
                Where(a => ekstenzije.Any(s => a.ekstenzija.Contains(s)));

                return queriable;
            }
            else
                return queriable;
        }

        public IQueryable<OsiromaseniMaterijali> poNameni(int namenaID, IQueryable<OsiromaseniMaterijali> materijali)
        {
            materijali = materijali.Where(m => m.namenaID == namenaID).Select(m => new OsiromaseniMaterijali
            {
                namenaID = m.namenaID,
                materijalId = m.materijalId,
                ekstenzija = m.ekstenzija,
                materijalNaslov = m.materijalNaslov,
                materijalOpis = m.materijalOpis,
                tipMaterijalaId = m.tipMaterijalaId,
                modulId = m.modulId
            });

            return materijali;
        }
    }
}