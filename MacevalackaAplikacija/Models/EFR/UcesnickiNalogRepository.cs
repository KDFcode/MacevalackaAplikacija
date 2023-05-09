using MacevalackaAplikacija.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MacevalackaAplikacija.Models.EFR
{
    public class UcesnickiNalogRepository : IUcesnickiNalogRepository
    {



        private turnirskoNova2Entities turnirskiEntities = new turnirskoNova2Entities();


        private DisciplinaBO mapiramDiscipline(Disciplina disciplina)
        {
            DisciplinaBO disciplinaBO = new DisciplinaBO { DiscID = disciplina.DisciplinaID, DiscNaziv = disciplina.NazivDiscip };
            return disciplinaBO;
        }//mapiramDiscipline()

        private FazaBO mapiramFaze(FazaTakmicenja faza)
        {
            FazaBO fazaBO = new FazaBO { FazaTakmicenjaID = faza.FazaTakmicenjaID, NazivFazeTakmicenja = faza.NazivFaze };
            return fazaBO;
        }//mapiramFaze()

        private UcesnickiNalogBO mapiram(UcesnickiNalog ucesnik)
        {
            UcesnickiNalogBO ucesnickiNalogBO = new UcesnickiNalogBO { ucesnikID = ucesnik.UcesnickiNalogID, ImePrezime = ucesnik.ImePrezime, Klub = ucesnik.Klub, Uloga = ucesnik.Uloga, Disciplina = mapiramDiscipline(ucesnik.Disciplina), faza = mapiramFaze(ucesnik.FazaTakmicenja) };
            return ucesnickiNalogBO;

        }//mapiram() 
       


        public IEnumerable<UcesnickiNalogBO> GetAll()
        {
            List<UcesnickiNalogBO> ucesnici = new List<UcesnickiNalogBO>();
            foreach (UcesnickiNalog ucesnik in turnirskiEntities.UcesnickiNalog)
            {
                ucesnici.Add(mapiram(ucesnik));
            }
            return ucesnici;
        }//GetAll()

        public IEnumerable<FazaBO> GetAllFaze()
        {
            List<FazaBO> faze = new List<FazaBO>();
            foreach (FazaTakmicenja faza in turnirskiEntities.FazaTakmicenja)
            {
                faze.Add(mapiramFaze(faza));
            }
            return faze;
        }//GetAllFaze()

        public IEnumerable<DisciplinaBO> GetAllDiscipline()
        {
            List<DisciplinaBO> discipline = new List<DisciplinaBO>();
            foreach (Disciplina disciplina in turnirskiEntities.Disciplina)
            {
                discipline.Add(mapiramDiscipline(disciplina));
            }
            return discipline;
        }//GetAllDiscipline()

        public void Add(UcesnickiNalogBO ucesnikNoviBo)
        {
            var Disc = turnirskiEntities.Disciplina.FirstOrDefault(t => t.DisciplinaID == ucesnikNoviBo.Disciplina.DiscID);

            var faza = turnirskiEntities.FazaTakmicenja.FirstOrDefault(t => t.FazaTakmicenjaID == ucesnikNoviBo.faza.FazaTakmicenjaID);


            UcesnickiNalog ucesnikNovi = new UcesnickiNalog()
            {
                ImePrezime = ucesnikNoviBo.ImePrezime,
                Klub = ucesnikNoviBo.Klub,
                Uloga = ucesnikNoviBo.Uloga,
                DisciplinaID = ucesnikNoviBo.Disciplina.DiscID,
                FazaTakmicenjaID = ucesnikNoviBo.faza.FazaTakmicenjaID
            };

            
            turnirskiEntities.UcesnickiNalog.Add(ucesnikNovi);
            turnirskiEntities.SaveChanges();
        }//Add()

        public void Delete(UcesnickiNalogBO ucesnikBo)
        {
            UcesnickiNalog ucesnikZaBrisanje = turnirskiEntities.UcesnickiNalog.FirstOrDefault(t => t.UcesnickiNalogID == ucesnikBo.ucesnikID);
            if (ucesnikZaBrisanje == null) return;

            turnirskiEntities.UcesnickiNalog.Remove(ucesnikZaBrisanje);
            try
            {
                turnirskiEntities.SaveChanges();

            }
            catch (Exception e)
            {
                Console.WriteLine("Ucesnik nije uspesno obrisana: " + e);

            }
        }//Delete()


        public void Update(UcesnickiNalogBO ucesnikZaIzmenuBo)
        {
            UcesnickiNalog ucesnikZaIzmenu = turnirskiEntities.UcesnickiNalog.FirstOrDefault(t => t.UcesnickiNalogID == ucesnikZaIzmenuBo.ucesnikID);
            if (ucesnikZaIzmenu == null) return;
            ucesnikZaIzmenu.ImePrezime = ucesnikZaIzmenuBo.ImePrezime;
            ucesnikZaIzmenu.Klub = ucesnikZaIzmenuBo.Klub;
            ucesnikZaIzmenu.Uloga = ucesnikZaIzmenuBo.Uloga;




            Disciplina disciplina = turnirskiEntities.Disciplina.FirstOrDefault(t => t.DisciplinaID == ucesnikZaIzmenuBo.Disciplina.DiscID);
            ucesnikZaIzmenu.Disciplina = disciplina;


            FazaTakmicenja faza = turnirskiEntities.FazaTakmicenja.FirstOrDefault(t => t.FazaTakmicenjaID == ucesnikZaIzmenuBo.faza.FazaTakmicenjaID);
            ucesnikZaIzmenu.FazaTakmicenja = faza;


            try
            {
                turnirskiEntities.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Neuspesan update ucesnika: " + e);
            }

        }//Update()

        public UcesnickiNalogBO DajPoID(int ucesnikID)
        {
            UcesnickiNalogBO trazeniUcesnik = new UcesnickiNalogBO();
            foreach (UcesnickiNalog ucesnik in turnirskiEntities.UcesnickiNalog.Where(t => t.UcesnickiNalogID == ucesnikID))
            {

                trazeniUcesnik.ImePrezime = ucesnik.ImePrezime;
                trazeniUcesnik.Klub = ucesnik.Klub;
                trazeniUcesnik.Uloga = ucesnik.Uloga;
                trazeniUcesnik.ucesnikID = ucesnik.UcesnickiNalogID;

                trazeniUcesnik.Disciplina = mapiramDiscipline(ucesnik.Disciplina);
                trazeniUcesnik.faza = mapiramFaze(ucesnik.FazaTakmicenja);

            }
            return trazeniUcesnik;
        }//DajPoID()

    }
}