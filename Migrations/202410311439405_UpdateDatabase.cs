namespace lab8.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        UniversityCampusID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.UniversityCampus", t => t.UniversityCampusID, cascadeDelete: true)
                .Index(t => t.UniversityCampusID);
            
            CreateTable(
                "dbo.UniversityCampus",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "UniversityCampusID", "dbo.UniversityCampus");
            DropIndex("dbo.Students", new[] { "UniversityCampusID" });
            DropTable("dbo.UniversityCampus");
            DropTable("dbo.Students");
        }
    }
}
