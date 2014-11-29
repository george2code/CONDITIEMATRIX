using System.Collections.Generic;
using HCalc.Domain.Entities;

namespace HCalc.Domain.Abstract
{
    public interface IDefectExtentRepository
    {
        IEnumerable<DefectExtent> DefectExtents { get; }
    }
}