using System.Collections.Generic;
using HCalc.Domain.Abstract;

namespace HCalc.Domain.Concrete
{
    public class EFActionRepository : IActionRepository
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<Entities.Action> Actions
        {
            get { return context.Actions; }
        }
    }
}