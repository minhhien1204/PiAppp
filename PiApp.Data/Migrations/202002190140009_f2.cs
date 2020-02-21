namespace PiApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class f2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Foods", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Foods", new[] { "CategoryId" });
            AlterColumn("dbo.Foods", "PricePromotion", c => c.Int());
            AlterColumn("dbo.Foods", "CategoryId", c => c.Int());
            CreateIndex("dbo.Foods", "CategoryId");
            AddForeignKey("dbo.Foods", "CategoryId", "dbo.Categories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Foods", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Foods", new[] { "CategoryId" });
            AlterColumn("dbo.Foods", "CategoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Foods", "PricePromotion", c => c.Int(nullable: false));
            CreateIndex("dbo.Foods", "CategoryId");
            AddForeignKey("dbo.Foods", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
    }
}
