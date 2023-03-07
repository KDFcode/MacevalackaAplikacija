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
        

        void Delete(DisciplinaBO disciplinaBo);
        void Add(DisciplinaBO disciplina);



        void Update(DisciplinaBO disciplinaBO);
    }
}
