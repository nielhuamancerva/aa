using FluentMigrator;

namespace FinalADS.Infrastructure.Migrations.MySQL
{
   
    public class CrearAutor : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("CrearAutor.sql");
        }
        public override void Down()
        {
        }
    }

}
