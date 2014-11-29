namespace HCalc.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Extent : DbMigration
    {
        public override void Up()
        {
//            CreateTable(
//                "dbo.DefectExtents",
//                c => new
//                    {
//                        Id = c.Int(nullable: false, identity: true),
//                        ExtentName = c.String(),
//                    })
//                .PrimaryKey(t => t.Id);
//            
//            CreateTable(
//                "dbo.DefectImportances",
//                c => new
//                    {
//                        Id = c.Int(nullable: false, identity: true),
//                        ImportanceName = c.String(),
//                    })
//                .PrimaryKey(t => t.Id);
//            
//            CreateTable(
//                "dbo.DefectIntencities",
//                c => new
//                    {
//                        Id = c.Int(nullable: false, identity: true),
//                        IntencityName = c.String(),
//                    })
//                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
//            DropTable("dbo.DefectIntencities");
//            DropTable("dbo.DefectImportances");
//            DropTable("dbo.DefectExtents");
        }
    }
}
