using System;
using System.Collections.Generic;

namespace cadastro_estudante.Models
{
    public partial class Area
    {
        public Area()
        {
            Curso = new HashSet<Curso>();
        }

        public int IdArea { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Curso> Curso { get; set; }
    }
}
