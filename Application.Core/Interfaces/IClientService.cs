using Application.Core.Dtos;
using Application.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Interfaces
{
    public interface IClientService
    {
        List<ClientDto> DisplayAllClients();
        bool CaptureClientsDetails(Client client);
        T DisplayClients<T>();
        List<int> GetNumberOfClientsPerdate();
        List<string> GetDatePerClient();
        List<double> GetNumberOfUsersPerLocation();
        List<string> GetLocationPerNumberOfUser();
    }
}
