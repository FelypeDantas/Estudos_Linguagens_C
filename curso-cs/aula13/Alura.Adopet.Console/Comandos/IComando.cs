using FluentResults;

namespace Alura.Adopet.Console.Comandos
{
    internal interface IComando
    {
        Task<Result> ExecutarAsync();
    }
}
