using BuildingBlocks.CQRS;
using Catalog.API.Models;

namespace Catalog.API.Features.Products.CreateProduct;

public record CreateProductCommand(
    string Name,
    List<string> Category,
    string Description,
    string ImageUrl,
    decimal Price)
    : ICommand<CreateProductResult>;

public record CreateProductResult(Guid Id);

internal class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Name = command.Name,
            Categories = command.Category,
            Description = command.Description,
            ImageUrl = command.ImageUrl,
            Price = command.Price,
        };

        return new CreateProductResult(Guid.NewGuid());
    }
}