using HCalc.Domain.Contract;
using HCalc.Domain.Entities;

namespace HCalc.Domain.Concrete
{
    public class DefectDescriptionRepository : BaseRepository<DefectDescription>
    {
        public DefectDescriptionRepository(IUnitOfWork unit) : base(unit) { }
    }
}