using ByteBank.Common;
using System.Reflection;
using System.Reflection.Emit;

MostrarBanner();

while (true)
{
    MostrarMenu();

    if (int.TryParse(Console.ReadLine(), out int escolha))
    {
        ExecutarEscolha(escolha);
    }
    else
    {
        Console.WriteLine("Opção inválida. Tente novamente.");
    }
}

static void MostrarBanner()
{
    Console.WriteLine(@"


    ____        __       ____              __      
   / __ )__  __/ /____  / __ )____ _____  / /__    
  / __  / / / / __/ _ \/ __  / __ `/ __ \/ //_/    
 / /_/ / /_/ / /_/  __/ /_/ / /_/ / / / / ,<       
/_____/\__, /\__/\___/_____/\__,_/_/ /_/_/|_|      
      /____/                                       
                                
        ");
}

static void MostrarMenu()
{
    Console.WriteLine("\nEscolha uma opção:");
    Console.WriteLine();
    Console.WriteLine("1. Ler arquivo de boletos");
    Console.WriteLine("2. Gravar arquivo com boletos agrupados por cedente");
    Console.WriteLine("3. Executar Plugins");
    Console.WriteLine();
    Console.Write("Digite o número da opção desejada: ");
}

static void ExecutarEscolha(int escolha)
{
    switch (escolha)
    {
        case 1:
            LerArquivoBoletos();
            break;

        case 2:
            GravarGrupoBoletos();
            break;

        case 3:
            ExecutarPlugins();
            break;

        default:
            Console.WriteLine("Opção inválida. Tente novamente.");
            break;
    }
}

static void LerArquivoBoletos()
{
    Console.WriteLine("Lendo arquivo de boletos...");

    var leitorDeBoleto = new LeitorDeBoleto();
    List<Boleto> boletos = leitorDeBoleto.LerBoletos("Boletos.csv");

    foreach (var boleto in boletos)
    {
        Console.WriteLine($"Cedente: {boleto.CedenteNome}, Valor: {boleto.Valor:#0.00}, Vencimento: {boleto.DataVencimento}");
    }
}

static void GravarGrupoBoletos()
{
    Console.WriteLine("Gravando arquivo de boletos...");

    var leitorDeBoleto = new LeitorDeBoleto();
    List<Boleto> boletos = leitorDeBoleto.LerBoletos("Boletos.csv");

    //RelatorioDeBoleto gravadorDeCSV = new RelatorioDeBoleto("BoletosPorCedente.csv");
    //gravadorDeCSV.Processar(boletos);

    var nomeParametroConstrutor = "nomeArquivoSaida";
    var parametroConstrutor = "BoletosPorCedente.csv";
    var nomeMetodo = "Processar";
    var parametroMetodo = boletos;

    ProcessarDinamicamente(nomeParametroConstrutor, parametroConstrutor,
        nomeMetodo, parametroMetodo);
}

static void ProcessarDinamicamente(string nomeParametroConstrutor, string parametroConstrutor, string nomeMetodo, List<Boleto> parametroMetodo)
{
    var tipoClasseRelatorio = typeof(RelatorioDeBoleto);
    var construtores = tipoClasseRelatorio.GetConstructors();

    //foreach (var construtor in construtores)
    //{
    //    Console.WriteLine($"Construtor: {construtor.Name}");
    //    Console.WriteLine($"  No. de parâmetros: {construtor.GetParameters().Length}");
    //}

    //O construtor desejado deve ter como requisitos:
    //1. Um único parâmetro
    //2. Esse parâmetro deve se chamar “nomeArquivoSaida”

    var construtor = construtores
        .Single(c => c.GetParameters().Length == 1
        && c.GetParameters().Any(p => p.Name == nomeParametroConstrutor));

    var instanciaClasse = construtor.Invoke(new object[] { parametroConstrutor });

    var metodoProcessar = tipoClasseRelatorio.GetMethod(nomeMetodo);
    metodoProcessar.Invoke(instanciaClasse, new object[] { parametroMetodo });
}

static void ExecutarPlugins()
{
    //Ler boletos a partir do arquivo CSV
    var leitorDeCSV = new LeitorDeBoleto();
    List<Boleto> boletos = leitorDeCSV.LerBoletos("Boletos.csv");

    //Obter classes de plugin 
    List<Type> classesDePlugin = ObterClassesDePlugin<IRelatorio<Boleto>>();

    foreach (var classe in classesDePlugin)
    {
        // Criar uma instância do plugin
        //var plugin = Activator.CreateInstance(classe, new object[] { "BoletosPorCedente.csv" });
        var plugin = Activator.CreateInstance(classe);

        // Chamar o método Processar usando Reflection
        MethodInfo metodoSalvar = classe.GetMethod("Processar");
        metodoSalvar.Invoke(plugin, new object[] { boletos });
    }
}

static List<Type> ObterClassesDePlugin<T>()
{
    var tiposEncontrados = new List<Type>();

    // Pegar o assembly que está em execução
    Assembly assemblyEmExecucao = Assembly.GetExecutingAssembly();

    // Pegar o assembly onde um tipo é declarado
    Assembly assemblyDosPlugins = typeof(IRelatorio<Boleto>).Assembly;

    var assemblies = ObterAssembliesDePlugins();

    foreach (var assembly in assemblies)
    {
        Console.WriteLine($"Assembly encontrado: {assembly.FullName}");
        IEnumerable<Type> tiposImplementandoT = ObterTiposDoAssembly<T>(assembly);

        tiposEncontrados.AddRange(tiposImplementandoT);
    }

    return tiposEncontrados;
}

static IEnumerable<Type> ObterTiposDoAssembly<T>(Assembly assemblyDosPlugins)
{
    //Descobre todos os tipos do assembly
    var tipos = assemblyDosPlugins.GetTypes();

    foreach (var tipo in tipos)
    {
        Console.WriteLine($"Nome: {tipo.Name}");
        Console.WriteLine($"Nome completo: {tipo.FullName}");
        Console.WriteLine($"É classe: {tipo.IsClass}");
        Console.WriteLine($"É interface: {tipo.IsInterface}");
        Console.WriteLine($"É abstrato: {tipo.IsAbstract}");

        Console.WriteLine("Inferfaces implementadas:");
        foreach (var interfaceType in tipo.GetInterfaces())
        {
            Console.WriteLine($" - {interfaceType.Name}");
        }
        Console.WriteLine();
    }

    // Encontrar tipos que implementam a interface T

    var tiposImplementandoT = tipos.Where(t => typeof(T).IsAssignableFrom(t)
        && t.IsClass && !t.IsAbstract);
    return tiposImplementandoT;
}
                      
static List<Assembly> ObterAssembliesDePlugins()
{
    var assemblies = new List<Assembly>();

    const string diretorio = @"C:\Plugins";

    // Obter todos os arquivos .dll na pasta
    string[] arquivosDll = Directory.GetFiles(diretorio, "*.dll");

    foreach (var arquivoDll in arquivosDll)
    {
        // Carregar o assembly a partir do arquivo DLL
        var assembly = Assembly.LoadFrom(arquivoDll);
        assemblies.Add(assembly);
    }

    return assemblies;
}

