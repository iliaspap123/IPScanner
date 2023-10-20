using Domain.Models;

namespace Domain.Interfaces
{
    public interface IIPStackHttpClient
    {
        Task<IPDetails> GetDetailsFromIPStack(string ip);
    }
}
