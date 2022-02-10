using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIDeslocamento.Domain.Interfaces;

namespace APIDeslocamento.Domain.Entities
{
    public class Deslocamento : BaseEntity
    {
        public Deslocamento(long carroId, long clienteId, long condutorId, DateTime dataHoraInicio, double quilometragemInicial)
        {
            CarroId = carroId;
            ClienteId = clienteId;
            CondutorId = condutorId;
            DataHoraInicio = dataHoraInicio;
            QuilometragemInicial = quilometragemInicial;
        }

        public Deslocamento()
        {
            //Necessário para o entity framework
        }

        public long CarroId { get; private set; }
        public long ClienteId { get; private set; }
        public long CondutorId { get; private set;}
        public DateTime DataHoraInicio { get; private set; }
        public double QuilometragemInicial { get; private set; }
        public double QuilometragemFinal { get; private set; }
        public string Observacao { get; private set; }
        public DateTime DataHoraFim { get; private set; }

        public void FinalizarDeslocamento(string observacao, double quilometragemfinal)
        {
            QuilometragemFinal = quilometragemfinal;
            Observacao = observacao;
            DataHoraFim = DateTime.Now; 
        }

    }
}
