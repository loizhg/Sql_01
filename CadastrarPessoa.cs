using System;
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
    }
}
