using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacevalackaAplikacija.Models.Interfaces
{
    internal interface IDisciplinaRepository
    {

        IEnumerable<DisciplinaBO> GetAll();
        DisciplinaBO DajPoID(int disciplinaID);


        IEnumerable<UcesnickiNalogBO> GetAllUcesnici();
         IEnumerable<UcesnickiNalogBO> DajSveUcesnikePoDiscID(int disciplinaID);
        IEnumerable<UcesnickiNalogBO> DajSveUcesnikePoDiscID2(int disciplinaID);

        void Delete(DisciplinaBO disciplinaBo);
        void Add(DisciplinaBO disciplina);

         IEnumerable<UcesnickiNalogBO> GetAllUceWithBiggestDisc();

        void Update(DisciplinaBO disciplinaBO);


    }
}
