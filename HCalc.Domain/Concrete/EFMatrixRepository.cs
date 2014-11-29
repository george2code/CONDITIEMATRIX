using System;
using System.Collections.Generic;
using System.Linq;
using HCalc.Domain.Abstract;
using HCalc.Domain.Entities;

namespace HCalc.Domain.Concrete
{
    public class EFMatrixRepository : IMatrixRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Matrix> Matrices {
            get { return context.Matrices; }
        }

        public Matrix GetById(int id)
        {
            return context.Matrices.FirstOrDefault(m => m.Id == id);
        }

        public void Add(Matrix entity)
        {
            context.Matrices.Add(entity);
            context.SaveChanges();
        }

        public void Update(Matrix entity)
        {
            var item = GetById(entity.Id);
            if (item != null)
            {
                item.BuildingPartId = entity.BuildingPartId;
                item.DefectDescriptionId = entity.DefectDescriptionId;
                item.ImportanceId = entity.ImportanceId;
                item.IntencityId = entity.IntencityId;
                item.ExtentId = entity.ExtentId;
                item.Condition = entity.Condition;
                item.ActieId = entity.ActieId;
                item.HvhId = entity.HvhId;
                item.EenhId = entity.EenhId;
                item.Percent = entity.Percent;
                item.Cost = entity.Cost;
                item.Total = entity.Total;
                item.BTW = entity.BTW;
                item.Cycle = entity.Cycle;
                item.StartYear = entity.StartYear;
                item.UpdatedDate = DateTime.Now;

                // apply changes
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            if (entity != null) {
                context.Matrices.Remove(entity);
                context.SaveChanges();
            }
        }
    }
}