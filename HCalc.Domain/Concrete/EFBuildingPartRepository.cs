using System.Collections.Generic;
using HCalc.Domain.Abstract;
using HCalc.Domain.Entities;

namespace HCalc.Domain.Concrete
{
    public class EFBuildingPartRepository : IBuildingPartRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<BuildingPart> BuildingParts
        {
            get { return context.BuildingParts; }
        }
    }
}