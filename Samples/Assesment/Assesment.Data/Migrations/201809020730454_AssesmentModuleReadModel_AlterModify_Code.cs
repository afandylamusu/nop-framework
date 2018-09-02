namespace Assesment.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AssesmentModuleReadModel_AlterModify_Code : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ReadModel-AssesmentModule", "Code", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ReadModel-AssesmentModule", "Code", c => c.String());
        }
    }
}
