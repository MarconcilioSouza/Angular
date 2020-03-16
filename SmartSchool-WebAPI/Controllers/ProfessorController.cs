using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartSchool_WebAPI.Data;
using SmartSchool_WebAPI.Models;

namespace SmartSchool_WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly IRepository repository;
        public ProfessorController(IRepository repo)
        {
            repository = repo;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var professores = await repository.GetAllProfessoresAsync(true);
                return Ok(professores);
            }
            catch (System.Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        [HttpGet("{professorId}")]
        public async Task<IActionResult> GetByProfessorId(int professorId)
        {
            try
            {
                var professor = await repository.GetProfessorAsyncById(professorId, true);
                return Ok(professor);
            }
            catch (System.Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        [HttpGet("ByAluno/{alunoId}")]
        public async Task<IActionResult> GetByAlunoId(int alunoId)
        {
            try
            {
                var professor = await repository.GetProfessoresAsyncByAlunoId(alunoId, true);
                return Ok(professor);
            }
            catch (System.Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Professor professor)
        {
            try
            {
                repository.Add(professor);
                if(await repository.SaveChangesAsync())
                return Ok(professor);
            }
            catch (System.Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }

            return BadRequest("Erro não esperado");
        }

        [HttpPut("{professorId}")]
        public async Task<IActionResult> Put(int professorId, Professor model)
        {
            try
            {
                 var professor = await repository.GetProfessorAsyncById(professorId, false);
                 if(professor == null)
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

        [HttpDelete("{professorId}")]
        public async Task<IActionResult> Delete(int professorId, Professor model)
        {
            try
            {
                 var professor = await repository.GetProfessorAsyncById(professorId, false);
                 if(professor == null)
                    return NotFound();

                repository.Delete(professor);
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