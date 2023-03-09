using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MacevalackaAplikacija.Models;
using MacevalackaAplikacija.Models.EFR;
using MacevalackaAplikacija.Models.Interfaces;

namespace MacevalackaAplikacija.Controllers
{
    public class DisciplinaController : Controller
    {

        private IDisciplinaRepository disciplinaRepository;

        public DisciplinaController()
        {
            disciplinaRepository = new DisciplinaRepository();
        }


        public ActionResult IndexDisc()
        {
            IEnumerable<DisciplinaBO> discipline = disciplinaRepository.GetAll();
           


            @ViewBag.Discipline = disciplinaRepository.GetAll();
            return View(discipline);
            
        }//IndexDisc()





        [Authorize(Roles = "organizator")]
        public ActionResult DeleteDisc(int id)//httpget
        {
            DisciplinaBO disciplina;
            disciplina = disciplinaRepository.DajPoID(id);

            @ViewBag.Discipline = disciplinaRepository.GetAll();
            return View(disciplina);
        }//Delete() 


        [HttpPost]
        [Authorize(Roles = "organizator")]
        public ActionResult DeleteDisc(DisciplinaBO disc)
        {
            disciplinaRepository.Delete(disc);
            return RedirectToAction("IndexDisc");
        }//Delete()



        [Authorize(Roles = "organizator")]
        public ActionResult CreateDisc()
        {
            @ViewBag.Discipline = disciplinaRepository.GetAll();

            return View();
        }//CreateDisc()


        [HttpPost]
        [Authorize(Roles = "organizator")]
        public ActionResult CreateDisc(DisciplinaBO disciplinaBo)
        {
            disciplinaRepository.Add(disciplinaBo);
            return RedirectToAction("IndexDisc");
        }//CreateDisc()

        [Authorize(Roles = "organizator")]

        public ActionResult EditDisc(int id)
        {
            DisciplinaBO discipline;
            discipline = disciplinaRepository.DajPoID(id);

            @ViewBag.Discipline = disciplinaRepository.GetAll();
            return View(discipline);
        }//Edit()


        [HttpPost]
        [Authorize(Roles = "organizator")]
        public ActionResult EditDisc(DisciplinaBO disciplinaBo)
        {
            if (disciplinaBo.DiscID == 0)
            {
                disciplinaRepository.Add(disciplinaBo);
            }
            else
            {
                disciplinaRepository.Update(disciplinaBo);
            }
            return RedirectToAction("IndexDisc");
        }//Edit()



       


        public ActionResult DajUcesnikePoDisciplini(int id)
        {

            if (id == 0)
            {
                return PartialView("ListaUcesnika", disciplinaRepository.GetAllUcesnici());
              
            }

            return PartialView("ListaUcesnika", disciplinaRepository.DajPoID(id));

        }//DajUcesnikePoDisciplini()

    }
}
