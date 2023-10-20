using Domain.Models;

namespace Domain.Interfaces
{
    public interface IIPInfoProvider
    {
        Task<IPDetails> GetDetails(string ip);
    }
}
