using System;

public class Logica 
{
    public static void Main()
    {
        double imposto = 0;

        double salarioBruto = double.Parse(Console.ReadLine()!);
        double beneficio = double.Parse(Console.ReadLine()!);
        
        if(salarioBruto >= 0 && salarioBruto <= 1100)
        {
            imposto = 0.05 * salarioBruto;
        } else if(salarioBruto >= 1100.01 && salarioBruto <= 2500)
        {
            imposto = 0.1 * salarioBruto;
        } else if(salarioBruto >= 2500.01)
        {
            imposto = 0.15 * salarioBruto;
        } else 
        {
            Console.WriteLine("O salario nao pode ser negativo!");
        }

        double saida = (salarioBruto - imposto) + beneficio;
        Console.WriteLine(saida.ToString("0.00"));
    }
}