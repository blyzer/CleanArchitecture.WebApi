using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Products.Commands.DeleteProductById
{
    public class DeleteProductByIdCommand : IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
        public class DeleteProductByIdCommandHandler : IRequestHandler<DeleteProductByIdCommand, Response<Guid>>
        {
            private readonly IProductRepositoryAsync _productRepository;
            private readonly IGenericUnitOfWork _unitOfWork;

            public DeleteProductByIdCommandHandler(IProductRepositoryAsync productRepository, IGenericUnitOfWork unitOfWork)
            {
                _productRepository = productRepository;
                _unitOfWork = unitOfWork;
            }
            public async Task<Response<Guid>> Handle(DeleteProductByIdCommand command, CancellationToken cancellationToken)
            {
                var product = await _productRepository.GetByIdAsync(command.Id).ConfigureAwait(false);
                if (product == null) throw new ApiException($"Product Not Found.");
                await _productRepository.DeleteAsync(product).ConfigureAwait(false);
                await _unitOfWork.Commit<Guid>(cancellationToken).ConfigureAwait(false);
                return new Response<Guid>(product.Id);
            }
        }
    }
}