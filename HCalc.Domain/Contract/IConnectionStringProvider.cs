namespace HCalc.Domain.Contract
{
    public interface IConnectionStringProvider
    {
        /// <summary>
        /// Which database server to connect to
        /// </summary>
        string ConnectionString { get; }
    }
}