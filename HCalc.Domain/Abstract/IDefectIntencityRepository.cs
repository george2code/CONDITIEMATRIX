using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCalc.Domain.Entities;

namespace HCalc.Domain.Abstract
{
    public interface IDefectIntencityRepository
    {
        IEnumerable<DefectIntencity> DefectIntencities { get; }
    }
}