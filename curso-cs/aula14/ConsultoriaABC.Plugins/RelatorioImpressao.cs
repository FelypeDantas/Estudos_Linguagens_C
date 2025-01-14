using ByteBank.Common;


namespace ConsultoriaABC.Plugins

{

    public class RelatorioImpressao : IRelatorio<Boleto>

    {

        private const string PastaDestino = @"C:\Plugins\Impressao";


        public void Processar(List<Boleto> boletos)

        {

            GerarDocumentos(boletos, PastaDestino);

        }


        private void GerarDocumentos(List<Boleto> boletos, string pastaDestino)

        {

            // Verificar se a pasta de destino existe, se não, criar

            if (!Directory.Exists(pastaDestino))

            {

                Directory.CreateDirectory(pastaDestino);

            }


            // Gerar documento para cada boleto na lista

            foreach (var boleto in boletos)

            {

                // Formatar o nome do arquivo, por exemplo, usando o número do documento

                string nomeArquivo = Path.Combine(pastaDestino, $"{boleto.NumeroDocumento}.txt");


                var documento = GerarDocumento(boleto);


                File.WriteAllText(nomeArquivo, documento);


                Console.WriteLine($"Boleto para impressão gerado: {nomeArquivo}");

            }

        }


        public string GerarDocumento(Boleto boleto)

        {

            string textoBoleto = $@"

------------------------------------------------------------------------------

                          BANCO Bytebank S.A.

                          Agência: {boleto.CedenteAgencia}       Conta: {boleto.CedenteConta}

------------------------------------------------------------------------------

CEDENTE: {boleto.CedenteNome}

CNPJ/CPF: {boleto.CedenteCpfCnpj}

------------------------------------------------------------------------------

SACADO: {boleto.SacadoNome}

CNPJ/CPF: {boleto.SacadoCpfCnpj}

Endereço: {boleto.SacadoEndereco}

------------------------------------------------------------------------------

Nº Documento: {boleto.NumeroDocumento}           Vencimento: {boleto.DataVencimento:dd/MM/yyyy}

Nosso Número: {boleto.NossoNumero}

------------------------------------------------------------------------------

Descrição                          Valor (R$)      Valor Documento (R$)

------------------------------------------------------------------------------

Pagamento de Serviços              {boleto.Valor,-14:N2}          {boleto.Valor,-19:N2}

------------------------------------------------------------------------------

Código de Barras: {boleto.CodigoBarras}

Linha Digitável: {boleto.LinhaDigitavel}

------------------------------------------------------------------------------

";


            return textoBoleto;

        }

    }

}