using ByteBank.Common;

using System.Reflection;

using System.Xml;


namespace ConsultoriaXYZ.Plugins

{

    public class RelatorioXML : IRelatorio<Boleto>

    {

        private const string PastaDestino = @"C:\Plugins";


        public RelatorioXML()

        {

        }


        public void Processar(List<Boleto> boletos)

        {

            var boletosPorCedenteList = PegaBoletosAgrupados(boletos);


            GravarArquivo(boletosPorCedenteList);

        }


        private void GravarArquivo(List<BoletosPorCedente> listaObjetos)

        {

            // Caminho do arquivo XML

            string caminhoArquivo = Path.Combine(PastaDestino, $"{typeof(BoletosPorCedente).Name}.xml");


            // Usar Reflection para obter propriedades do tipo genérico

            PropertyInfo[] objetoProperties = typeof(BoletosPorCedente).GetProperties();


            // Escrever os dados no arquivo XML

            XmlWriterSettings settings = new XmlWriterSettings { Indent = true };

            using (XmlWriter xmlWriter = XmlWriter.Create(caminhoArquivo, settings))

            {

                xmlWriter.WriteStartDocument();

                xmlWriter.WriteStartElement("BoletosPorCedentes"); // Root element


                // Escrever dados

                foreach (var objeto in listaObjetos)

                {

                    xmlWriter.WriteStartElement("BoletoPorCedente"); // Element for each BoletosPorCedente object


                    foreach (var property in objetoProperties)

                    {

                        xmlWriter.WriteStartElement(property.Name); // Element for each property


                        // Escrever valor da propriedade como texto

                        xmlWriter.WriteString(property.GetValue(objeto)?.ToString() ?? "");


                        xmlWriter.WriteEndElement(); // End property element

                    }


                    xmlWriter.WriteEndElement(); // End BoletosPorCedente element

                }


                xmlWriter.WriteEndElement(); // End root element

                xmlWriter.WriteEndDocument();

            }


            Console.WriteLine($"Arquivo '{caminhoArquivo}' criado com sucesso!");

        }


        private List<BoletosPorCedente> PegaBoletosAgrupados(List<Boleto> boletos)

        {

            // Agrupar boletos por cedente

            var boletosAgrupados = boletos.GroupBy(b => new

            {

                b.CedenteNome,

                b.CedenteCpfCnpj,

                b.CedenteAgencia,

                b.CedenteConta

            });


            // Lista para armazenar instâncias de BoletosPorCedente

            List<BoletosPorCedente> boletosPorCedenteList = new List<BoletosPorCedente>();


            // Iterar sobre os grupos de boletos por cedente

            foreach (var grupo in boletosAgrupados)

            {

                // Criar instância de BoletosPorCedente

                BoletosPorCedente boletosPorCedente = new BoletosPorCedente

                {

                    CedenteNome = grupo.Key.CedenteNome,

                    CedenteCpfCnpj = grupo.Key.CedenteCpfCnpj,

                    CedenteAgencia = grupo.Key.CedenteAgencia,

                    CedenteConta = grupo.Key.CedenteConta,

                    Valor = grupo.Sum(b => b.Valor),

                    Quantidade = grupo.Count()

                };


                // Adicionar à lista

                boletosPorCedenteList.Add(boletosPorCedente);

            }


            return boletosPorCedenteList;

        }


    }

}

