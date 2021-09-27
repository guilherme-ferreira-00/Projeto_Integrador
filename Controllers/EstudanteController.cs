using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using cadastro_estudante.Models;


namespace cadastro_estudante.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EstudanteController : ControllerBase
    {
        private BDContexto contexto;
        
        public EstudanteController(BDContexto bdContexto)
        {
            contexto = bdContexto;
        }
        // GET: api/Estudante
        [HttpGet]
        public List<Cursoestudante> Listar()
        {
            return contexto.Cursoestudante.ToList();
        }
        

        [HttpGet]
        public List<Estudante> EstudanteCadastrado()
        {
            return contexto.Estudante.Include(c => c.IdCursoNavigation).OrderBy(c => c.Nome).Select
            (
                c => new Estudante 
                { 
                    Id = c.Id,
                    Nome = c.Nome,
                    Idade = c.Idade,
                    Data = c.Data,
                    Graduado = c.Graduado,
                    IdCursoNavigation = new Curso 
                    { 
                        IdCurso = c.IdCursoNavigation.IdCurso, 
                        Nome = c.IdCursoNavigation.Nome,
                        Carga = c.IdCursoNavigation.Carga,
                        Tipo = c.IdCursoNavigation.Tipo
                    }, 
                    IdcursoDisciplinaNavigation = new Cursodisciplina 
                    { 
                        IdcursoDisciplina = c.IdcursoDisciplinaNavigation.IdcursoDisciplina, 
                        Nome = c.IdcursoDisciplinaNavigation.Nome,
                    },
                    IdcursoEstudanteNavigation  = new Cursoestudante 
                    { 
                        IdcursoEstudante = c.IdcursoEstudanteNavigation.IdcursoEstudante, 
                        Nome = c.IdcursoEstudanteNavigation.Nome
                    }
                }).ToList();
        }
    [HttpGet]
        public List<Estudante> Consultar(int idCurso)
        {
            return contexto.Estudante.Where(c => c.Id == idCurso).Select
            (
                c => new Estudante 
                { 
                    Id = c.Id,
                    Nome = c.Nome,
                    Idade = c.Idade,
                    Data = c.Data,
                    Graduado = c.Graduado,
                    IdcursoDisciplinaNavigation = new Cursodisciplina 
                    { 
                        IdcursoDisciplina = c.IdcursoDisciplinaNavigation.IdcursoDisciplina, 
                        Nome = c.IdcursoDisciplinaNavigation.Nome,
                    },
                    IdcursoEstudanteNavigation  = new Cursoestudante 
                    { 
                        IdcursoEstudante = c.IdcursoEstudanteNavigation.IdcursoEstudante, 
                        Nome = c.IdcursoEstudanteNavigation.Nome
                    }
                }).ToList();
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
    
   
        
        [HttpPut]
        public string Alterar([FromBody]Estudante novoCurso)
        {
            return "Estudante Alterado com sucesso!";
        }

        [HttpGet]
        public List<Cursodisciplina> Listardis()
        {
            return contexto.Cursodisciplina.ToList();
        }

    }

    
}
