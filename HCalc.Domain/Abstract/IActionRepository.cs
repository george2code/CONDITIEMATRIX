using System.Collections.Generic;

namespace HCalc.Domain.Abstract
{
    public interface IActionRepository
    {
        IEnumerable<Entities.Action> Actions { get; }
    }
}