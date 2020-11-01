namespace Atech.ConsoleApp
{
    public static class FormaGeometricaExtension
    {
        const int VERTICE_VALIDO = 1;
        const int AREA_VALIDA = 2;

        public static FormaGeometrica Pesquisar(this int[,] numeros)
        {
            var resultado = new FormaGeometrica();

            for (int indexLinha = 0; indexLinha < numeros.GetLength(0); indexLinha++)
            {
                var forma = AnalisarLinha(numeros, indexLinha, 0);
                SeValidoIncrementarObjeto(resultado, forma);
            }

            resultado.Valido = resultado.Vertice >= AREA_VALIDA;
            return resultado;
        }

        private static void SeValidoIncrementarObjeto(FormaGeometrica resultado, FormaGeometrica forma)
        {
            if (forma.Valido && resultado.Area <= forma.Area)
            {
                resultado.Area = forma.Area;
                resultado.ColunaInicial = forma.ColunaInicial;
                resultado.Valido = forma.Valido;
                resultado.Vertice = forma.Vertice;
            }                
        }

        public static FormaGeometrica AnalisarLinha(int[,] numeros, int indexLinha, int colunaInicial)
        {
            var arestaAtual = new FormaGeometrica();

            for (int indexColuna = colunaInicial; indexColuna < numeros.GetLength(1); indexColuna++)
            {
                var vertice = numeros[indexLinha, indexColuna];
                arestaAtual.ValidarVertice(indexColuna, vertice);
            }           

            ExecutarRecursividade(numeros, indexLinha, arestaAtual);

            return arestaAtual;
        }

        private static void ValidarVertice(this FormaGeometrica arestaAtual, int indexColuna, int vertice)
        {
            if (vertice == VERTICE_VALIDO)
            {
                arestaAtual.Area += vertice;

                if (!arestaAtual.Valido)
                    arestaAtual.ColunaInicial = indexColuna;

                arestaAtual.Valido = true;                
            }
            else
            {
                arestaAtual.Area = 0;
                arestaAtual.Valido = false;
                arestaAtual.ColunaInicial = 0;             

            }
        }

        private static void ExecutarRecursividade(int[,] numeros, int indexLinha, FormaGeometrica aresta)
        {
            aresta.Valido = aresta.Area > AREA_VALIDA;
            int indexProximaLinha = indexLinha + 1;
            bool exiteProximaLinha = indexProximaLinha < numeros.GetLength(0);
            if (aresta.Valido && exiteProximaLinha)
            {             
                var proximaAresta = AnalisarLinha(numeros, indexProximaLinha, aresta.ColunaInicial);
                aresta.Area += proximaAresta.Area;
                aresta.Valido = proximaAresta.Area > AREA_VALIDA;

                if (aresta.Valido)
                  aresta.Vertice += VERTICE_VALIDO;
            }
        }
    }
}
