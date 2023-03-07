using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacevalackaAplikacija.Models.Interfaces
{
    internal interface IUcesnickiNalogRepository
    {

        IEnumerable<UcesnickiNalogBO> GetAll();

        IEnumerable<FazaBO> GetAllFaze();

        IEnumerable<DisciplinaBO> GetAllDiscipline();
        void Add(UcesnickiNalogBO ucesnikBo);
        UcesnickiNalogBO DajPoID(int ucesnikID);
        void Delete(UcesnickiNalogBO ucesnikBo);
        void Update(UcesnickiNalogBO ucesnikBo);
    }
}
