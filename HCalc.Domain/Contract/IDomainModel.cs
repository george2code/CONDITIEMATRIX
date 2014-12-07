using System;

namespace HCalc.Domain.Contract
{
    // Marker interface

    public interface IBaseDomainModel
    {

    }

    public interface IDomainModel : IBaseDomainModel
    {
        void SetUpdateProperties(Guid userId);
        void SetCreateProperties(Guid userId,Guid OrganizationId);
        void MarkDeleted(Guid userId);
        void SetCreateProperties();
    }
}