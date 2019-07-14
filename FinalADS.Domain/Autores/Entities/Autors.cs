using FinalADS.Domain.Autores.Constants;
using Common;

namespace FinalADS.Domain.Autores.Entities
{
    public class Autors:Entity
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string institucion { get; set; }
        public Autors()
        {

        }

    }
}
