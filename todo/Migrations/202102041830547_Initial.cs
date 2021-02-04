namespace todo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Atividades",
                c => new
                    {
                        AtividadeId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Data = c.DateTime(nullable: false),
                        Concluída = c.Boolean(nullable: false),
                        Realizando = c.Boolean(nullable: false),
                        Fazer = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AtividadeId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Atividades");
        }
    }
}
