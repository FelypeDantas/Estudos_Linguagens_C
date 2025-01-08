using bytebank_ATENDIMENTO.bytebank.Atendimento;
using bytebank_GeradorChavePix;

Console.WriteLine("Boas Vindas ao ByteBank, Atendimento.");
new ByteBankAtendimento().AtendimentoCliente();

//Console.WriteLine(GeradorPix.GetChavePix());

//var listaDeChaves = GeradorPix.GetChavesPix(10);

//foreach (var chave in listaDeChaves)
//{
//    Console.WriteLine(chave);
//}
