using Application.Core.Dtos;
using Application.Core.Helpers;
using Application.Core.Interfaces;
using Application.Core.Models;

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
            string path = DataPath();

            var captureClient = _clientMapper.Map(client);

            var clients = _jsonDataHelper.ReadJsonFile<List<ClientDto>>(path);
            clients.Add(captureClient);
            var response = _jsonDataHelper.WriteToJsonFile(clients, path);
            if (response == true)
                isClientCaptured = true;

            return isClientCaptured;
        }

        public List<ClientDto> DisplayAllClients()
        {
            string path = DataPath();
            var clients = _jsonDataHelper.ReadJsonFile<List<ClientDto>>(path);
            return clients;
        }

        public bool DoesClientExist(string clientName)
        {
            bool clientExist = false;
            var client = DisplayAllClients().Where(cn => cn.ClientName == clientName).FirstOrDefault();

            if (client == null) return false;
            if (client.ClientName == clientName)
                clientExist = true;


            return clientExist;
        }

        private List<(DateTime Date, int NumberOfClientsCreated)> GetNumberOfClientsPerdateTest()
        {
            var clients = DisplayAllClients();

            var numberOfClientsCreatedPerDate = new Dictionary<DateTime, int>();

            foreach (var client in clients)
            {
                if (!numberOfClientsCreatedPerDate.ContainsKey(client.DateRegistered))
                {
                    numberOfClientsCreatedPerDate[client.DateRegistered] = 0;
                }

                numberOfClientsCreatedPerDate[client.DateRegistered]++;
            }

            var numberOfClientsCreatedPerDateList = new List<(DateTime Date, int NumberOfClientsCreated)>();

            foreach (var (date, numberOfClientsCreated) in numberOfClientsCreatedPerDate)
            {
                numberOfClientsCreatedPerDateList.Add((date, numberOfClientsCreated));
            }

            return numberOfClientsCreatedPerDateList;
        }

        public List<int> GetNumberOfClientsPerdate()
        {
            List<(DateTime, int)> numberOfUsersList = GetNumberOfClientsPerdateTest();
            List<int> userSum = new List<int>();

            foreach ((DateTime date, int total) in numberOfUsersList)
            {
                userSum.Add(total);
            }

            return userSum; ;
        }

        public List<string> GetDatePerClient()
        {
            List<(DateTime, int)> numberOfUsersTuple = GetNumberOfClientsPerdateTest();
            List<string> clientsPerUser = new List<string>();

            foreach ((DateTime date, int total) in numberOfUsersTuple)
            {
                clientsPerUser.Add(date.Date.ToShortDateString());
            }

            return clientsPerUser; ;
        }

        private List<(string Location, double TotalNumberOfUsers)> GetNumberOfUsersPerLocation1()
        {

            var clients = DisplayAllClients();

            var totalNumberOfUsersPerLocation = new Dictionary<string, double>();

            foreach (var client in clients)
            {
                if (!totalNumberOfUsersPerLocation.ContainsKey(client.Location))
                {
                    totalNumberOfUsersPerLocation[client.Location] = 0;
                }

                totalNumberOfUsersPerLocation[client.Location] += client.NumberOfSystemUsers;
            }

            var totalNumberOfUsersPerLocationSumList = new List<(string Location, double TotalNumberOfUsers)>();

            foreach (var (location, totalNumberOfUsers) in totalNumberOfUsersPerLocation)
            {
                totalNumberOfUsersPerLocationSumList.Add((location, totalNumberOfUsers));
            }

            return totalNumberOfUsersPerLocationSumList;
        }

        public List<double> GetNumberOfUsersPerLocation()
        {
            List<(string, double)> numberOfUsersList = GetNumberOfUsersPerLocation1();
            List<double> userSum = new List<double>();

            foreach ((string location, double total) in numberOfUsersList)
            {
                userSum.Add(total);
            }

            return userSum; ;
        }

        public List<string> GetLocationPerNumberOfUser()
        {
            List<(string, double)> numberOfUsersList = GetNumberOfUsersPerLocation1();
            List<string> locationPerUser = new List<string>();

            foreach ((string location, double total) in numberOfUsersList)
            {
                locationPerUser.Add(location);
            }

            return locationPerUser; ;
        }

        private string DataPath()
        {
            string dirPath = "C:\\Users\\FumisaniMabasa\\Fumisani\\DeveloperAssessment\\";
            string clientDataFileName = "ClientAnalyticsApplication\\Application.Core\\Data\\ClientData.json";
            string path = Path.Combine(dirPath, clientDataFileName);

            return path;
        }

    }
}
