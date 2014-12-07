using HCalc.Domain.Contract;
using HCalc.Domain.Entities;

namespace HCalc.Domain.Concrete
{
    public class MatrixRepository : BaseRepository<Matrix>
    {
        public MatrixRepository(IUnitOfWork unit) : base(unit) { }
    }
}