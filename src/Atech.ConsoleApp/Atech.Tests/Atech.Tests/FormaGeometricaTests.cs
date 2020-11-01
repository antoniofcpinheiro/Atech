using Atech.ConsoleApp;
using Xunit;

namespace Atech.Tests
{
    public class FormaGeometricaTests
    {
        const string MENSGEM_ERRO = "C�lculo de �rea inv�lido";
        const int  CALCULO_AREA_VALIDA = 6;

        [Fact]
        public void DeveValidarRetangulo()
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
              .Pesquisar();

            // Assert
            Assert.True(resultado.Area == CALCULO_AREA_VALIDA, MENSGEM_ERRO);
             

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
              .Pesquisar();

            // Assert
            Assert.False(resultado.Valido, MENSGEM_ERRO);

        }


    }
}