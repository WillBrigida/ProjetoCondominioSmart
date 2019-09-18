using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoCondominioSmart.Models
{
    public class Pessoa
    {
        public string Nome { get; set; }

        public Pessoa(string nome)
        {
            this.Nome = nome;
        }
    }
}
