namespace Atech.ConsoleApp
{
    public static class FormaGeometricaExtension
    {
        const int COLUNA_INICIAL = 0;
        const int VERTICE_VALIDO = 1;
        const int INCREMENTO_LINHA = 1;
        const int AREA_VALIDA = 2;     

        public static FormaGeometrica RetornarFormaGeometrica(this int[,] numeros)
        {
            var resultado = new FormaGeometrica();

            for (int indexLinha = 0; indexLinha < numeros.GetLength(0); indexLinha++)
            {
                var forma = numeros
                    .AnalisarLinha(indexLinha, COLUNA_INICIAL);

                resultado
                    .SeValidoIncrementarObjeto(forma);
            }

            resultado.Valido = resultado.Vertice >= AREA_VALIDA;
            return resultado;
        }

        private static void SeValidoIncrementarObjeto(this FormaGeometrica resultado, FormaGeometrica forma)
        {
            if (forma.Valido && resultado.Area <= forma.Area)
            {
                resultado.Area = forma.Area;
                resultado.ColunaInicial = forma.ColunaInicial;
                resultado.Valido = forma.Valido;
                resultado.Vertice = forma.Vertice;
            }                
        }

        public static FormaGeometrica AnalisarLinha(this int[,] numeros, int indexLinha, int colunaInicial)
        {
            var arestaAtual = new FormaGeometrica();

            for (int indexColuna = colunaInicial; indexColuna < numeros.GetLength(1); indexColuna++)
            {
                var vertice = numeros[indexLinha, indexColuna];

                arestaAtual
                    .ValidarVertice(indexColuna, vertice);
            }

            numeros
                .ExecutarRecursividade(indexLinha, arestaAtual);

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
                arestaAtual.ColunaInicial = COLUNA_INICIAL;             

            }
        }

        private static void ExecutarRecursividade(this int[,] numeros, int indexLinha, FormaGeometrica aresta)
        {
            aresta.Valido = aresta.Area > AREA_VALIDA;
            int indexProximaLinha = indexLinha + INCREMENTO_LINHA;
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
