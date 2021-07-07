﻿using System;
using System.IO;
using System.Threading.Tasks;

namespace multiThread
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleClass classeSimples = new SimpleClass();

            test(ref classeSimples);
            escreverClasseNoConsole(classeSimples);

            criarTextoJSON(classeSimples);

        }

        #region coleta_valores_do_usuario
        public void coletarValoresDoUsuario(ref SimpleClass simple)
        {
            if (simple == null)
            {
                throw new NullReferenceException();
            }

            Console.WriteLine("\nDigite um numero inteiro: ");
            simple.InteiroQualquer = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite um texto: ");
            simple.StringQualquer = Console.ReadLine();
            Console.WriteLine("Digite um numero decimal: ");
            simple.FloatQualquer = float.Parse(Console.ReadLine());
            Console.WriteLine("Digite outro numero decimal: ");
            simple.DoubleQualquer = double.Parse(Console.ReadLine());
            Console.WriteLine("Digite uma letra, numero[0-9] ou simbolo: ");
            string tempString = Console.ReadLine();
            simple.CharQualquer = tempString[0];
        }
        #endregion coleta_valores_do_usuario

        #region metodos async
        static async Task criarTextoJSON(SimpleClass simple)
        {
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(simple);

            string caminho = @"C:\Users\Eduardo CFN\Desktop\",
                //TODO: Qualidade: Perguntar ao usuario aonde quer salvar. Usar função que mostra o caminho para salvar.
                   nomeDoArquivo = "json.txt";
            try
            {
                File.WriteAllText(caminho + nomeDoArquivo, json);              
            }
            catch (Exception) { }

            await Task.Delay(1);

            
        }

        static async Task criarTextoNomeVariavel(SimpleClass simple)
        {
            //TODO: Preencher o metodo 'criarTextoNomeVariavel' para gerar .txt da seguinte forma: 'NomeVariavel:ValorVariavel'.
            throw new NotImplementedException();
        }

        static async Task printarJSON_No_Console(SimpleClass simple)
        {
            //TODO: Preencher o metodo 'printarJSON_No_Console' este metodo deve "printar" no console a classe no formato JSON.
            throw new NotImplementedException();
        }

        #endregion metodos async

        #region metodos_de_teste
        //TODO: Criar metodo 'test', o mesmo ira preencher, com valores aleatórios, uma instancia da classe 'SimpleClass' que será recebida por referencia.
        public static void test(ref SimpleClass simple)
        {
            if (simple == null)
            {
                throw new NullReferenceException();
            }

            Random rand = new Random();

            int charaterMaxUnicode = 'a', charaterMinUnicode = 'Z',
                ascii_digitos_comeco = 48, ascii_alfabeto_latino_fim = 122;

            //Inteiro Aleatorio
            simple.InteiroQualquer = rand.Next(int.MinValue, int.MaxValue);
            //string Aleatorio
            string temp = "";

            for (int i = 0; i < rand.Next(0, 50); i++) 
            {
                temp += (char)rand.Next(ascii_digitos_comeco, ascii_alfabeto_latino_fim);
            }

            simple.StringQualquer = temp;
            //Float Aleatorio
            simple.FloatQualquer =  (float) rand.Next(int.MinValue, int.MaxValue) + (float) rand.NextDouble();
            //Double Aleatorio
            simple.DoubleQualquer = (double)rand.Next(int.MinValue, int.MaxValue) + rand.NextDouble();
            //Char Aleatorio
            simple.CharQualquer = (char) rand.Next(charaterMinUnicode, charaterMaxUnicode);



    }

        public static void escreverClasseNoConsole(SimpleClass simple) 
        {
            if (simple == null)
            {
                throw new ArgumentNullException();
            }

            Console.WriteLine("Inteiro Qualquer: " + simple.InteiroQualquer);
            Console.WriteLine("Float Qualquer: " + simple.FloatQualquer);
            Console.WriteLine("Double Qualquer: " + simple.DoubleQualquer);
            Console.WriteLine("Char Qualquer: " + simple.CharQualquer);
            Console.WriteLine("string qualquer: " + simple.StringQualquer);
            //Criando um expaço para os proximos output´s.
            Console.Write("\n\n");
        }

        #endregion metodos_de_teste

    }
}
