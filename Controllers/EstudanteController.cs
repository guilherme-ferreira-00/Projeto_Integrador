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
    public class EstudanteController : ControllerBase
    {
        // GET: api/Estudante
        [HttpGet]
        public List<cursoEstudante> Listar()
        {
            List<cursoEstudante> curso = new List<cursoEstudante>();

            cursoEstudante ads = new cursoEstudante
            {
                Id = 1,
                Nome = "Analise e desenvolvimaneto de sistemas"
            };

            curso.Add(ads);

            cursoEstudante cc = new cursoEstudante
            {
                Id = 2,
                Nome = "Ciência da Computação"
            };

            curso.Add(cc);

            cursoEstudante si = new cursoEstudante
            {
                Id = 3,
                Nome = "Sistema de informação"
            };

            curso.Add(si);

            return curso;
        }

        [HttpGet]
        public List<Estudante> EstudanteCadastrado()
        {
            return new List<Estudante>
            {
                new Estudante {  Id = 1 ,Nome = "Emilly", Idade = 23 , Data = "01/02/2011" ,cursoEstudante = new cursoEstudante { Id = 1, Nome = "Analise e desenvolvimento de sistemas" }, Graduado = "Sim" },
                new Estudante {  Id = 1 ,Nome = "Jasmine", Idade = 19 , Data = "01/02/2020" ,cursoEstudante = new cursoEstudante { Id = 1, Nome = "Analise e desenvolvimento de sistemas" }, Graduado = "Não" },
                new Estudante {  Id = 1 ,Nome = "Filip", Idade = 21 , Data = "01/02/2019" ,cursoEstudante = new cursoEstudante { Id = 2, Nome = "Ciência da Computação	" }, Graduado = "Não" },
                new Estudante {  Id = 1 ,Nome = "José", Idade = 33 , Data = "01/08/2009" ,cursoEstudante = new cursoEstudante { Id = 3, Nome = "Sistemas de informação	" }, Graduado = "Sim" },
                new Estudante {  Id = 1 ,Nome = "Cauã", Idade = 41 , Data = "01/02/2018" ,cursoEstudante = new cursoEstudante { Id = 1, Nome = "Analise e desenvolvimento de sistemas	" }, Graduado = "Não" },
                new Estudante {  Id = 1 ,Nome = "Isabela", Idade = 25 , Data = "01/08/2020" ,cursoEstudante = new cursoEstudante { Id = 3, Nome = "Sistemas de informação" }, Graduado = "Não" },
                new Estudante {  Id = 1 ,Nome = "Luis", Idade = 20 , Data = "01/02/2016" ,cursoEstudante = new cursoEstudante { Id = 1, Nome = "Analise e desenvolvimento de sistemas	" }, Graduado = "Sim" },
                new Estudante {  Id = 1 ,Nome = "Marcos", Idade = 29 , Data = "01/02/2012" ,cursoEstudante = new cursoEstudante { Id = 3, Nome = "Sistemas de informação	" }, Graduado = "Sim" },
                new Estudante {  Id = 1 ,Nome = "Samuel", Idade = 31 , Data = "01/02/2021" ,cursoEstudante = new cursoEstudante { Id = 1, Nome = "Analise e desenvolvimento de sistemas	" }, Graduado = "Não" },
                new Estudante {  Id = 1 ,Nome = "Kauê", Idade = 22 , Data = "01/02/2019" ,cursoEstudante = new cursoEstudante { Id = 3, Nome = "Sistemas de informação	" }, Graduado = "Sim" },
        
            };
        }

    [HttpPost]
        public string Cadastrar([FromBody]Estudante novoEstudante)
        {
            return "Estudante cadastrado com sucesso!";
        }

    [HttpDelete]
        public string Excluir([FromBody]int nomeEstudante)
        {
            return "Estudante excluído com sucesso!";
        }
    
    [HttpGet]
        public Estudante Consultar(int idEstudante)
        {
            return new Estudante 
            { 
                Id = 2, 
                Nome = "Jasmine", 
                Idade = 19, 
                Data = "2020-02-01",
                cursoDisciplina = new cursoDisciplina
                {
                    Id = 0,
                    Nome = "Cálculo I"
                },
                cursoEstudante = new cursoEstudante 
                {
                    Id = 1,
                    Nome = "Analise e desenvolvimento de sistemas"
                },
                Graduado = "2",
                
            };
        }
        
        [HttpPut]
        public string Alterar([FromBody]Estudante novoCurso)
        {
            return "Estudante Alterado com sucesso!";
        }

        [HttpGet]
        public List<cursoDisciplina> Listardisciplina()
        {
            List<cursoDisciplina> curso = new List<cursoDisciplina>();

            cursoDisciplina cal = new cursoDisciplina
            {
                Id = 1,
                Nome = "Cálculo I"
            };

            curso.Add(cal);

            cursoDisciplina lm = new cursoDisciplina
            {
                Id = 2,
                Nome = "Lógica Matemática"
            };

            curso.Add(lm);

            cursoDisciplina so = new cursoDisciplina
            {
                Id = 3,
                Nome = "Sistemas Operacionais"
            };

            curso.Add(so);

            cursoDisciplina alg = new cursoDisciplina
            {
                Id = 4,
                Nome = "Análise de Algoritmos"
            };

            curso.Add(alg);

            return curso;
        }



    }

    
}
