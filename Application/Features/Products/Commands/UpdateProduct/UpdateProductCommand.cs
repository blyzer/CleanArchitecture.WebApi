using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Rate { get; set; }
        public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Response<Guid>>
        {
            private readonly IProductRepositoryAsync _productRepository;
            private readonly IGenericUnitOfWork _unitOfWork;

            public UpdateProductCommandHandler(IProductRepositoryAsync productRepository, IGenericUnitOfWork unitOfWork)
            {
                _productRepository = productRepository;
                _unitOfWork = unitOfWork;
            }
            public async Task<Response<Guid>> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
            {
                var product = await _productRepository.GetByIdAsync(command.Id).ConfigureAwait(false);

                if (product == null)
                {
                    throw new ApiException($"Product Not Found.");
                }
                else
                {
                    product.Name = command.Name;
                    product.Rate = command.Rate;
                    product.Description = command.Description;
                    await _productRepository.UpdateAsync(product).ConfigureAwait(false);
                    await _unitOfWork.Commit<Guid>(cancellationToken).ConfigureAwait(false);
                    return new Response<Guid>(product.Id);
                }
            }
        }
    }
}