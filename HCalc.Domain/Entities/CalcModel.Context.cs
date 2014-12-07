﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HCalc.Domain.Entities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class HCalcEntities : DbContext
    {
        public HCalcEntities()
            : base("name=HCalcEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
//            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Action> Actions { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<BuildingPart> BuildingParts { get; set; }
        public virtual DbSet<DefectCondition> DefectConditions { get; set; }
        public virtual DbSet<DefectDescription> DefectDescriptions { get; set; }
        public virtual DbSet<DefectExtent> DefectExtents { get; set; }
        public virtual DbSet<DefectImportance> DefectImportances { get; set; }
        public virtual DbSet<DefectIntencity> DefectIntencities { get; set; }
        public virtual DbSet<Matrix> Matrices { get; set; }
    }
}