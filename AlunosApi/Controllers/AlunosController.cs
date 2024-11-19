using AlunosApi.Models;
using AlunosApi.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace AlunosApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AlunosController(IAlunosRepository repository) : ControllerBase
{

    [HttpGet]
    public IActionResult GetAlunos()
    {
        var alunos = repository.GetAlunos();

        if (alunos == null)
            return NotFound();

        return Ok(alunos);
    }

    [HttpGet("{id}")]
    public IActionResult GetAluno(string id)
    {
        var aluno = repository.GetAlunoById(id);

        if (aluno == null)
            return NotFound();

        return Ok(aluno);
    }

    [HttpPost]
    public IActionResult InsertAluno([FromBody] AlunoRequestViewModel request)
    {
        var aluno = new Aluno(
            nome: request.Nome,
            email: request.Email,
            idade: request.Idade
            );

        repository.InsertAluno(aluno);
        return Created("", aluno);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateAluno(string id, [FromBody] AlunoRequestViewModel request)
    {
        var aluno = repository.GetAlunoById(id);
        aluno.UpdateAluno(request.Nome, request.Email, request.Idade);

        repository.UpdateAluno(id, aluno);
        return Ok(aluno);
    }

    [HttpDelete("{id}")]
    public void Delete(string id) => repository.DeleteAluno(id);
}
