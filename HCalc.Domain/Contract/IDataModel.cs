using System;

namespace HCalc.Domain.Contract
{
    public interface IDataModel
    {
        void SetUpdateProperties(Guid userId);
        void SetCreateProperties(Guid userId, Guid organizationId);
    }
}