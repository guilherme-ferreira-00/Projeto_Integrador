using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using cadastro_estudante.Models;
using Microsoft.EntityFrameworkCore;

namespace cadastro_estudante.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private BDContexto contexto;
        
        public CursoController(BDContexto bdContexto)
        {
            contexto = bdContexto;
        }
        public List<Area> Listar()
        {
            return contexto.Area.ToList();
        }
        

        [HttpGet]
        public List<Curso> CusoCadastrado()
        {

            return contexto.Curso.Include(c => c.IdAreaNavigation).OrderBy(c => c.Nome).Select
            (
                c => new Curso 
                { 
                    IdCurso = c.IdCurso,
                    Nome = c.Nome,
                    Carga = c.Carga,
                    IdAreaNavigation = new Area 
                    { 
                        IdArea = c.IdAreaNavigation.IdArea, 
                        Nome = c.IdAreaNavigation.Nome
                    } 
                }).ToList();
        }

       [HttpGet]
        public List<Curso> Consultar(int Id)
        {
             return contexto.Curso.Where(c => c.IdCurso == Id).Select
            (
                c => new Curso 
                {  
                    IdCurso = c.IdCurso,
                    Nome = c.Nome,
                    Carga = c.Carga,
                    Tipo = c.Tipo,
                    IdAreaNavigation = new Area 
                    { 
                        IdArea = c.IdAreaNavigation.IdArea, 
                        Nome = c.IdAreaNavigation.Nome
                    } 
                
            }).ToList();
        }

        [HttpPost]
        public string Cadastrar([FromBody]Curso novoCurso)
        {
            contexto.Add(novoCurso);
            contexto.SaveChanges();
            return "Curso cadastrado com sucesso!";
            
        }

        [HttpDelete]
        public string Excluir([FromBody]int nomeCurso)
        {
             Curso dados = contexto.Curso.FirstOrDefault(p => p.IdCurso == nomeCurso);

            if (dados == null)
            {
                return "Não foi encontrado Curso para o ID informado!";
            }
            else
            {
                contexto.Remove(dados);
                contexto.SaveChanges();
            
                return "Curso excluído com sucesso!";
            }
            
        }

        [HttpPut]
        public string Alterar([FromBody]Curso novoCurso)
        {
            contexto.Update(novoCurso);
            contexto.SaveChanges();
            return "Curso Alterado com sucesso!";
        }

        [HttpDelete]
        public string ExcluirLogico([FromBody]int id)
        {
            try
            {
                Curso dados = contexto.Curso.FirstOrDefault(p => p.IdCurso == id);

                dados.Excluido = true;
                contexto.Update(dados);
                contexto.SaveChanges();
        
                return "Curso excluído com sucesso!";
            }
            catch (System.Exception ex)
            {
                return ex.Message;
            }
        }

    }
}
