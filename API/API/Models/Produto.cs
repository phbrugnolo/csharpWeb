using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class Produto
{
    public Produto(string nome, string descricao, string status, double preco, int quantidade)
    {
        Nome = nome;
        Descricao = descricao;
        Status = "Ativo";
        Preco = preco;
        CriadoEm = DateTime.Now;
        Id = Guid.NewGuid().ToString();
        Quantidade = quantidade;
    }

    public string? Id { get; set; }
    // Data Annatations em C#
    [Required(ErrorMessage = "Este campo é obrigaório!")]
    public string? Nome { get; set; }
    [MinLength(3, ErrorMessage = "Este campo deve ter no mínimo 3 caractres")]
    [MaxLength(100, ErrorMessage = "Este campo deve ter no maximo 100 caractres")]
    public string? Descricao { get; set; }
    public string? Status { get; set; }
    [Range(1, double.MaxValue , ErrorMessage = "Este produto deve estar entre 1R$")]
    public double Preco { get; set; }
    public int Quantidade { get; set; }
    public DateTime CriadoEm { get; set; }

}
