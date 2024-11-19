using AlunosApi.Models;

namespace AlunosApi.Repositories.Interface;

public interface IAlunosRepository
{
    public void InsertAluno(Aluno aluno);
    public void UpdateAluno(string id, Aluno newAluno);
    public Aluno GetAlunoById(string id);
    public List<Aluno> GetAlunos(); 
    public void DeleteAluno(string id);

}
