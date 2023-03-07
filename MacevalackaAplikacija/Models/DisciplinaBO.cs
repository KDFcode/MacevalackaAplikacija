using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MacevalackaAplikacija.Models
{
    public class DisciplinaBO
    {

        public int DiscID { get; set; }



        #region naziv
        [StringLength(10, ErrorMessage = "Naziv ne sme biti duzi od 10 karaktera ")]

        public string DiscNaziv { get; set; }
        #endregion
    }
}