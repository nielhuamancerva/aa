using FluentMigrator;

namespace FinalADS.Infrastructure.Migrations.MySQL
{
  
    public class CrearArticuloCientifico : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("CrearArticuloCientifico.sql");
        }

        public override void Down()
        {
        }
    }
}
