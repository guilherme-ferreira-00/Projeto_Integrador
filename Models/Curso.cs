using System;
using System.Collections.Generic;

namespace cadastro_estudante.Models
{
    public partial class Curso
    {
        public Curso()
        {
            Estudante = new HashSet<Estudante>();
        }

        public int IdCurso { get; set; }
        public string Nome { get; set; }
        public double? Carga { get; set; }
        public string Tipo { get; set; }
        public int IdArea { get; set; }
        public bool Excluido { get; set; }

        public virtual Area IdAreaNavigation { get; set; }
        public virtual ICollection<Estudante> Estudante { get; set; }
    }
}
