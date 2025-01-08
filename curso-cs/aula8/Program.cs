List<Produto> listaProdutos = new List<Produto>();

Produto produto1 = new Produto();
produto1.Nome = "Maça";
produto1.Quantidade = 100;

Produto produto2 = new Produto();
produto2.Nome = "Banana";
produto2.Quantidade = 100;

listaProdutos.Add(produto1);
listaProdutos.Add(produto2);

listaProdutos.RemoveAt(0);
listaProdutos.Remove(produto2);

foreach (Produto produto in listaProdutos)
{
    Console.WriteLine(produto.Nome);
}


