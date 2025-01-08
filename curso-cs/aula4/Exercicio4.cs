Dictionary<string, string> usuarios = new Dictionary<string, string>
{
    { "user1", "senha123" },
    { "user2", "abc456" },
};

string nomeUsuario = "user1";
string senha = "senha123";

if (usuarios.ContainsKey(nomeUsuario) && usuarios[nomeUsuario] == senha)
    Console.WriteLine("Login bem-sucedido!");
else
    Console.WriteLine("Nome de usuário ou senha incorretos.");