using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace Sql
{
    class Program
    {
        static void Main(string[] args)
        {
            string nome;
            string cpf;
            string rg;
            DateTime data_nascimento;
            string naturalidade;


            Console.WriteLine("digite o nome : ");
            nome = Convert.ToString(Console.ReadLine());
            Console.WriteLine("digite o cpf : ");
            cpf = Convert.ToString(Console.ReadLine());
            Console.WriteLine("digite o rg : ");
            rg = Convert.ToString(Console.ReadLine());
            Console.WriteLine("digite a data de nascimento : ");
            data_nascimento = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("digite o naturalidade : ");
            naturalidade = Convert.ToString(Console.ReadLine());


            CadastrarPessoa cadastrar = new CadastrarPessoa(nome, cpf, rg, data_nascimento, naturalidade);

            CadastrarPessoa listar = new CadastrarPessoa();
            listar.ListarPessoas();



            CadastrarPessoa atualizar = new CadastrarPessoa();
            atualizar.AtualizarPessoa(nome, cpf, rg, data_nascimento, naturalidade);






        }
    }
}
