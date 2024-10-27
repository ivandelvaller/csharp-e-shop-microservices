using Carter;
using MediatR;
using Mapster;

namespace Catalog.API.Features.Products.CreateProduct;

public record CreateProductRequest(
    Guid Id,
    string Name,
    string Description,
    string ImageUrl,
    decimal Price);

public record CreateProductResponse(Guid Id);

public class CreateProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/products", async (CreateProductRequest request, ISender sender) =>
            {
                var command = request.Adapt<CreateProductCommand>();

                var result = await sender.Send(command);

                var response = request.Adapt<CreateProductResponse>();

                return Results.Created($"/products/{result.Id}", response);
            })
            .WithName("Create Product")
            .Produces<CreateProductResult>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Create a Product")
            .WithDescription("Create a Product");
    }
}