using AlunosApi.Configurations;
using AlunosApi.Models;
using AlunosApi.Repositories.Interface;
using MongoDB.Driver;

namespace AlunosApi.Repositories.Implementation;

public class AlunosRepository : IAlunosRepository
{
    private readonly IMongoCollection<Aluno> _alunos;

    public AlunosRepository(IDatabaseConfig databaseConfig)
    {
        var client = new MongoClient(databaseConfig.ConnectionString);
        var database = client.GetDatabase(databaseConfig.DatabaseName);

        _alunos = database.GetCollection<Aluno>("alunos");
    }

    public void InsertAluno(Aluno aluno) => _alunos.InsertOne(aluno);

    public void UpdateAluno(string id, Aluno newAluno) => _alunos.ReplaceOne(s => s.Id == id, newAluno);

    public Aluno GetAlunoById(string id) => _alunos.Find(s => s.Id == id).SingleOrDefault();

    public List<Aluno> GetAlunos() => _alunos.Find(s => true).ToList();

    public void DeleteAluno(string id) => _alunos.FindOneAndDelete(s => s.Id == id);

}

