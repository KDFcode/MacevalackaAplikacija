using MacevalackaAplikacija.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MacevalackaAplikacija.Models.EFR
{
    public class DisciplinaRepository : IDisciplinaRepository
    {


        private turnirskoNova2Entities turnirskiEntities = new turnirskoNova2Entities();



        private DisciplinaBO mapiram(Disciplina disciplina)
        {
            DisciplinaBO disciplinaBO = new DisciplinaBO { DiscID = disciplina.DisciplinaID, DiscNaziv = disciplina.NazivDiscip };
            return disciplinaBO;
        }//mapiram()


        private FazaBO mapiramFaze(FazaTakmicenja faza)
        {
            FazaBO fazaBO = new FazaBO { FazaTakmicenjaID = faza.FazaTakmicenjaID, NazivFazeTakmicenja = faza.NazivFaze };
            return fazaBO;
        }//mapiram()

        private UcesnickiNalogBO mapiramUcesnike(UcesnickiNalog ucesnik)
        {
            UcesnickiNalogBO ucesnickiNalogBO = new UcesnickiNalogBO { ucesnikID = ucesnik.UcesnickiNalogID, ImePrezime = ucesnik.ImePrezime, Klub = ucesnik.Klub, Uloga = ucesnik.Uloga, Disciplina = mapiram(ucesnik.Disciplina), faza = mapiramFaze(ucesnik.FazaTakmicenja) };
            return ucesnickiNalogBO;

        }//mapiramUcesnika() 

        public IEnumerable<DisciplinaBO> GetAll()
        {
            List<DisciplinaBO> discipline = new List<DisciplinaBO>();
            foreach (Disciplina disciplina in turnirskiEntities.Disciplina)
            {
                discipline.Add(mapiram(disciplina));
            }
            return discipline;
        }//GetAll()
        public void Add(DisciplinaBO disciplinaNovaBo)
        {
            Disciplina disciplinaNova = new Disciplina();
            disciplinaNova.NazivDiscip = disciplinaNovaBo.DiscNaziv;
            
            turnirskiEntities.Disciplina.Add(disciplinaNova);
            turnirskiEntities.SaveChanges();
        }//Add()

        public DisciplinaBO DajPoID(int disciplinaID)
        {

            DisciplinaBO disciplinaTrazena = new DisciplinaBO();
            foreach (Disciplina disciplina in turnirskiEntities.Disciplina.Where(t => t.DisciplinaID == disciplinaID))
            {

                disciplinaTrazena.DiscNaziv = disciplina.NazivDiscip;
                disciplinaTrazena.DiscID = disciplina.DisciplinaID;

            }
            return disciplinaTrazena;
            List<UcesnickiNalogBO> trazeniUcesnici = new List<UcesnickiNalogBO>();
            UcesnickiNalogBO trazeniUcesnik = new UcesnickiNalogBO();
            foreach (UcesnickiNalog ucesnik in turnirskiEntities.UcesnickiNalog.Where(t => t.DisciplinaID == disciplinaID))
            {
                trazeniUcesnik.ucesnikID = ucesnik.UcesnickiNalogID;
                trazeniUcesnik.ImePrezime = ucesnik.ImePrezime;
                trazeniUcesnik.faza.NazivFazeTakmicenja = ucesnik.FazaTakmicenja.NazivFaze;
                trazeniUcesnik.Disciplina.DiscNaziv = ucesnik.Disciplina.NazivDiscip;
                trazeniUcesnik.Klub = ucesnik.Klub;
                trazeniUcesnik.Uloga = ucesnik.Uloga;
                trazeniUcesnici.Add(trazeniUcesnik);
            }



        }//DajPoID()


        public IEnumerable<UcesnickiNalogBO> DajSveUcesnikePoDiscID( int disciplinaID)
        {

            DisciplinaBO disciplinaTrazena = new DisciplinaBO();
            foreach (Disciplina disciplina in turnirskiEntities.Disciplina.Where(t => t.DisciplinaID == disciplinaID))
            {

                disciplinaTrazena.DiscNaziv = disciplina.NazivDiscip;
                disciplinaTrazena.DiscID = disciplina.DisciplinaID;

            }


            List<UcesnickiNalogBO> trazeniUcesnici = new List<UcesnickiNalogBO>();
            
            foreach (UcesnickiNalog ucesnik in turnirskiEntities.UcesnickiNalog.Where(t => t.DisciplinaID == disciplinaID))
            {
                UcesnickiNalogBO trazeniUcesnik = new UcesnickiNalogBO();

                trazeniUcesnik.ucesnikID = ucesnik.UcesnickiNalogID;
                trazeniUcesnik.ImePrezime = ucesnik.ImePrezime;
                trazeniUcesnik.Klub = ucesnik.Klub;
                trazeniUcesnik.Uloga = ucesnik.Uloga;
                trazeniUcesnici.Add(trazeniUcesnik);
            }
            return trazeniUcesnici;
        }//DajSveUcesnikePoDiscID()
        //_ListVerzija


        //public IEnumerable<UcesnickiNalogBO> DajSveUcesnikePoDiscID_QueueVerzija(int disciplinaID)
        //{

        //    DisciplinaBO disciplinaTrazena = new DisciplinaBO();
        //    foreach (Disciplina disciplina in turnirskiEntities.Disciplina.Where(t => t.DisciplinaID == disciplinaID))
        //    {

        //        disciplinaTrazena.DiscNaziv = disciplina.NazivDiscip;
        //        disciplinaTrazena.DiscID = disciplina.DisciplinaID;

        //    }

        //    Queue<UcesnickiNalogBO> trazeniUcesnici = new Queue<UcesnickiNalogBO>();



        //    UcesnickiNalogBO trazeniUcesnik = new UcesnickiNalogBO();
        //    foreach (UcesnickiNalog ucesnik in turnirskiEntities.UcesnickiNalog.Where(t => t.DisciplinaID == disciplinaID))
        //    {
        //        trazeniUcesnik.ucesnikID = ucesnik.UcesnickiNalogID;
        //        trazeniUcesnik.ImePrezime = ucesnik.ImePrezime;
        //        trazeniUcesnik.Klub = ucesnik.Klub;
        //        trazeniUcesnik.Uloga = ucesnik.Uloga;
        //        trazeniUcesnici.Enqueue(trazeniUcesnik);
        //    }
        //    return trazeniUcesnici;
        //}//DajSveUcesnikePoDiscID_QueueVerzija()



        //public IEnumerable<UcesnickiNalogBO> DajSveUcesnikePoDiscID_NizVerzija(int disciplinaID)
        //{

        //    DisciplinaBO disciplinaTrazena = new DisciplinaBO();
        //    foreach (Disciplina disciplina in turnirskiEntities.Disciplina.Where(t => t.DisciplinaID == disciplinaID))
        //    {

        //        disciplinaTrazena.DiscNaziv = disciplina.NazivDiscip;
        //        disciplinaTrazena.DiscID = disciplina.DisciplinaID;

        //    }

        //    UcesnickiNalogBO[] trazeniUcesnici = new UcesnickiNalogBO[40];
        //    //pretpostavimo da je max 40 ljudi po disciplini
        //    //ubaci u verbalni opis,dugorocno zelis da ovo kupi neki podatak o broju ljudi itd.



        //    UcesnickiNalogBO trazeniUcesnik = new UcesnickiNalogBO();
        //    foreach (UcesnickiNalog ucesnik in turnirskiEntities.UcesnickiNalog.Where(t => t.DisciplinaID == disciplinaID))
        //    {
        //        trazeniUcesnik.ucesnikID = ucesnik.UcesnickiNalogID;
        //        trazeniUcesnik.ImePrezime = ucesnik.ImePrezime;
        //        trazeniUcesnik.Klub = ucesnik.Klub;
        //        trazeniUcesnik.Uloga = ucesnik.Uloga;
        //        trazeniUcesnici.Append(trazeniUcesnik);
        //    }
        //    return trazeniUcesnici;
        //}//DajSveUcesnikePoDiscID_NizVerzija()

        public void Delete(DisciplinaBO disciplinaBo)
        {
            List<UcesnickiNalogBO> listaUcesnika = new List<UcesnickiNalogBO>();



            foreach (UcesnickiNalog ucesnik in turnirskiEntities.UcesnickiNalog)
            {
                listaUcesnika.Add(mapiramUcesnike(ucesnik));
            }

            foreach (UcesnickiNalogBO ucesniK in listaUcesnika)
            {
                if (ucesniK.Disciplina.DiscID == disciplinaBo.DiscID)
                {
                    UcesnickiNalog ucesnikZaBrisanje = turnirskiEntities.UcesnickiNalog.FirstOrDefault(t => t.UcesnickiNalogID == ucesniK.ucesnikID);
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
                }
            }


            Disciplina disciplinaZaBrisanje = new Disciplina();
            disciplinaZaBrisanje = turnirskiEntities.Disciplina.FirstOrDefault(t => t.DisciplinaID == disciplinaBo.DiscID);
            if (disciplinaZaBrisanje == null) return;

            turnirskiEntities.Disciplina.Remove(disciplinaZaBrisanje);

            try
            {
                turnirskiEntities.SaveChanges();

            }
            catch (Exception e)
            {
                Console.WriteLine("Disciplina nije uspesno obrisana: " + e);

            }

        }//Delete()
        



        public void Update(DisciplinaBO disciplinaBO)
        {
            Disciplina disciplinaZaIzmenu = turnirskiEntities.Disciplina.FirstOrDefault(t => t.DisciplinaID == disciplinaBO.DiscID);
            if (disciplinaZaIzmenu == null) return; 
            disciplinaZaIzmenu.NazivDiscip = disciplinaBO.DiscNaziv;

            try
            {
                turnirskiEntities.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Neuspesan update discipline: " + e);
            }

        }//Update()


        public IEnumerable<UcesnickiNalogBO> GetAllUcesnici()
        {
            List<UcesnickiNalogBO> ucesnici = new List<UcesnickiNalogBO>();
            foreach (UcesnickiNalog ucesnik in turnirskiEntities.UcesnickiNalog)
            {
                ucesnici.Add(mapiramUcesnike(ucesnik));
            }
            return ucesnici;
        }//GetAll()

        //public IEnumerable<UcesnickiNalogBO> DajSveUcesnikePoDiscID2(int disciplinaID)
        //{


        //    DisciplinaBO disciplinaTrazena = new DisciplinaBO();
        //    foreach (Disciplina disciplina in turnirskiEntities.Disciplina.Where(t => t.DisciplinaID == disciplinaID))
        //    {

        //        disciplinaTrazena.DiscNaziv = disciplina.NazivDiscip;
        //        disciplinaTrazena.DiscID = disciplina.DisciplinaID;

        //    }

        //    Queue<UcesnickiNalogBO> trazeniUcesnici = new Queue<UcesnickiNalogBO>();



        //    UcesnickiNalogBO trazeniUcesnik = new UcesnickiNalogBO();
        //    foreach (UcesnickiNalog ucesnik in turnirskiEntities.UcesnickiNalog.Where(t => t.DisciplinaID == disciplinaID))
        //    {
        //        trazeniUcesnik.ucesnikID = ucesnik.UcesnickiNalogID;
        //        trazeniUcesnik.ImePrezime = ucesnik.ImePrezime;
        //        trazeniUcesnik.Klub = ucesnik.Klub;
        //        trazeniUcesnik.Uloga = ucesnik.Uloga;
        //        trazeniUcesnici.Enqueue(trazeniUcesnik);
        //    }
        //    return trazeniUcesnici;
        //}

        public IEnumerable<UcesnickiNalogBO> GetAllUceWithBiggestDisc()
        {
            int disciplinaID = 1; //ovo resiti preko brojanja itd. posle ali zasad ne komplikuj
            List<UcesnickiNalogBO> ucesnici = new List<UcesnickiNalogBO>();
            foreach (UcesnickiNalog ucesnik in turnirskiEntities.UcesnickiNalog.Where(t => t.DisciplinaID == disciplinaID))
            {
                UcesnickiNalogBO ucesnikBo = new UcesnickiNalogBO();
                ucesnikBo.ucesnikID = ucesnik.UcesnickiNalogID;
                ucesnikBo.ImePrezime = ucesnik.ImePrezime;
                ucesnikBo.Uloga = ucesnik.Uloga;
                ucesnikBo.Klub = ucesnik.Klub;
                //  ucesnikBo.Disciplina.DiscNaziv = new DisciplinaBO() { DiscNaziv = ucesnik.Disciplina. , DiscID = ucesnik.Disciplina. };
                ucesnici.Add(ucesnikBo);
            }
            return ucesnici;
        }
    }
}