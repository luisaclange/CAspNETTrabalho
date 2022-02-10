using APIDeslocamento.Domain.Entities;
using APIDeslocamento.Domain.Interfaces;
using MediatR;

namespace APIDeslocamento.Application.Clientes.Commands.CriarCliente
{
    public class CriarClienteCommand : IRequest<Cliente>
    {
        public string Nome { get; set; }

        public string Cpf { get; set; }
    }

    public class CriarClienteCommandHandler : IRequestHandler<CriarClienteCommand, Cliente>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CriarClienteCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Cliente> Handle(
            CriarClienteCommand request,
            CancellationToken cancellationToken)
        {
            var clienteInserir = new Cliente(request.Nome, request.Cpf);

            var repositoryCliente = _unitOfWork.GetRepository<Cliente>();

            repositoryCliente.Add(clienteInserir);

            await _unitOfWork.CommitAsync();

            return clienteInserir;
        }
    }
}