using System.Collections.Generic;
using HCalc.Domain.Entities;

namespace HCalc.Domain.Abstract
{
    public interface IDefectDescriptionRepository
    {
        IEnumerable<DefectDescription> DefectDescriptions { get; }
    }
}