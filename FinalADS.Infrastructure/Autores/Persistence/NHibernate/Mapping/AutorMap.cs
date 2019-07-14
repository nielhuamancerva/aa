using FinalADS.Domain.Autores.Entities;
using FluentNHibernate.Mapping;

namespace FinalADS.Infrastructure.Autor.Persistence.NHibernate.Mapping
{
    public class AutorMap : ClassMap<Autors>
    {


        public AutorMap()
        {
            Id(x => x.Id).Column("autor_id");
            Map(x => x.FirstName).Column("first_name");
            Map(x => x.LastName).Column("last_name");
            Map(x => x.institucion).Column("institucion");
        }
    }
}
