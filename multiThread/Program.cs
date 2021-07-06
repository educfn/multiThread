using System;
using System.Threading.Tasks;

namespace multiThread
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }


        static async Task criarTextoJSON(SimpleClass simple)
        {
            //TO DO: Preencher o metodo 'criarTextoJSON' para gerar .txt em JSON. Usar a extensão 'Newtonsoft'.
            throw new NotImplementedException;
        }

        static async Task criarTextoNomeVariavel(SimpleClass simple)
        {
            //TO DO: Preencher o metodo 'criarTextoNomeVariavel' para gerar .txt da seguinte forma: 'NomeVariavel:ValorVariavel'.
            throw new NotImplementedException;
        }

        static async Task printarJSON_No_Console(SimpleClass simple)
        {
            //TO DO: Preencher o metodo 'printarJSON_No_Console' este metodo deve "printar" no console a classe no formato JSON.
            throw new NotImplementedException;
        }

    }
}
