using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIDeslocamento.Domain.Interfaces;

namespace APIDeslocamento.Domain.Entities
{
    public class Carro : BaseEntity
    {
        public Carro(string placa, string descricao)
        {
            Placa = placa;
            Descricao = descricao;
        }

        public Carro()
        {
            //Necessário para o entity framework
        }

        public string Placa { get; private set; }
        public string Descricao { get; private set; }
        
    }
}
