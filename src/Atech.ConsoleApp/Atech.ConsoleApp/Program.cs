using System;

namespace Atech.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {            
              int[,] entrada = new int[4, 5]
              {
                  {1,0,1,0,0},
                  {1,0,1,1,1},
                  {1,1,1,1,1},
                  {1,0,0,1,0}
              };

            var resultado = entrada
                .Pesquisar();

            var textoApresentacao = "Nenhum retângulo válido";

            if (resultado.Valido)
                textoApresentacao = string.Concat("Saida :", resultado.Area);

            Console.WriteLine(textoApresentacao);
            Console.ReadKey();
        }
    }
}
