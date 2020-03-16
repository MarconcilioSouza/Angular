using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartSchool_WebAPI.Data;

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
    }
}