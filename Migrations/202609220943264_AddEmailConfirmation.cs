namespace MyCode.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmailConfirmation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "IsEmailConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "ActivationCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "ActivationCode");
            DropColumn("dbo.Users", "IsEmailConfirmed");
        }
    }
}
