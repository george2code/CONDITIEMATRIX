namespace HCalc.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
//            CreateTable(
//                "dbo.DefectDescriptions",
//                c => new
//                    {
//                        Id = c.Int(nullable: false, identity: true),
//                        Description = c.String(),
//                    })
//                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            //DropTable("dbo.DefectDescriptions");
        }
    }
}
