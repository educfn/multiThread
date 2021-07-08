using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace multiThread
{
    class Program
    {
        static void Main(string[] args)
        {
            mainASync().GetAwaiter().GetResult();
        }

        #region coleta_valores_do_usuario
        public static void coletarValoresDoUsuario(ref SimpleClass simple)
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

        static async Task mainASync()
        {
            //TODO: Qualidade: Perguntar ao usuario aonde quer salvar e o nome do arquivo. Usar função que mostra o caminho para salvar.
            const string localParaSalvarArquivos = "C:\\Users\\Eduardo CFN\\Desktop\\Pasta_de_Textos\\"; //<<<====Guilherme altere aqui===============
            int quantidadeDeClassesParaCriar = 10;                                                      //<<<====Guilherme altere aqui================
            bool primeiraVez = true;
            int quantidadeDeClassesParaProcessar = 0;

            do
            {
                SimpleClass simplesClasse = null;
                simplesClasse = Semaforo.removeItem();

                
                criarTextoJSON(simplesClasse, localParaSalvarArquivos, quantidadeDeClassesParaProcessar);
                criarTextoNomeVariavel(simplesClasse, localParaSalvarArquivos, quantidadeDeClassesParaProcessar);
                printarJSON_No_Console(simplesClasse);

                quantidadeDeClassesParaProcessar--;

                if (primeiraVez == true && Semaforo.Count() == 0)
                {
                    test_criarEAdicionarListaSimpleClass(quantidadeDeClassesParaCriar);
                    primeiraVez = false;
                    quantidadeDeClassesParaProcessar = Semaforo.Count();
                } 

            } while(Semaforo.Count() > 0);

            await Task.Delay(1);
        }

        static async Task criarTextoJSON(SimpleClass simple, string ondeSalvar, int quantidadeDeArquivos = 0)
        {
            do
            {
                if (simple != null)
                {
                    string temp_json = Newtonsoft.Json.JsonConvert.SerializeObject(simple),
                           nomeDoArquivo = "json.txt";
                    if (quantidadeDeArquivos > 0)
                    {
                        nomeDoArquivo = "json" + quantidadeDeArquivos + ".txt";
                        quantidadeDeArquivos--;
                    }

                    string json = "";
                    foreach (var caracter in temp_json)
                    {
                        if (caracter == ',') json += caracter + "\n";
                        else json += caracter;
                    }

                    try
                    {
                        File.WriteAllText(ondeSalvar + nomeDoArquivo, json);
                    }
                    catch (Exception) { }

                }

            } while (quantidadeDeArquivos > 0);

            await Task.Delay(1);           
        }

        static async Task criarTextoNomeVariavel(SimpleClass simple, string ondeSalvar, int quantidadeDeArquivos = 0)
        {

            do
            {
                if (simple != null)
                {
                    string texto = "",
                           //TODO: Qualidade: Perguntar ao usuario aonde quer salvar. Usar função que mostra o caminho para salvar.
                           nomeDoArquivo = "NomeVariavel_VariavelNome.txt";
                    if (quantidadeDeArquivos > 0)
                    {
                        nomeDoArquivo = "NomeVariavel_VariavelNome"+ quantidadeDeArquivos + ".txt";
                        quantidadeDeArquivos--;
                    }

                    texto = "InteiroQualquer:" + simple.InteiroQualquer + "\n" +
                            "FloatQualquer:" + simple.FloatQualquer + "\n" +
                            "DoubleQualquer:" + simple.DoubleQualquer + "\n" +
                            "CharQualquer:" + simple.CharQualquer + "\n" +
                            "StringQualquer:" + simple.StringQualquer + "\n";

                    try
                    {
                        File.WriteAllText(ondeSalvar + nomeDoArquivo, texto);
                    }
                    catch (Exception) { }
                }
            } while (quantidadeDeArquivos > 0);

            await Task.Delay(1);
        }

        static async Task printarJSON_No_Console(SimpleClass simple)
        {
            if (simple != null)
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(simple);

                foreach (var caracter in json)
                {
                    if (caracter == ',') Console.Write("\n");
                    else Console.Write(caracter);
                }

                Console.Write("\n\n\n");
            }

            await Task.Delay(1);
        }

        #endregion metodos async

        #region metodos_de_teste
        //TODO: Criar metodo 'test', o mesmo ira preencher, com valores aleatórios, uma instancia da classe 'SimpleClass' que será recebida por referencia.
        public static void test_PreencherSimpleClass(ref SimpleClass simple)
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
            simple.FloatQualquer =  (float) ( rand.Next(int.MinValue, int.MaxValue) + rand.NextDouble() );
            //Double Aleatorio
            simple.DoubleQualquer = (double) rand.Next(int.MinValue, int.MaxValue) + rand.NextDouble();
            //Char Aleatorio
            simple.CharQualquer = (char) rand.Next(charaterMinUnicode, charaterMaxUnicode);



    }

        public static void test_escreverClasseNoConsole(SimpleClass simple) 
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

        public static void test_criarEAdicionarListaSimpleClass(int tamanhoDaLista)
        {

            if (tamanhoDaLista > 0)
            {
                for (int i = 0; i < tamanhoDaLista; i++)
                {
                    SimpleClass simple = new SimpleClass();
                    test_PreencherSimpleClass(ref simple);
                    Semaforo.addItem(simple);
                }

            }
            else throw new Exception();

        }

        #endregion metodos_de_teste

    }
}
