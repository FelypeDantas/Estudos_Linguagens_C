Aula 1 - Preenchendo objetos dinamicamente

	Projeto: Ler arquivo CSV boletos, instanciar lista de objetos Boleto e preencher as propriedades

		System.Reflection
		System.Type
		Activator.CreateInstance
		PropertyInfo property = type.GetProperty(header[i]);
		property.SetValue

Aula 2 - lendo objetos dinamicamente

	Projeto: Ler a lista de objetos Boleto (criada na Aula 1), consolidar e gravar relatório de boletos por cedente CSV,
		criando instância diretamente pela classe e chamando o método SalvarBoletosPorCedente diretamente

	Gravar arquivo CSV relatório
		GetProperties
		PropertyInfo property = type.GetProperty
		property.GetValue
		Attribute.GetCustomAttributes
		CustomAttributeData

Aula 3 - Construtores e métodos

	Projeto: refatorar o código da Aula 2, criar instância e 
		invocar o método SalvarBoletosPorCedente dinamicamente, passando parâmetro(s)

	GetConstructors
	GetConstructor
	ConstructorInfo
	ParameterInfo
	GetMethods
	GetMethod
	MethodInfo

	Para saber mais:
		FieldInfo
		EventInfo

Aula 4 - Informações de Assembly

	Projeto: 
		Varrer o assembly em execução
		Encontrar tipos que implementam a interface T

	Assembly
	Assembly.GetEntryAssembly vs Assembly.GetExecutingAssembly
	Assembly.LoadFrom
	assembly.GetTypes()
	IsAssignableFrom
	IsClass
	IsAbstract

Aula 5 - Montando o sistema de plugins

	Projeto: 
		Solução quebrada em ByteBank.Common e ByteBank.Library
		Pasta Plugins
		Colocar a dll na pasta Plugins
		Verificar se o diretório existe
		Obter todos os arquivos .dll na pasta
		Carregar o assembly
		Criar um novo de fornecedor, compilar, colocar a dll na pasta Plugins

	Module
	MetadataLoadContext: Carregar e inspecionar assemblies usando o MetadataLoadContext.
	Para saber mais: System.Reflection.Emit, DynamicMethod (avançado demais para o curso)