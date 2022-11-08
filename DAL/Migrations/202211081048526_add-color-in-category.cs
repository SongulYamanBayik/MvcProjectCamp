namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcolorincategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "Color", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "Color");
        }
    }
}
