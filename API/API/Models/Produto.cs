namespace API.Models;

public class Produto
{
    public Produto(string nome, string desc, string status, double preco)
    {
        Nome = nome;
        Descricao = desc;
        Status = status;
        Preco = preco;
    }

    public string? Nome { get; set; }
    public string? Descricao { get; set; }
    public string? Status { get; set; }
    public double Preco { get; set; }

    
}

