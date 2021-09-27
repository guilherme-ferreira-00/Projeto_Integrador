using System;
using System.Collections.Generic;

namespace cadastro_estudante.Models
{
    public partial class Cursodisciplina
    {
        public Cursodisciplina()
        {
            Estudante = new HashSet<Estudante>();
        }

        public int IdcursoDisciplina { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Estudante> Estudante { get; set; }
    }
}
