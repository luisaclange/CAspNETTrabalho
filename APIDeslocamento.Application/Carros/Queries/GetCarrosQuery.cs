﻿using APIDeslocamento.Domain.Entities;
using APIDeslocamento.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace APIDeslocamento.Application.Carros.Queries
{
    public class GetCarrosQuery : IRequest<List<Carro>>
    {

    }

    public class GetCarrosQueryHandler : IRequestHandler<GetCarrosQuery, List<Carro>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCarrosQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Carro>> Handle(GetCarrosQuery request, CancellationToken cancellationToken)
        {
            var repositoryCarro = _unitOfWork.GetRepository<Carro>();

            //cria um filtro informando que deve buscar todos os documentos
            var carroQuery = repositoryCarro.GetAll();

            //executa de fato a consulta
            var Carros = await carroQuery
                .ToListAsync(cancellationToken);

            return Carros;
        }
    }
}

