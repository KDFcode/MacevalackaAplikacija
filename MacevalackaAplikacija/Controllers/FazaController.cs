using MacevalackaAplikacija.Models;
using MacevalackaAplikacija.Models.EFR;
using MacevalackaAplikacija.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MacevalackaAplikacija.Controllers
{
    public class FazaController : Controller
    {

        private IFazaRepository fazaRepository;

        public FazaController()
        {
            fazaRepository = new FazaRepository();
        }



        public ActionResult IndexFaza()
        {
            IEnumerable<FazaBO> faze = fazaRepository.GetAll();
            return View(faze);
        }//IndexDisc()



        [Authorize(Roles = "organizator")]
        public ActionResult DeleteFaza(int id)//httpget
        {
            FazaBO faza;
            faza = fazaRepository.DajPoID(id);

            @ViewBag.fazaTrazena = fazaRepository.GetAll();
            return View(faza);
        }//Delete() 

        
        [HttpPost]
        [Authorize(Roles = "organizator")]
        public ActionResult DeleteFaza(FazaBO faza)
        {
            fazaRepository.Delete(faza);
            return RedirectToAction("IndexFaza");
        }//Delete()



        [Authorize(Roles = "organizator")]
        public ActionResult CreateFaza()
        {
            @ViewBag.Faze = fazaRepository.GetAll();

            return View();
        }//CreateDisc()


        [HttpPost]
        [Authorize(Roles = "organizator")]
        public ActionResult CreateFaza(FazaBO fazaBO)
        {
            fazaRepository.Add(fazaBO);
            return RedirectToAction("IndexFaza");
        }//CreateDisc()


        [Authorize(Roles = "organizator")]
        public ActionResult EditFaza(int id)
        {
            FazaBO faze;
            faze = fazaRepository.DajPoID(id);

            @ViewBag.Faze = fazaRepository.GetAll();
            return View(faze);
        }//Edit()


        [HttpPost]
        [Authorize(Roles = "organizator")]
        public ActionResult EditFaza(FazaBO fazaBO)
        {
            if (fazaBO.FazaTakmicenjaID == 0)
            {
                fazaRepository.Add(fazaBO);
            }
            else
            {
                fazaRepository.Update(fazaBO);
            }
            return RedirectToAction("IndexFaza");
        }//Edit()
    }
}