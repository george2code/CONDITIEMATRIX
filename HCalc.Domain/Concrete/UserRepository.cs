using HCalc.Domain.Contract;
using HCalc.Domain.Entities;

namespace HCalc.Domain.Concrete
{
    public class UserRepository : BaseRepository<AspNetUser>
    {
        public UserRepository(IUnitOfWork unit) : base(unit) { }
    }
}