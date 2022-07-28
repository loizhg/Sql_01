using System;

namespace Sql
{
    class Program
    {
        static void Main(string[] args)
        {
            string nome;
            string cpf;
            string rg;
            string data_nascimento;
            string naturalidade;

            Console.WriteLine("Digite o nome : ");
            nome = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Digite o cpf : ");
            cpf = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Digite o rg : ");
            rg = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Digite a data de nascimento : ");
            data_nascimento = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Digite o naturalidade : ");
            naturalidade = Convert.ToString(Console.ReadLine());

            CadastrarPessoa cadastrar = new CadastrarPessoa(nome, cpf, rg, data_nascimento, naturalidade);

        }
    }
}
