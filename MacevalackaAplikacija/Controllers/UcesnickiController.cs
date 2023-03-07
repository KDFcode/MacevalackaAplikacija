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
    public class UcesnickiController : Controller
    {





        private IUcesnickiNalogRepository ucesnickiRepository;

        public UcesnickiController()
        { ucesnickiRepository = new UcesnickiNalogRepository(); }





        public ActionResult IndexUce()
        {
            IEnumerable<UcesnickiNalogBO> ucesnici = ucesnickiRepository.GetAll();
            return View(ucesnici);
        }//IndexUce()



        [Authorize(Roles = "organizator")]
        public ActionResult DeleteUce(int id) //httpget
        {
            UcesnickiNalogBO ucesnici;
            ucesnici = ucesnickiRepository.DajPoID(id);

            @ViewBag.Ucesnici = ucesnickiRepository.GetAll();
            return View(ucesnici);
        }//Delete() 

        [HttpPost]
        [Authorize(Roles = "organizator")]
        public ActionResult DeleteUce(UcesnickiNalogBO ucesnik)
        {
            ucesnickiRepository.Delete(ucesnik);
            return RedirectToAction("IndexUce");
        }//Delete() 



        //[Authorize(Roles = "Administrator")]
        [Authorize(Roles = "organizator")]
        public ActionResult CreateUce()
        {
            @ViewBag.Discipline = ucesnickiRepository.GetAllDiscipline();
            @ViewBag.Faze = ucesnickiRepository.GetAllFaze();
            @ViewBag.Ucesnici = ucesnickiRepository.GetAll(); //razmisli da li da ostavis bez ovoga?
            return View();
        }//CreateUce()

        [HttpPost]
        [Authorize(Roles = "organizator")]
        public ActionResult CreateUce(UcesnickiNalogBO ucesnikBo)
        {
            ucesnickiRepository.Add(ucesnikBo);
            return RedirectToAction("IndexUce");
        }//CreateUce()



        //[Authorize(Roles = "Administrator")]
        [Authorize(Roles = "organizator")]
        public ActionResult EditUce(int id) //httpget
        {
            UcesnickiNalogBO ucesnik;
            ucesnik = ucesnickiRepository.DajPoID(id);

       //     @ViewBag.Ucesnici = ucesnickiRepository.GetAll();
            return View(ucesnik);
        }//Edit()




        [HttpPost]
        [Authorize(Roles = "organizator")]
        public ActionResult EditUce(UcesnickiNalogBO ucesnikBo)
        {
           
            if (ucesnikBo.ucesnikID == 0)
            {
                ucesnickiRepository.Add(ucesnikBo);
            }
            else
            {
                ucesnickiRepository.Update(ucesnikBo);
            }
            return RedirectToAction("IndexUce");
        }//Edit()



         public ActionResult Details(int id)
        {
            if (id == null) 
            { return HttpNotFound(); }
            else
            {
                UcesnickiNalogBO ucesnik = ucesnickiRepository.DajPoID(id);
                if (ucesnik == null)
                {
                    return HttpNotFound();
                }
                return View(ucesnik);
            }
        }
    }
}