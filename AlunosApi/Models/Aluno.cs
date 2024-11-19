using System.ComponentModel.DataAnnotations;

namespace AlunosApi.Models;

public class Aluno(string nome, string email, int idade)
{
    [Key]
    public string Id { get; private set; } = Guid.NewGuid().ToString();
    [Required]
    [StringLength(40)]
    public string Nome { get; private set; } = nome;
    [EmailAddress]
    [Required]
    [StringLength(30)]
    public string Email { get; private set; } = email;
    [Required]
    public int Idade { get; private set; } = idade;

    public void UpdateAluno(string nome, string email, int idade)
    {
        Nome = nome;
        Email = email;
        Idade = idade;
    }
}
