namespace Assesment.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AssesmentAttributeReadModel_AlterRemove_ChecklistId : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ReadModel-AssesmentAttribute", "ChecklistId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ReadModel-AssesmentAttribute", "ChecklistId", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
