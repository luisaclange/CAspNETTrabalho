using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIDeslocamento.Domain.Entities
{
    public class Cliente : BaseEntity
    {
        public Cliente(string nome, string cpf)
        {
            Nome = nome;
            Cpf = cpf;
        }

        public Cliente()
        {
            //Necessário para o entity framework
        }

        public string Nome { get; private set; }
        public string Cpf { get; private set; }
    }
}
