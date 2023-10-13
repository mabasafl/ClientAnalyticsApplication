using Application.Core.Dtos;
using Application.Core.Helpers;
using Application.Core.Interfaces;
using Application.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Services
{
    public class ClientService : IClientService
    {
        private readonly IMapper<Client, ClientDto> _clientMapper;
        private readonly JsonDataHelper _jsonDataHelper;
        public ClientService(IMapper<Client, ClientDto> clientMapper, JsonDataHelper jsonDataHelper)
        {
            _clientMapper = clientMapper;
            _jsonDataHelper = jsonDataHelper;
        }
        public bool CaptureClientsDetails(Client client)
        {
            var isClientCaptured = false;
            string path = @"C:\\Users\\FumisaniMabasa\\Fumisani\\DeveloperAssessment\\ClientAnalyticsApplication\\Application.Core\\Data\\ClientData.json";

            var captureClient = _clientMapper.Map(client);

            var clients = _jsonDataHelper.ReadJsonFile<List<ClientDto>>(path);
            clients.Add(captureClient);
            var response = _jsonDataHelper.WriteToJsonFile(clients, path);
            if(response == true)
                isClientCaptured = true;

            return isClientCaptured;
        }

        public IEnumerable<ClientDto> DisplayAllClients()
        {
            string path = @"C:\\Users\\FumisaniMabasa\\Fumisani\\DeveloperAssessment\\ClientAnalyticsApplication\\Application.Core\\Data\\ClientData.json";
            var clients = _jsonDataHelper.ReadJsonFile<IEnumerable<ClientDto>>(path);
            return clients;
        }
    }
}
