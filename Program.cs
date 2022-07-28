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

            //Console.WriteLine("digite o nome : ");
            //nome = Convert.ToString(Console.ReadLine());
            //Console.WriteLine("digite o cpf : ");
            //cpf = Convert.ToString(Console.ReadLine());
            //Console.WriteLine("digite o rg : ");
            //rg = Convert.ToString(Console.ReadLine());
            //Console.WriteLine("digite a data de nascimento : ");
            //data_nascimento = Convert.ToString(Console.ReadLine());
            //Console.WriteLine("digite o naturalidade : ");
            //naturalidade = Convert.ToString(Console.ReadLine());

            //CadastrarPessoa cadastrar = new CadastrarPessoa(nome, cpf, rg, data_nascimento, naturalidade);

            //CadastrarPessoa listar = new CadastrarPessoa();
            //listar.ListarPessoas();



            DB_Conect conexao = new DB_Conect();
            SqlCommand cmd = new SqlCommand();
            String mensagem = "";
            string connection = @"Data Source=ITELABD13\SQLEXPRESS;Initial Catalog=Cadastro;Integrated Security=True";

            List<Pessoa> pessoas = new List<Pessoa>();
            try
            {
                SqlDataReader resultado;
                var query = @"SELECT Id, Nome, Cpf, Rg, DataNascimento, Naturalidade FROM Pessoa";
                using (var sql = new SqlConnection(connection))
                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Connection.Open();
                    resultado = command.ExecuteReader();

                    while (resultado.Read())
                    {
                        pessoas.Add(new Pessoa(resultado.GetInt32(resultado.GetOrdinal("Id")),
                                               resultado.GetString(resultado.GetOrdinal("Nome")),
                                               resultado.GetString(resultado.GetOrdinal("Cpf")),
                                               resultado.GetString(resultado.GetOrdinal("Rg")),
                                               resultado.GetDateTime(resultado.GetOrdinal("DataNascimento")),
                                               resultado.GetString(resultado.GetOrdinal("Naturalidade"))));
                    }
                }
                Console.WriteLine("========Listagem========");
                foreach (Pessoa p in pessoas)
                {
                    Console.WriteLine("========Inicio========");
                    Console.WriteLine("Nome: " + p.Nome);
                    Console.WriteLine("CPF: " + p.Cpf);
                    Console.WriteLine("Rg: " + p.Rg);
                    Console.WriteLine("Naturalidade: " + p.Naturalidade);
                    Console.WriteLine("Data de Nascimento: " + p.DataNascimento);
                    Console.WriteLine("========Fim========");
                }
            }
            catch (Exception)
            {
                mensagem = "Erro!";
            }


        }
    }
}
