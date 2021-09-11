using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cadastro_estudante.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        [HttpGet]
        public List<Area> Listar()
        {
            List<Area> areas = new List<Area>();

            Area exatas = new Area
            {
                Id = 1,
                Nome = "Exatas"
            };

            areas.Add(exatas);

            Area saude = new Area
            {
                Id = 2,
                Nome = "Saúde"
            };

            areas.Add(saude);

            Area humanas = new Area
            {
                Id = 3,
                Nome = "Humanas"
            };

            areas.Add(humanas);

            return areas;
        }

        [HttpGet]
        public List<Curso> CusoCadastrado()
        {
            return new List<Curso>
            {
                new Curso {  Id = 1 ,Nome = "Analise e desenvolvimento de sistemas", carga_horaria = 40, Area = new Area { Id = 1, Nome = "Exatas" } },
                new Curso {  Id = 2 ,Nome = "Engenharia civil", carga_horaria = 80, Area = new Area { Id = 1, Nome = "Exatas" } },
                new Curso {  Id = 3 ,Nome = "Medicina veterinaria", carga_horaria = 100, Area = new Area { Id = 2, Nome = "Saúde" } },
                new Curso {  Id = 4 ,Nome = "Ciência da Computação", carga_horaria = 80, Area = new Area { Id = 2, Nome = "Exatas" } },
                new Curso {  Id = 5 ,Nome = "Ciencias humanas", carga_horaria = 40, Area = new Area { Id = 2, Nome = "Humanas" } },
            };
        }

        [HttpGet]
        public Curso Consultar(int idCurso)
        {
            return new Curso 
            { 
                Id = 2, 
                Nome = "Engenharia civil", 
                carga_horaria = 80, 
                Area = new Area 
                {
                    Id = 1,
                    Nome = "Exatas"
                },
                Tipo = "2",
                
            };
        }

        [HttpPost]
        public string Cadastrar([FromBody]Curso novoCurso)
        {
            return "Curso cadastrado com sucesso!";
        }

        [HttpDelete]
        public string Excluir([FromBody]int nomeCurso)
        {
            return "Curso excluído com sucesso!";
        }

        [HttpPut]
        public string Alterar([FromBody]Curso novoCurso)
        {
            return "Curso Alterado com sucesso!";
        }

    }
}
