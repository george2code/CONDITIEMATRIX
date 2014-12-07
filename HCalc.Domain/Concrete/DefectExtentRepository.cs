using HCalc.Domain.Contract;
using HCalc.Domain.Entities;

namespace HCalc.Domain.Concrete
{
    public class DefectExtentRepository : BaseRepository<DefectExtent>
    {
        public DefectExtentRepository(IUnitOfWork unit) : base(unit) { }
    }
}