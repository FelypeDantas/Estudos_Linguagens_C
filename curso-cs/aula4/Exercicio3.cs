Dictionary<string, string> perguntasERespostas = new Dictionary<string, string>
{
    { "Qual é a capital do Brasil?", "Brasília" },
    { "Quanto é 7 vezes 8?", "56" },
    { "Quem escreveu 'Romeu e Julieta'?", "William Shakespeare" },
};

int pontuacao = 0;

foreach (var pergunta in perguntasERespostas)
{
    Console.WriteLine(pergunta.Key);
    Console.Write("Sua resposta: ");
    string respostaUsuario = Console.ReadLine();

    if (respostaUsuario.ToLower() == pergunta.Value.ToLower())
    {
        Console.WriteLine("Correto!\n");
        pontuacao++;
    }
    else
    {
        Console.WriteLine($"Incorreto. A resposta correta é: {pergunta.Value}\n");
    }
}

Console.WriteLine($"Pontuação final: {pontuacao} de {perguntasERespostas.Count}");