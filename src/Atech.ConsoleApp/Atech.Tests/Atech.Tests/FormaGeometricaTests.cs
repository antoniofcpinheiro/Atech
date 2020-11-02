using Atech.ConsoleApp;
using Xunit;

namespace Atech.Tests
{
    public class FormaGeometricaTests
    {
        const string MENSAGEM_ERRO = "Cálculo de área inválido";
        const int  CALCULO_AREA_VALIDA = 6;

        [Fact]
        public void DeveValidarRetangulo4x5()
        {
            // Arrange
            int[,] entrada = new int[4, 5]
             {
                  {1,0,1,0,0},
                  {1,0,1,1,1},
                  {1,1,1,1,1},
                  {1,0,0,1,0}
             };

            // Act
            var resultado = entrada
              .RetornarFormaGeometrica();

            // Assert
            Assert.True(resultado.Area == CALCULO_AREA_VALIDA, MENSAGEM_ERRO);
             

        }


        [Fact]
        public void DeveValidarRetangulo8x5()
        {
            // Arrange
            int[,] entrada = new int[8, 5]
             {
                  {1,0,1,0,0},
                  {1,0,0,1,1},
                  {1,0,0,1,1},
                  {1,0,0,1,0},
                  {1,0,1,0,0},
                  {1,0,1,1,1},
                  {1,1,1,1,1},
                  {1,0,0,1,0}
             };

            // Act
            var resultado = entrada
              .RetornarFormaGeometrica();

            // Assert
            Assert.True(resultado.Area == CALCULO_AREA_VALIDA, MENSAGEM_ERRO);


        }

        [Fact]
        public void NaoDeveValidarRetanguloInvalido()
        {

            // Arrange
            int[,] entrada = new int[2, 5]
             {
                  {1,0,1,0,0},
                  {1,0,1,1,1} 
             };

            // Act
            var resultado = entrada
              .RetornarFormaGeometrica();

            // Assert
            Assert.False(resultado.Valido, MENSAGEM_ERRO);

        }


    }
}
