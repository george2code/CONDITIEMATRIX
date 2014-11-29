using System.Collections.Generic;
using HCalc.Domain.Abstract;

namespace HCalc.Domain.Concrete
{
    public class EFDefectExtentRepository : IDefectExtentRepository
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<Entities.DefectExtent> DefectExtents
        {
            get { return context.DefectExtents; }
        }
    }
}