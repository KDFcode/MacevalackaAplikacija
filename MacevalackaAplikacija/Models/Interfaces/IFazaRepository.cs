using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacevalackaAplikacija.Models.Interfaces
{
    internal interface IFazaRepository
    {


        IEnumerable<FazaBO> GetAll();
        FazaBO DajPoID(int fazaID);
        void Delete(FazaBO faza);
        void Add(FazaBO faza);
        void Update(FazaBO faza);
    }
}
