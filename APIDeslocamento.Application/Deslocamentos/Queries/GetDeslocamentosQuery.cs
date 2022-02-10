using APIDeslocamento.Domain.Entities;
using APIDeslocamento.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace APIDeslocamento.Application.Deslocamentos.Queries
{
    public class GetDeslocamentosQuery : IRequest<List<Deslocamento>>
    {
    }

    public class GetDeslocamentosQueryHandler : IRequestHandler<GetDeslocamentosQuery, List<Deslocamento>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetDeslocamentosQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Deslocamento>> Handle(GetDeslocamentosQuery request, CancellationToken cancellationToken)
        {
            var repositoryDeslocamento = _unitOfWork.GetRepository<Deslocamento>();

            //cria um filtro informando que deve buscar todos os documentos
            var DeslocamentoQuery = repositoryDeslocamento.GetAll();

            //executa de fato a consulta
            var Deslocamentos = await DeslocamentoQuery
                .ToListAsync(cancellationToken);

            return Deslocamentos;
        }
    }
}

