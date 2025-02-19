namespace Casemanagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _001 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Adalots", "logoPath", c => c.String());
        }
        

        public override void Down()
        {
            DropColumn("dbo.Adalots", "logoPath");
        }
    }
}
