using System.Collections.Generic;
using HCalc.Domain.Entities;

namespace HCalc.Domain.Abstract
{
    public interface IDefectImportanceRepository
    {
        IEnumerable<DefectImportance> DefectImportances { get; }
    }
}