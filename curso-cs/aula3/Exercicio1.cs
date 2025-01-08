Console.Write("Insira o primeiro valor: ");
double a = Console.ReadLine()!;

Console.Write("Insira o segundo valor: ");
double b = Console.ReadLine()!;

void multiplicar(double a, double b)
{
    double resposta = a * b;
    Console.WriteLine($"Ao Multiplicar {resposta}");
}

void somar(double a, double b)
{
    double resposta = a + b;
    Console.WriteLine($"Ao Somar {resposta}");
}

void dividir(double a, double b)
{
    double resposta = a / b;
    Console.WriteLine($"Ao Dividir {resposta}");
}

void subtrair(double a, double b)
{
    double resposta = a - b;
    Console.WriteLine($"Ao Subtrair {resposta}");
}

somar(a, b);
subtrair(a, b);
dividir(a, b);
multiplicar(a, b);
