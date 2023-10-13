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
        IEnumerable<ClientDto> DisplayAllClients();
        bool CaptureClientsDetails(Client client);
    }
}
