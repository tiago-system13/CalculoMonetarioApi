namespace CaulculoMonetarioApi.Negocio.Servicos.Interfaces
{
    public interface ICalculaJurosServico
    {
        decimal CalcularJuros(int tempo, decimal valorInicial);
    }
}
