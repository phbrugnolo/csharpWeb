using API.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


List<Produto> listaProdutos = new List<Produto>(){
    new Produto("Celular", "Android", "Active", 1700.00),
    new Produto("Carro", "Foda", "Inactive", 20000.00),
    new Produto("Computador", "Tem 3090", "Active", 7850.99),
    new Produto("Mouse", "Ergonomico", "Active", 10.99)

};


//End Points
//Cadastrar um produto na lista
// a) Atraves das informações da url
// b) Atraves das informações no corpo da requisação
// Realizar as operações de alterções e remoção da lista
app.MapPost("/api/produtos/cadastrar", () => "Api com watch desfuncional!");

//GET  http://localhost:{porta}/api/produtos
app.MapGet("/api/produtos/listar", () => listaProdutos);

//GET  http://localhost:{porta}/api/buscar{product.nome}
app.MapGet("/api/produtos/buscar/{nome}", ([FromRoute] string nome) =>
{
    //Endpoint com várias linhas de código 
    for (int i = 0; i < listaProdutos.Count; i++)
    {
        if (listaProdutos[i].Nome == nome)
        {
            return Results.Ok(listaProdutos[i]);
        }
    }
    return Results.NotFound();
});

app.Run();
