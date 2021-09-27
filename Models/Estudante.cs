using System;
using System.Collections.Generic;

namespace cadastro_estudante.Models
{
    public partial class Estudante
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Data { get; set; }
        public int Idade { get; set; }
        public bool Graduado { get; set; }
        public int? IdCurso { get; set; }
        public int? IdcursoDisciplina { get; set; }
        public int? IdcursoEstudante { get; set; }

        public virtual Curso IdCursoNavigation { get; set; }
        public virtual Cursodisciplina IdcursoDisciplinaNavigation { get; set; }
        public virtual Cursoestudante IdcursoEstudanteNavigation { get; set; }
    }
}
