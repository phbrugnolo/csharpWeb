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

app.MapPost("/api/produtos/cadastrar/", ([FromBody] Produto produto) => {
    //Adicionando o produto dentro da lista
    listaProdutos.Add(produto);
    return Results.Created("", produto);
});

// Deletando Produto
app.MapDelete("/api/produtos/remover/{nome}", ([FromRoute] string nome) => {

    for (int i = 0; i < listaProdutos.Count; i++)
    {
        if (listaProdutos[i].Nome == nome)
        {
            listaProdutos.Remove(listaProdutos[i]);
            return Results.Ok("Produto removido com suceso");
        }
    }
    return Results.NotFound("Produto não Encontrado");
});

app.MapPut("/api/produtos/edit/{nome}", ([FromRoute] string nome, [FromBody] Produto pAtualizado) => {

    for (int i = 0; i < listaProdutos.Count; i++)
    {
        if (listaProdutos[i].Nome == nome)
        {
            listaProdutos[i].Nome = pAtualizado.Nome;
            listaProdutos[i].Descricao = pAtualizado.Descricao;
            listaProdutos[i].Status = pAtualizado.Status;
            listaProdutos[i].Preco = pAtualizado.Preco;
            return Results.Ok("Produto editado com suceso");
        }
    }
    return Results.NotFound("Produto não Encotrado");
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
