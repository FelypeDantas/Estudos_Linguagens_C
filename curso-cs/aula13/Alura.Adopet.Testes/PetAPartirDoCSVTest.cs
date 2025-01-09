using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Util;

namespace Alura.Adopet.Testes
{
    public class PetAPartirDoCsvTest
    {
        [Fact]
        public void QuandoStringForValidaDeveRetornatUmPet()
        {
            //Arrange
            string linha = "456b24f4-19e2-4423-845d-4a80e8854a41;Lima Limão;1";
            
            //Act
            Pet pet = linha.ConverteDoTexto();

            //Assert
            Assert.NotNull(pet);
        }

        [Fact]
        public void QuandoStringForNulaDeveLancarArgumentNullException()
        {
            //Arrange
            string? linha = null;

            //Act + Assert
            Assert.Throws<ArgumentNullException>(() => linha.ConverteDoTexto());
        }

        [Fact]
        public void QuandoStringForVaziaDeveLancarArgumentException()
        {
            //Arrange
            string? linha = string.Empty;

            //Act + Assert
            Assert.Throws<ArgumentException>(() => linha.ConverteDoTexto());
        }

        [Fact]
        public void QuandoGuidForInvalidoDeveLancarArgumentException()
        {
            //Arrange
            string? linha = "aksjdha;Nina;2";

            //Act + Assert
            Assert.Throws<ArgumentException>(() => linha.ConverteDoTexto());
        }

        [Fact]
        public void QuandoTipoForInvalidoDeveLancarArgumentException()
        {
            //Arrange
            string? linha = "609c9b0d-aa02-459f-a340-256513fc9bad;Nina;3";

            //Act + Assert
            Assert.Throws<ArgumentException>(() => linha.ConverteDoTexto());
        }
    }
}
