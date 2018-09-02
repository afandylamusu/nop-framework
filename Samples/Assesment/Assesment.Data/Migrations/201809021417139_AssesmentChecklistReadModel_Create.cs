namespace Assesment.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AssesmentChecklistReadModel_Create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ReadModel-AssesmentChecklist",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        ModuleId = c.String(nullable: false, maxLength: 255),
                        AggregateId = c.String(nullable: false, maxLength: 255),
                        CreatedTime = c.DateTimeOffset(nullable: false, precision: 7),
                        CreatedBy = c.String(nullable: false, maxLength: 255),
                        ModifiedTime = c.DateTimeOffset(precision: 7),
                        ModifiedBy = c.String(maxLength: 255),
                        LastAggregateSequenceNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.AggregateId, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.ReadModel-AssesmentChecklist", new[] { "AggregateId" });
            DropTable("dbo.ReadModel-AssesmentChecklist");
        }
    }
}
