using System.Collections.Generic;
using HCalc.Domain.Abstract;

namespace HCalc.Domain.Concrete
{
    public class EFDefectDescriptionRepository : IDefectDescriptionRepository
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<Entities.DefectDescription> DefectDescriptions
        {
            get { return context.DefectDescriptions; }
        }
    }
}