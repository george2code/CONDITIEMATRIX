namespace HCalc.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class matrix_update : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Matrices", "Percent", c => c.Single());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Matrices", "Percent", c => c.Single(nullable: false));
        }
    }
}
