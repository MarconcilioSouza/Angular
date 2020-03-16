using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartSchool_WebAPI.Data;
using SmartSchool_WebAPI.Models;

namespace SmartSchool_WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly IRepository repository;
        public AlunoController(IRepository repo)
        {
            repository = repo;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var alunos = await repository.GetAllAlunosAsync(true);
                return Ok(alunos);
            }
            catch (System.Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        [HttpGet("{alunoId}")]
        public async Task<IActionResult> GetByAlunoId(int alunoId)
        {
            try
            {
                var aluno = await repository.GetAlunoAsyncById(alunoId, true);
                return Ok(aluno);
            }
            catch (System.Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        [HttpGet("bydisciplina/{disciplinaId}")]
        public async Task<IActionResult> GetByDisciplinaId(int disciplinaId)
        {
            try
            {
                var result = await repository.GetAlunosAsyncByDisciplinaId(disciplinaId, true);
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post(Aluno aluno)
        {
            try
            {
                repository.Add(aluno);
                if(await repository.SaveChangesAsync())
                return Ok(aluno);
            }
            catch (System.Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }

            return BadRequest("Erro não esperado");
        }

        [HttpPut("{AlunoId}")]
        public async Task<IActionResult> Put(int AlunoId, Aluno model)
        {
            try
            {
                 var aluno = await repository.GetAlunoAsyncById(AlunoId, false);
                 if(aluno == null)
                    return NotFound();

                repository.Update(model);
                if(await repository.SaveChangesAsync())
                    return Ok(model);
            }
            catch (System.Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }

            return BadRequest("Erro não esperado");
        }

        [HttpDelete("{AlunoId}")]
        public async Task<IActionResult> Delete(int AlunoId, Aluno model)
        {
            try
            {
                 var aluno = await repository.GetAlunoAsyncById(AlunoId, false);
                 if(aluno == null)
                    return NotFound();

                repository.Delete(aluno);
                if(await repository.SaveChangesAsync())
                    return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }

            return BadRequest("Erro não esperado");
        }
    }
}