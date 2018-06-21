namespace ImageWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContentViewModelValues : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContentViewModels",
                c => new
                    {
                        ImageId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.ImageId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ContentViewModels");
        }
    }
}
