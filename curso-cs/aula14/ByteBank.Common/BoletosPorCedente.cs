using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Common
{
    public class BoletosPorCedente
    {
        [NomeColuna("Nome")]
        public string CedenteNome { get; set; }
        [NomeColuna("CpfCnpj")]
        public string CedenteCpfCnpj { get; set; }
        [NomeColuna("Agencia")]
        public string CedenteAgencia { get; set; }
        [NomeColuna("Conta")]
        public string CedenteConta { get; set; }
        [NomeColuna("Total")]
        public decimal Valor { get; set; }
        [NomeColuna("Qtd")]
        public int Quantidade { get; set; }
    }
}
