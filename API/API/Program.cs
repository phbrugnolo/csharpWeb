using API.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


List<Produto> listaProdutos = new List<Produto>(){
    new Produto("Celular", "Android", "Active", 1700.00),
    new Produto("Carro", "Veloz", "Inactive", 20000.00),
    new Produto("Computador", "Gamer", "Active", 7850.99),
    new Produto("Mouse", "Ergonomico", "Active", 10.99)

};


//End Points
//Cadastrar um produto na lista
// a) Atraves das informações da url
// b) Atraves das informações no corpo da requisação
// Realizar as operações de alterções e remoção da lista
app.MapPost("/api/produtos/cadastrar/{nome}/{descricao}", ([FromRoute] string nome, [FromRoute] string descricao) => {

    // Preenchendo pelo constructor
    Produto produto = new Produto(nome, descricao, "Active", 123);

    //Preenchendo pelo atributo
    produto.Nome = nome;
    produto.Descricao = descricao;
    produto.Status = "Active";
    produto.Preco = 123;

    //Adicionando o produto dentra da lista
    listaProdutos.Add(produto);
    return Results.Created("", produto);
});

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
    return Results.NotFound("Produto não Encotrado");
});



app.Run();
