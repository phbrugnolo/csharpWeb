var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<Produto> listaProd = new List<Produto>(){
    new Produto("Celular", "Android"),
    new Produto("Carro", "Foda"),
    new Produto("Computador", "Tem 3090"),
    new Produto("Mouse", "Ergonomico")

};


//End Points
app.MapPost("/api/produtos", () => "Api ruim com watch!");

app.MapGet("/api/produtos", () => listaProd);

app.Run();

public record Produto(string nome, string desc);