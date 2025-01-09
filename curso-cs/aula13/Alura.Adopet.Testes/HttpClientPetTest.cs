
using Alura.Adopet.Console.Servicos;
using Moq;
using Moq.Protected;
using System.Net;
using System.Net.Sockets;

namespace Alura.Adopet.Testes
{
    public class HttpClientPetTest
    {
        [Fact]
        public async Task ListaPetsDeveRetornarUmaListaNaoVazia()
        {
            //Arrange
            var handlerMock = new Mock<HttpMessageHandler>();
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(@"
                     [
                        {
                            ""id"": ""ed48920c-5adb-4684-9b8f-ba8a94775a11"",
                            ""nome"": ""Sábio"",
                            ""tipo"": 0,
                            ""proprietario"":null
                        },
                        {
                            ""id"": ""456b24f4-19e2-4423-845d-4a80e8854a41"",
                            ""nome"": ""Lima Limão"",
                            ""tipo"": 0,
                            ""proprietario"": null
                        },
                        {
                            ""id"": ""3aeff89d-7da2-4603-852e-d232fbdc56bd"",
                            ""nome"": ""Caito"",
                            ""tipo"": 0,
                            ""proprietario"": null
                        },
                        {
                            ""id"": ""bcdcb7a4-1279-4a6b-97e9-da6378ae6437"",
                            ""nome"": ""Jujuba"",
                            ""tipo"": 1,
                            ""proprietario"": null
                        },
                        {
                            ""id"": ""609c9b0d-aa02-459f-a340-256513fc9bad"",
                            ""nome"": ""Nina"",
                            ""tipo"": 1,
                            ""proprietario"": null
                        },
                        {
                            ""id"": ""01303089-833f-46ff-9f06-77f9d4f89f1d"",
                            ""nome"": ""Perdido"",
                            ""tipo"": 0,
                            ""proprietario"": null
                        }
                    ]
                "),
            };
            handlerMock
               .Protected()
               .Setup<Task<HttpResponseMessage>>(
                  "SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>())
               .ReturnsAsync(response);

            var httpClient = new Mock<HttpClient>(MockBehavior.Default, handlerMock.Object);
            httpClient.Object.BaseAddress = new Uri("http://localhost:5057");
            var clientePet = new HttpClientPet(httpClient.Object);

            //Act
            var lista = await clientePet.ListPetsAsync();

            //Assert
            Assert.NotNull(lista);
            Assert.NotEmpty(lista);
        }

        [Fact]
        public async Task QuandoAPIForaDeveRetornarUmaExcecao()
        {
            //Arrange
            var handlerMock = new Mock<HttpMessageHandler>();
            handlerMock
               .Protected()
               .Setup<Task<HttpResponseMessage>>(
                  "SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>())
               .ThrowsAsync(new SocketException());

            var httpClient = new Mock<HttpClient>(MockBehavior.Default, handlerMock.Object);
            httpClient.Object.BaseAddress = new Uri("http://localhost:5057");

            var clientePet = new HttpClientPet(httpClient.Object);

            //Act+Assert
            await Assert.ThrowsAnyAsync<Exception>(()=> clientePet.ListPetsAsync());

        }

    }
}