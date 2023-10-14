using Application.Core.Dtos;
using Application.Core.Helpers;
using Application.Core.Interfaces;
using Application.Core.Models;
using Newtonsoft.Json;
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

        public List<ClientDto> DisplayAllClients()
        {
            string path = @"C:\\Users\\FumisaniMabasa\\Fumisani\\DeveloperAssessment\\ClientAnalyticsApplication\\Application.Core\\Data\\ClientData.json";
            var clients = _jsonDataHelper.ReadJsonFile<List<ClientDto>>(path);
            return clients;
        }

        public T DisplayClients<T>()
        {
            string path = @"C:\\Users\\FumisaniMabasa\\Fumisani\\DeveloperAssessment\\ClientAnalyticsApplication\\Application.Core\\Data\\ClientData.json";
            var clients = _jsonDataHelper.ReadJsonFile<T>(path);
            return clients;
        }
        /*public List<int> GetNumberOfClientsPerdate()
        {
            var clients = DisplayAllClients();
            var totalOfEachDate = new List<int>();

            var dates = new HashSet<DateTime>();
            foreach (var client in clients)
            {
                dates.Add(client.DateRegisterd.Date);
            }

            foreach (var date in dates)
            {
                int numberOfClientsResgisteredOnDate = 0;
                foreach (var client in clients)
                {
                    if (client.DateRegisterd.Date == date.Date)
                    {
                        numberOfClientsResgisteredOnDate++;
                    }
                }

                totalOfEachDate.Add(numberOfClientsResgisteredOnDate);
            }

            //to remove
            GetNumberOfClientsPerdateTest();

            return totalOfEachDate;
        }*/










        public List<(DateTime Date, int NumberOfClientsCreated)> GetNumberOfClientsPerdateTest()
        {
            var clients = DisplayAllClients();

            var numberOfClientsCreatedPerDate = new Dictionary<DateTime, int>();

            foreach (var client in clients)
            {
                if (!numberOfClientsCreatedPerDate.ContainsKey(client.DateRegisterd))
                {
                    numberOfClientsCreatedPerDate[client.DateRegisterd] = 0;
                }

                numberOfClientsCreatedPerDate[client.DateRegisterd]++;
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
            List<(DateTime, int)> numberOfUsersTuple = GetNumberOfClientsPerdateTest();
            List<int> userSum = new List<int>();

            foreach ((DateTime date, int total) in numberOfUsersTuple)
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

        /*public List<(string Location, DateTime TotalNumberOfUsers)> GetNumberOfClientsPerdateTest()
        {

            var clients = DisplayAllClients();

            var totalNumberOfUsersPerLocation = new Dictionary<string, DateTime>();

            foreach (var client in clients)
            {
                if (!totalNumberOfUsersPerLocation.ContainsKey(client.Location))
                {
                    totalNumberOfUsersPerLocation[client.Location] = 0;
                }

                totalNumberOfUsersPerLocation[client.Location] += client.NumberOfSystemUsers;
            }

            var totalNumberOfUsersPerLocationSumList = new List<(string Location, DateTime TotalNumberOfUsers)>();

            foreach (var (location, totalNumberOfUsers) in totalNumberOfUsersPerLocation)
            {
                totalNumberOfUsersPerLocationSumList.Add((location, totalNumberOfUsers));
            }

            return totalNumberOfUsersPerLocationSumList;
        }*/






























        public List<(string Location, double TotalNumberOfUsers)> GetNumberOfUsersPerLocation1()
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
            List<(string, double)> numberOfUsersTuple = GetNumberOfUsersPerLocation1();
            List<double> userSum = new List<double>();

            foreach ((string location,double total) in numberOfUsersTuple)
            {
                userSum.Add(total);
            }

            return userSum; ;
        }

        public List<string> GetLocationPerNumberOfUser()
        {
            List<(string, double)> numberOfUsersTuple = GetNumberOfUsersPerLocation1();
            List<string> locationPerUser = new List<string>();

            foreach ((string location, double total) in numberOfUsersTuple)
            {
                locationPerUser.Add(location);
            }

            return locationPerUser; ;
        }


    }
}
