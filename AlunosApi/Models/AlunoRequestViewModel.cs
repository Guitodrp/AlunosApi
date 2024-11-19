using System.ComponentModel.DataAnnotations;

namespace AlunosApi.Models;

public class AlunoRequestViewModel
{
    [Required]
    [StringLength(40)]
    public string Nome { get; set; }

    [EmailAddress]
    [Required]
    [StringLength(40)]
    public string Email { get; set; }

    [Required]
    [Range(0, 25)]
    public int Idade { get; set; }

}
