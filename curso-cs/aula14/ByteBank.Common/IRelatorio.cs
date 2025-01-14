namespace ByteBank.Common
{
    public interface IRelatorio<T>
    {
        void Processar(List<T> boletos);
    }
}