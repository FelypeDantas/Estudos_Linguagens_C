string lista = [2];

lista[0] = "C#";
lista[1] = "Java";
lista[2] = "JavaScript";

Console.WriteLine(lista[0]);

Console.Write("Me fale uma posicao (valor inteiro): ");
int valor = Console.ReadLine()!;



string verificaEntrada(int valor){
    for(int i = 0; i < 2; i++)
    {
        valor = i;
        if(valor == i)
        {
            return lista[i] + " a posicao foi " + i;
        }
    }
    return null;
}