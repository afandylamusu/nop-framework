namespace Assesment.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AssesmentModuleReadModel_AlterAdd_Code : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReadModel-AssesmentModule", "Code", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ReadModel-AssesmentModule", "Code");
        }
    }
}
