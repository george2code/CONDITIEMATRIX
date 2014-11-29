using System.Collections.Generic;
using HCalc.Domain.Abstract;

namespace HCalc.Domain.Concrete
{
    public class EFDefectIntencityRepository : IDefectIntencityRepository
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<Entities.DefectIntencity> DefectIntencities
        {
            get { return context.DefectIntencities; }
        }
    }
}