namespace lab8.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CampusAndStudentValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Students", "Address", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.UniversityCampus", "Name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UniversityCampus", "Name", c => c.String());
            AlterColumn("dbo.Students", "Address", c => c.String());
            AlterColumn("dbo.Students", "Name", c => c.String());
        }
    }
}
