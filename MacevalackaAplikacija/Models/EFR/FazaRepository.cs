using MacevalackaAplikacija.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MacevalackaAplikacija.Models.EFR
{
    public class FazaRepository : IFazaRepository
    {



        private turnirskoNova2Entities turnirskiEntities = new turnirskoNova2Entities();



        private FazaBO mapiram(FazaTakmicenja faza)
        {
            FazaBO fazaBO = new FazaBO { FazaTakmicenjaID = faza.FazaTakmicenjaID, NazivFazeTakmicenja = faza.NazivFaze };
            return fazaBO;
        }//mapiram()

        private DisciplinaBO mapiramDiscipline(Disciplina disciplina)
        {
            DisciplinaBO disciplinaBO = new DisciplinaBO { DiscID = disciplina.DisciplinaID, DiscNaziv = disciplina.NazivDiscip };
            return disciplinaBO;
        }//mapiramDiscipline()

        private UcesnickiNalogBO mapiramUcesnika(UcesnickiNalog ucesnik)
        {
            UcesnickiNalogBO ucesnickiNalogBO = new UcesnickiNalogBO { ucesnikID = ucesnik.UcesnickiNalogID, ImePrezime = ucesnik.ImePrezime, Klub = ucesnik.Klub, Uloga = ucesnik.Uloga, Disciplina = mapiramDiscipline(ucesnik.Disciplina), faza = mapiram(ucesnik.FazaTakmicenja) };
            return ucesnickiNalogBO;

        }//mapiramUcesnika() 


        public IEnumerable<FazaBO> GetAll()
        {
            List<FazaBO> faze = new List<FazaBO>();
            foreach (FazaTakmicenja faza in turnirskiEntities.FazaTakmicenja)
            {
                faze.Add(mapiram(faza));
            }
            return faze;
        }//GetAll()
        public void Add(FazaBO fazaNovaBo)
        {
            FazaTakmicenja fazaNova = new FazaTakmicenja();
            fazaNova.NazivFaze = fazaNovaBo.NazivFazeTakmicenja;
            turnirskiEntities.FazaTakmicenja.Add(fazaNova);
            turnirskiEntities.SaveChanges();
        }//Add()

        public FazaBO DajPoID(int fazaID)
        {

            FazaBO fazaTrazena = new FazaBO();
            foreach (FazaTakmicenja faza in turnirskiEntities.FazaTakmicenja.Where(t => t.FazaTakmicenjaID == fazaID))
            {

                fazaTrazena.NazivFazeTakmicenja = faza.NazivFaze;
                fazaTrazena.FazaTakmicenjaID = faza.FazaTakmicenjaID;

            }
            return fazaTrazena;
        }//DajPoID()

       


        public void Delete(FazaBO fazaBO)

        {

            List<UcesnickiNalogBO> listaUcesnika = new List<UcesnickiNalogBO>();

            // GetAllUcesnici

            foreach (UcesnickiNalog ucesnik in turnirskiEntities.UcesnickiNalog)
            {
                listaUcesnika.Add(mapiramUcesnika(ucesnik));
            }

            foreach (UcesnickiNalogBO ucesniK in listaUcesnika)
            {
                if (ucesniK.faza.FazaTakmicenjaID == fazaBO.FazaTakmicenjaID)
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

            FazaTakmicenja fazaZaBrisanje = turnirskiEntities.FazaTakmicenja.FirstOrDefault(t => t.FazaTakmicenjaID == fazaBO.FazaTakmicenjaID);
            if (fazaZaBrisanje == null) return; 

            turnirskiEntities.FazaTakmicenja.Remove(fazaZaBrisanje);
            try
            {
                turnirskiEntities.SaveChanges();

            }
            catch (Exception e)
            {
                Console.WriteLine("Faza nije uspesno obrisana: " + e);

            }

           
        }//Delete()


        public void Update(FazaBO fazaBO)
        {
            FazaTakmicenja fazaZaIzmenu = turnirskiEntities.FazaTakmicenja.FirstOrDefault(t => t.FazaTakmicenjaID == fazaBO.FazaTakmicenjaID);
            if (fazaZaIzmenu == null) return; 
            fazaZaIzmenu.NazivFaze = fazaBO.NazivFazeTakmicenja;

            try
            {
                turnirskiEntities.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Neuspesan update faze: " + e);
            }

        }//Update()
    }
}