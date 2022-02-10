using APIDeslocamento.Domain.Entities;
using APIDeslocamento.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace APIDeslocamento.Application.Clientes.Queries
{
    public class GetClientesQuery : IRequest<List<Cliente>>
    {
    }

    public class GetClientesQueryHandler : IRequestHandler<GetClientesQuery, List<Cliente>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetClientesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Cliente>> Handle(GetClientesQuery request, CancellationToken cancellationToken)
        {
            var repositoryCliente = _unitOfWork.GetRepository<Cliente>();

            //cria um filtro informando que deve buscar todos os documentos
            var clienteQuery = repositoryCliente.GetAll();


            //executa de fato a consulta
            var clientes = await clienteQuery
                .ToListAsync(cancellationToken);

            return clientes;
        }
    }
}

