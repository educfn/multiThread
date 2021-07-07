using System;
using System.Threading.Tasks;

namespace multiThread
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleClass classeSimples = new SimpleClass();

            Console.WriteLine("Hello World!");
        }

        public void coletarValoresDoUsuario(ref SimpleClass simple)
        {
            if (simple == null)
            {
                throw new NullReferenceException();
            }

            Console.WriteLine("\nDigite um numero inteiro: ");
            simple.inteiroQualquer = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite um texto: ");
            simple.stringQualquer = Console.ReadLine();
            Console.WriteLine("Digite um numero decimal: ");
            simple.floatQualquer = float.Parse(Console.ReadLine());
            Console.WriteLine("Digite outro numero decimal: ");
            simple.doubleQualquer = double.Parse(Console.ReadLine());
            Console.WriteLine("Digite uma letra, numero[0-9] ou simbolo: ");
            string tempString = Console.ReadLine();
            simple.charQualquer = tempString[0];
        }

        #region metodos async
        static async Task criarTextoJSON(SimpleClass simple)
        {
            //TO DO: Preencher o metodo 'criarTextoJSON' para gerar .txt em JSON. Usar a extensão 'Newtonsoft'.
            throw new NotImplementedException();
        }

        static async Task criarTextoNomeVariavel(SimpleClass simple)
        {
            //TO DO: Preencher o metodo 'criarTextoNomeVariavel' para gerar .txt da seguinte forma: 'NomeVariavel:ValorVariavel'.
            throw new NotImplementedException();
        }

        static async Task printarJSON_No_Console(SimpleClass simple)
        {
            //TO DO: Preencher o metodo 'printarJSON_No_Console' este metodo deve "printar" no console a classe no formato JSON.
            throw new NotImplementedException();
        }

        #endregion metodos async

        //TO DO: Criar metodo 'test', o mesmo ira preencher, com valores aleatórios, uma instancia da classe 'SimpleClass' que será recebida e 'retornara' a mesma.

    }
}
