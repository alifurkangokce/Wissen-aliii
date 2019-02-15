namespace Wissen.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Hazır1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "CreatedBy", c => c.String());
            AlterColumn("dbo.Categories", "UpdatedBy", c => c.String());
            AlterColumn("dbo.Posts", "CreatedBy", c => c.String());
            AlterColumn("dbo.Posts", "UpdatedBy", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "UpdatedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Posts", "CreatedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Categories", "UpdatedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Categories", "CreatedBy", c => c.Int(nullable: false));
        }
    }
}
