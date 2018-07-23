namespace MyAngAppAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbCurrency",
                c => new
                    {
                        CurrencyId = c.Int(nullable: false, identity: true),
                        CurrencyCode = c.String(),
                        CurrencyDescription = c.String(),
                        ClientNo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CurrencyId);
            
            AddColumn("dbo.SalesOrder", "Currency_CurrencyId", c => c.Int());
            CreateIndex("dbo.SalesOrder", "Currency_CurrencyId");
            AddForeignKey("dbo.SalesOrder", "Currency_CurrencyId", "dbo.tbCurrency", "CurrencyId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SalesOrder", "Currency_CurrencyId", "dbo.tbCurrency");
            DropIndex("dbo.SalesOrder", new[] { "Currency_CurrencyId" });
            DropColumn("dbo.SalesOrder", "Currency_CurrencyId");
            DropTable("dbo.tbCurrency");
        }
    }
}
