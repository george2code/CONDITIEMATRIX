using System;
using System.Collections.Generic;
using HCalc.Domain.Abstract;

namespace HCalc.Domain.Concrete
{
    public class EFDefectImportanceRepository : IDefectImportanceRepository
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<Entities.DefectImportance> DefectImportances
        {
            get { return context.DefectImportances; }
        }
    }
}