using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace Sql
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string Data_Nascimento { get; set; }
        public string Naturalidade { get; set; }

        public Pessoa() { }

        public Pessoa(
        int id,
        string nome,
        string cpf,
        string rg,
        string data_nascimento,
        string naturalidade)
        {
            this.Id = id;
            this.Nome = nome;
            this.Cpf = cpf;
            this.Rg = rg;
            this.Data_Nascimento = data_nascimento;
            this.Naturalidade = naturalidade;
        }


    }
}
