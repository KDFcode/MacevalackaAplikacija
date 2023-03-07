using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MacevalackaAplikacija.Models
{
    public class FazaBO
    {
        #region properties
        public int FazaTakmicenjaID { get; set; }


        [StringLength(20, ErrorMessage = "Naziv faze takmicenja ne sme biti duzi od 20 karaktera ")] 
        public string NazivFazeTakmicenja { get; set; }

        #endregion
    }
}