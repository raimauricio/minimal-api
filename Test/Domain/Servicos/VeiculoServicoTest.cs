using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.Servicos;
using MinimalApi.Infraestrutura.Db;

namespace Test.Domain.Servicos
{
    [TestClass]
    public class VeiculoServicoTest
    {
        // Arrange
        private static DbContexto CriarContextoDeTeste()
        {
            var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var path = Path.GetFullPath(Path.Combine(assemblyPath ?? "", "..", "..", ".."));
    
            var builder = new ConfigurationBuilder()
                .SetBasePath(path ?? Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
    
            var configuration = builder.Build();
    
            return new DbContexto(configuration);
        }
        

        private VeiculoServico servico  =  new(CriarContextoDeTeste());


        [TestMethod]
        public void TestIncluir(){
            // Arrange
            Veiculo veiculo = new()
            {              
                Id = 1,
                Ano = 2024,
                Marca = "Wolkswagen",
                Nome = "Gol",
            };
            // Act
            servico.Incluir(veiculo);

            // Assert
            Assert.AreEqual(1, servico.Todos(1).Count);
            servico.Apagar(veiculo);
        }

        
        [TestMethod]
        public void TestApagar(){
            // Arrange
            Veiculo veiculo = new()
            {              
                Id = 2,
                Ano = 2024,
                Marca = "FIAT",
                Nome = "uno",
            };
            // Act
            servico.Incluir(veiculo);
            servico.Apagar(veiculo);

            // Assert
            Assert.AreEqual(1, servico.Todos(1).Count);
            
        }
        
        [TestMethod]
        public void TestAtualizar(){
            // Arrange
            Veiculo veiculo = new()
            {                
                Ano = 2023,
                Id = 1,
                Marca = "Fiat",
                Nome = "Mobi"
            };
            // Act
            servico.Atualizar(veiculo);
            
            // Assert
            Assert.AreEqual(2023, veiculo.Ano);
            Assert.AreEqual("Fiat", veiculo.Marca);
            Assert.AreEqual("Mobi", veiculo.Nome);
            
            
        }
        
        [TestMethod]
        public void TestBuscaPorId(){
            // Arrange
            Veiculo veiculo = new()
            {                
                Id = 1,
                Ano = 2024,
                Marca = "Wolkswagen",
                Nome = "Gol",
            };
            // Act
            servico.Incluir(veiculo);
            Veiculo? veiculoDoBanco = servico.BuscaPorId(veiculo.Id);

            // Assert
            Assert.AreEqual(2, veiculoDoBanco?.Id);
        }
    }
}