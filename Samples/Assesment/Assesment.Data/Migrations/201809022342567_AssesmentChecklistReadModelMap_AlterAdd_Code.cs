namespace Assesment.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AssesmentChecklistReadModelMap_AlterAdd_Code : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReadModel-AssesmentChecklist", "Code", c => c.String(nullable: false, maxLength: 64));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ReadModel-AssesmentChecklist", "Code");
        }
    }
}
