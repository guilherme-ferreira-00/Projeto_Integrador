using System;
using System.Collections.Generic;

namespace cadastro_estudante.Models
{
    public partial class Cursoestudante
    {
        public Cursoestudante()
        {
            Estudante = new HashSet<Estudante>();
        }

        public int IdcursoEstudante { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Estudante> Estudante { get; set; }
    }
}
