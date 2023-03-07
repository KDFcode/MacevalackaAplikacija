using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MacevalackaAplikacija.Models
{
    public class UcesnickiNalogBO
    {


        #region properties
        public int ucesnikID { get; set; }


        [StringLength(50, ErrorMessage = "Ime i prezime ne smeju zajedno biti duzi od 50 karaktera ")]
        public string ImePrezime { get; set; }


        [StringLength(10, ErrorMessage = "Naziv turnirske uloge ne sme biti duzi od 10 karaktera ")]
        public string Uloga { get; set; }


        [StringLength(40, ErrorMessage = "Naziv kluba ne sme biti duzi od 40 karaktera ")]
        public string Klub { get; set; }
        public virtual DisciplinaBO Disciplina { get; set; } 
        public virtual FazaBO faza { get; set; }





        #endregion
    }
}