public class CursoInfo
{
    public string Curso { get; set; } = string.Empty;
    public string Aluno { get; set; } = string.Empty;
    public string Instrutor { get; set; } = string.Empty;
}

var cursoInfo = new CursoInfo
{
    Curso = "C#: Criando a sua primeira aplicação",
    Aluno = "Felype Dantas",
    Instrutor = "Gui Lima"
};

Console.WriteLine($"""
    Curso: {cursoInfo.Curso}
    Aluno: {cursoInfo.Aluno}
    Instrutor: {cursoInfo.Instrutor}
    """);
