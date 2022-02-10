using APIDeslocamento.Domain.Entities;
using APIDeslocamento.Domain.Interfaces;
using MediatR;

namespace APIDeslocamento.Application.Carros.Commands.CriarCarro
{
    public class CriarCarroCommand : IRequest<Carro>
    {
        public string Placa { get; set; }

        public string Descricao { get; set; }
    }

    public class CriarCarroCommandHandler : IRequestHandler<CriarCarroCommand, Carro>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CriarCarroCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Carro> Handle(
            CriarCarroCommand request,
            CancellationToken cancellationToken)
        {
            var carroInserir = new Carro(request.Placa, request.Descricao);

            var repositoryCarro = _unitOfWork.GetRepository<Carro>();

            repositoryCarro.Add(carroInserir);

            await _unitOfWork.CommitAsync();

            return carroInserir;
        }
    }
}
