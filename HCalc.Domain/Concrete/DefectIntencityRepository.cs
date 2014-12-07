using HCalc.Domain.Contract;
using HCalc.Domain.Entities;

namespace HCalc.Domain.Concrete
{
    public class DefectIntencityRepository : BaseRepository<DefectIntencity>
    {
        public DefectIntencityRepository(IUnitOfWork unit) : base(unit) { }
    }
}