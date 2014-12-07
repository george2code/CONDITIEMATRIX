using HCalc.Domain.Contract;
using HCalc.Domain.Entities;

namespace HCalc.Domain.Concrete
{
    public class BuildingPartRepository : BaseRepository<BuildingPart>
    {
        public BuildingPartRepository(IUnitOfWork unit) : base(unit) {}
    }
}