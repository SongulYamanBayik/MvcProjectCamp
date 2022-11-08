namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renametitle : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Tittles", newName: "Titles");
            RenameColumn(table: "dbo.Contents", name: "TittleID", newName: "TitleID");
            RenameIndex(table: "dbo.Contents", name: "IX_TittleID", newName: "IX_TitleID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Contents", name: "IX_TitleID", newName: "IX_TittleID");
            RenameColumn(table: "dbo.Contents", name: "TitleID", newName: "TittleID");
            RenameTable(name: "dbo.Titles", newName: "Tittles");
        }
    }
}
