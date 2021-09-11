public class Estudante
{
    public int Id { get; set; }

    public string Nome { get; set; }

    public string Data { get; set; }

    public double Idade { get; set; }

    public cursoEstudante cursoEstudante { get; set; }

    public cursoDisciplina cursoDisciplina { get; set; }

    public string Graduado { get; set; }
}