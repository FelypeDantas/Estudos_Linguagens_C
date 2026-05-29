using System;

namespace LearningCSharp
{
    class Program
    {
        public static void Despedida(params string[] alunos)
        {
            foreach (string aluno in alunos)
            {
                Console.WriteLine($"Tchau {aluno}, até a próxima aula!");
            }
        }

        static void Main(string[] args)
        {
            Despedida("João", "Antônio", "Thiago");
        }
    }
}
