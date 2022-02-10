using APIDeslocamento.Domain.Entities;
using APIDeslocamento.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace APIDeslocamento.Application.Condutores.Queries
{
    public class GetCondutoresQuery : IRequest<List<Condutor>>
    {

    }

    public class GetCondutoresQueryHandler : IRequestHandler<GetCondutoresQuery, List<Condutor>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCondutoresQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Condutor>> Handle(GetCondutoresQuery request, CancellationToken cancellationToken)
        {
            var repositoryCondutor = _unitOfWork.GetRepository<Condutor>();

            //cria um filtro informando que deve buscar todos os documentos
            var condutorQuery = repositoryCondutor.GetAll();


            //executa de fato a consulta
            var condutores = await condutorQuery
                .ToListAsync(cancellationToken);

            return condutores;
        }
    }
}

