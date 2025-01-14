namespace ByteBank.Common
{
    public class Boleto
    {
        // Informações do Cedente (Beneficiário)
        public string CedenteNome { get; set; }
        public string CedenteCpfCnpj { get; set; }
        public string CedenteAgencia { get; set; }
        public string CedenteConta { get; set; }

        // Informações do Sacado (Pagador)
        public string SacadoNome { get; set; }
        public string SacadoCpfCnpj { get; set; }
        public string SacadoEndereco { get; set; }

        // Informações do Boleto
        public decimal Valor { get; set; }
        public DateTime DataVencimento { get; set; }
        public string NumeroDocumento { get; set; }
        public string NossoNumero { get; set; }

        // Outras Informações
        public string CodigoBarras { get; set; }
        public string LinhaDigitavel { get; set; }
    }

}
