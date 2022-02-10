using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIDeslocamento.Domain.Interfaces;

namespace APIDeslocamento.Domain.Entities
{
    public class Condutor : BaseEntity
    {
        public Condutor(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }

        public Condutor()
        {
            //Necessário para o entity framework
        }

        public string Nome { get; private set;}
        public string Email { get; private set; }
    }
}
