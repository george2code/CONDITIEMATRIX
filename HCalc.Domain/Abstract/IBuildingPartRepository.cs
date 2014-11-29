using System.Collections.Generic;
using HCalc.Domain.Entities;

namespace HCalc.Domain.Abstract
{
    public interface IBuildingPartRepository
    {
        IEnumerable<BuildingPart> BuildingParts { get; }
    }
}