namespace API.Models;

public class Produto
{
    public Produto(string nome, string descricao, string status, double preco)
    {
        Nome = nome;
        Descricao = descricao;
        Status = status;
        Preco = preco;
        CriadoEm = DateTime.Now;
        Id = Guid.NewGuid().ToString();
    }

    public string? Id { get; set; }
    public string? Nome { get; set; }
    public string? Descricao { get; set; }
    public string? Status { get; set; }
    public double Preco { get; set; }
    public DateTime CriadoEm { get; set; }

}
