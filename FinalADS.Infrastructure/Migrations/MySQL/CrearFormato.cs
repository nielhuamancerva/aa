using FluentMigrator;

namespace FinalADS.Infrastructure.Migrations.MySQL
{

    public class CrearFormato : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("CrearFormato.sql");
        }
        public override void Down()
        {
        }
    }
}
