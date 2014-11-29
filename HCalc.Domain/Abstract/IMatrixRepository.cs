using System.Collections.Generic;
using HCalc.Domain.Entities;

namespace HCalc.Domain.Abstract
{
    public interface IMatrixRepository
    {
        IEnumerable<Matrix> Matrices { get; }
        Matrix GetById(int id);
        void Add(Matrix entity);
        void Update(Matrix entity);
        void Delete(int id);
    }
}