using Alura.Adopet.Console.Comandos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Console.Util
{
    public class DocumentacaoDoSistema
    {
        public static Dictionary<string, DocComando> ToDictionary(Assembly assemblyComOTipoDocComando)
        {
            return assemblyComOTipoDocComando.GetTypes()
             .Where(t => t.GetCustomAttributes<DocComando>().Any())
             .Select(t => t.GetCustomAttribute<DocComando>()!)
             .ToDictionary(d => d.Instrucao);
        }
    }
}
