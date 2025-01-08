Dictionary<string, int> estoque = new Dictionary<string, int>
{
    { "camisetas", 50 },
    { "calças", 30 },
    { "tênis", 20 },
};

string produto = "camisetas";

if (estoque.ContainsKey(produto))
{
    Console.WriteLine($"Quantidade em estoque de {produto}: {estoque[produto]} unidades.");
}
else
{
    Console.WriteLine("Produto não encontrado no estoque.");
}