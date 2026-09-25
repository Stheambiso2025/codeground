namespace MyCode.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddQuizzesAndProjects : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProjectSubmissions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        Code = c.String(nullable: false),
                        SubmittedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuizId = c.Int(nullable: false),
                        QuestionText = c.String(nullable: false),
                        OptionA = c.String(),
                        OptionB = c.String(),
                        OptionC = c.String(),
                        OptionD = c.String(),
                        CorrectOption = c.String(nullable: false),
                        OrderIndex = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Quizs", t => t.QuizId, cascadeDelete: true)
                .Index(t => t.QuizId);
            
            CreateTable(
                "dbo.Quizs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LessonId = c.Int(),
                        CourseId = c.Int(),
                        Title = c.String(nullable: false),
                        IsFinalTest = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.QuizAttempts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        QuizId = c.Int(nullable: false),
                        Score = c.Int(nullable: false),
                        TotalQuestions = c.Int(nullable: false),
                        AttemptedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "QuizId", "dbo.Quizs");
            DropIndex("dbo.Questions", new[] { "QuizId" });
            DropTable("dbo.QuizAttempts");
            DropTable("dbo.Quizs");
            DropTable("dbo.Questions");
            DropTable("dbo.ProjectSubmissions");
        }
    }
}
