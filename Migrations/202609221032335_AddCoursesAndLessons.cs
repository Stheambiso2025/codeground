namespace MyCode.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCoursesAndLessons : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(),
                        Icon = c.String(),
                        Slug = c.String(),
                        OrderIndex = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Lessons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(nullable: false),
                        Title = c.String(nullable: false),
                        Content = c.String(),
                        CodeExample = c.String(),
                        Language = c.String(),
                        OrderIndex = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lessons", "CourseId", "dbo.Courses");
            DropIndex("dbo.Lessons", new[] { "CourseId" });
            DropTable("dbo.Lessons");
            DropTable("dbo.Courses");
        }
    }
}
