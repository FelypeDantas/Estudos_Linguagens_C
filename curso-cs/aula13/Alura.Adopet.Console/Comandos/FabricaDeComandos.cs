using Alura.Adopet.Console.Servicos;
using Alura.Adopet.Console.Util;

namespace Alura.Adopet.Console.Comandos
{
    internal static class FabricaDeComandos
    {
        public static IComando? CriarComando(string[] argumentos)
        {
            var comando = argumentos[0];
            switch (comando)
            {
                case "import":
                var httpClientPet = new HttpClientPet(new AdopetAPIClientFactory().CreateClient("adopet"));
                LeitorDeArquivo leitorDeArquivos = new(argumentos[1]);
                    return new Import(httpClientPet, leitorDeArquivos);                    
                case "list":
                    var httpClientPetList = new HttpClientPet(new AdopetAPIClientFactory().CreateClient("adopet"));
                    return new List(httpClientPetList);               
                case "show":
                    LeitorDeArquivo leitorDeArquivosShow = new(argumentos[1]);
                    return new Show(leitorDeArquivosShow);
                case "help":
                    var comandoASerExibido = argumentos.Length==2? argumentos[1] : null;
                    return new Help(comandoASerExibido);
                default: return null;
            }           
        }
    }
}
