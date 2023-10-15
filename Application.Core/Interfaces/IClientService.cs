using Application.Core.Dtos;
using Application.Core.Models;

namespace Application.Core.Interfaces
{
    public interface IClientService
    {
        List<ClientDto> DisplayAllClients();
        bool CaptureClientsDetails(Client client);
        List<int> GetNumberOfClientsPerdate();
        List<string> GetDatePerClient();
        List<double> GetNumberOfUsersPerLocation();
        List<string> GetLocationPerNumberOfUser();
        bool DoesClientExist(string client);
    }
}
