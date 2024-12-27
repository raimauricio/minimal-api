using MinimalApi.Dominio.Entidades;
namespace Test.Domain.Entidades
{
    [TestClass]
    public class VeiculosTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange

            Veiculo veiculo = new()
            {
                // Act
                Ano = 2024,
                Id = 1,
                Marca = "Wolkswagen",
                Nome = "Gol"
            };

            // Assert
            Assert.AreEqual(1, veiculo.Id);
            Assert.AreEqual("Wolkswagen", veiculo.Marca);
            Assert.AreEqual("Gol", veiculo.Nome);
            Assert.AreEqual(2001, veiculo.Ano);
        }
    }
}
