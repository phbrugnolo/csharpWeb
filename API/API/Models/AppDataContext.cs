using Microsoft.EntityFrameworkCore;

namespace API.Models;

public class AppDataContext : DbContext
{
    //Entity Framework Code First
    //Quais classes que vão representar as tabelas no banco
    public DbSet<Produto> Produtos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Configuração da String de conexão
        optionsBuilder.UseSqlite("Data Source=app.db");
    }
}
