using FluentMigrator;


namespace FinalADS.Infrastructure.Migrations.MySQL
{

    public class InsertAutor:Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("InsertAutor.sql");
        }

        public override void Down()
        {
        }
    }
}
