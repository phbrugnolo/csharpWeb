using System.ComponentModel.DataAnnotations;
using API.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
//Registrar o serviço do banco de dados na aplicação
builder.Services.AddDbContext<AppDataContext>();
var app = builder.Build();


List<Produto> Produtos = new List<Produto>();


//End Points
//Cadastrar um produto na lista

app.MapPost("/api/produtos/cadastrar/", ([FromBody] Produto produto, [FromServices] AppDataContext context) =>
{

    //Validando os atributos da tabela no DB
    List<ValidationResult> errors = new List<ValidationResult>();
    if(!Validator.TryValidateObject(produto, new ValidationContext(produto), errors, true)){
        return Results.BadRequest(errors);
    }

    Produto? produtoBuscado = context.Produtos.FirstOrDefault(x => x.Nome == produto.Nome);

    if (produtoBuscado is null)
    {
        // produto.Nome = produto.Nome.ToUpper();
        context.Produtos.Add(produto);
        context.SaveChanges();
        return Results.Created("Produto cadastrado com sucessos", produto);
    }
    return Results.BadRequest("Já existe um produto com este nome");

});

//GET  http://localhost:{porta}/api/produtos
app.MapGet("/api/produtos/listar", ([FromServices] AppDataContext context) =>
{

    if (context.Produtos.Any()) return Results.Ok(context.Produtos.ToList());
    return Results.NotFound("Produto não encontrado");

});

// Deletando Produto
app.MapDelete("/api/produtos/remover/{nome}", ([FromRoute] string nome, [FromServices] AppDataContext context) =>
{
    Produto? produto = context.Produtos.FirstOrDefault(x => x.Nome == nome);

    if (produto is not null)
    {
        context.Produtos.Remove(produto);
        context.SaveChanges();
        return Results.Ok("Produto removido com suceso");
    }

    return Results.NotFound("Produto não Encontrado");
});

app.MapPut("/api/produtos/edit/{nome}", ([FromRoute] string nome, [FromBody] Produto pAtualizado, [FromServices] AppDataContext context) =>
{
    Produto? produto = context.Produtos.FirstOrDefault(x => x.Nome == nome);

    if (produto is not null)
    {
        produto.Nome = pAtualizado.Nome;
        produto.Descricao = pAtualizado.Descricao;
        produto.Status = pAtualizado.Status;
        produto.Preco = pAtualizado.Preco;
        produto.Quantidade = pAtualizado.Quantidade;
        context.Produtos.Update(produto);
        context.SaveChanges();
        return Results.Ok("Produto editado com suceso");

    }
    return Results.NotFound("Produto não Encotrado");
});

//GET  http://localhost:{porta}/api/buscar{product.nome}
app.MapGet("/api/produtos/buscar/{nome}", ([FromRoute] string nome, [FromServices] AppDataContext context) =>
{
    //Endpoint com várias linhas de código 
    Produto? produto = context.Produtos.FirstOrDefault(x => x.Nome == nome);

    if (produto is null) return Results.NotFound("Produto não Encotrado");
    return Results.Ok(produto);

});



app.Run();
