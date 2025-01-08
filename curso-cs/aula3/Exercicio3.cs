List<int> valores = new ArrayList<>();
int total = 0;

Console.Write("Insira os valores que deseja somar: ");
int valor = Console.ReadLine()!;

valores.Add(valor);

for(int i in valores)
{
    total =+ i;
}

Console.Write("A soma total: " + total);