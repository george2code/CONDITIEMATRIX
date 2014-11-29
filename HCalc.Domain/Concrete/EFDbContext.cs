using System.Data.Entity;
using HCalc.Domain.Entities;

namespace HCalc.Domain.Concrete
{
    public class EFDbContext: DbContext
    {
        public DbSet<BuildingPart> BuildingParts { get; set; }
        public DbSet<DefectDescription> DefectDescriptions { get; set; }
        public DbSet<DefectExtent> DefectExtents { get; set; }
        public DbSet<DefectIntencity> DefectIntencities { get; set; }
        public DbSet<DefectImportance> DefectImportances { get; set; }
        public DbSet<Action> Actions { get; set; }
    }
}