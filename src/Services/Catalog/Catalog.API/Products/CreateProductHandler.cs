﻿using BuidingBlocks.CQRS;
using Catalog.API.Models;
using MediatR;
using System.Windows.Input;

namespace Catalog.API.Products
{

    public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price) :ICommand<CreateProductResult>;

    public record CreateProductResult(Guid Id);
    public class CreateProductHandler  : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = command.Name,
                Category = command.Category,
                Description = command.Description,
                ImageFile = command.ImageFile,
                Price = command.Price,
            };


            return new CreateProductResult(Guid.NewGuid());
           
        }
    }
}
