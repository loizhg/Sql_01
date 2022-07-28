﻿using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace Sql
{
    public class CadastrarPessoa
    {
        DB_Conect conexao = new DB_Conect();
        SqlCommand cmd = new SqlCommand();
        public String mensagem = "";
        List<Pessoa> pessoas = new List<Pessoa>();

        public CadastrarPessoa() { }

        public CadastrarPessoa(
        string nome,
        string cpf,
        string rg,
        string data_nascimento,
        string naturalidade)
        {
            // comando sql
            cmd.CommandText = "insert into Pessoa (Nome, Cpf, Rg, DataNascimento, Naturalidade) values (@nome, @cpf, @rg, @data_nascimento, @naturalidade)";

            using (var sql = new SqlConnection())
            {
                //parametros
                cmd.Parameters.AddWithValue("@nome", nome);
                cmd.Parameters.AddWithValue("@cpf", cpf);
                cmd.Parameters.AddWithValue("@rg", rg);
                cmd.Parameters.AddWithValue("@data_nascimento", data_nascimento);
                cmd.Parameters.AddWithValue("@naturalidade", naturalidade);

                //conectar com banco
                try
                {
                    //conexao
                    cmd.Connection = conexao.conectar();
                    //executar comando
                    cmd.ExecuteNonQuery();
                    //desconectar
                    conexao.desconectar();
                    //mensagem de erro
                    this.mensagem = "Cadastrado!";
                }
                catch (Exception)
                {
                    this.mensagem = "Erro!";
                }
            }
        }

        public void ListarPessoas()
        {
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
