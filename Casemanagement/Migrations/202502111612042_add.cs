namespace Casemanagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Adalots",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CaseDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HairingDate = c.DateTime(nullable: false),
                        nextHairingDate = c.Int(nullable: false),
                        Hairing = c.String(),
                        Comments = c.String(),
                        CaseinfoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Caseinfoes", t => t.CaseinfoId, cascadeDelete: true)
                .Index(t => t.CaseinfoId);
            
            CreateTable(
                "dbo.Caseinfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Casenumber = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Discription = c.String(),
                        AdalotId = c.Int(nullable: false),
                        SectionId = c.Int(nullable: false),
                        CaseSourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Adalots", t => t.AdalotId, cascadeDelete: true)
                .ForeignKey("dbo.CaseSources", t => t.CaseSourceId, cascadeDelete: true)
                .ForeignKey("dbo.Sections", t => t.SectionId, cascadeDelete: true)
                .Index(t => t.AdalotId)
                .Index(t => t.SectionId)
                .Index(t => t.CaseSourceId);
            
            CreateTable(
                "dbo.CaseSources",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Divition = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CaseDetails", "CaseinfoId", "dbo.Caseinfoes");
            DropForeignKey("dbo.Caseinfoes", "SectionId", "dbo.Sections");
            DropForeignKey("dbo.Caseinfoes", "CaseSourceId", "dbo.CaseSources");
            DropForeignKey("dbo.Caseinfoes", "AdalotId", "dbo.Adalots");
            DropIndex("dbo.Caseinfoes", new[] { "CaseSourceId" });
            DropIndex("dbo.Caseinfoes", new[] { "SectionId" });
            DropIndex("dbo.Caseinfoes", new[] { "AdalotId" });
            DropIndex("dbo.CaseDetails", new[] { "CaseinfoId" });
            DropTable("dbo.Sections");
            DropTable("dbo.CaseSources");
            DropTable("dbo.Caseinfoes");
            DropTable("dbo.CaseDetails");
            DropTable("dbo.Adalots");
        }
    }
}
