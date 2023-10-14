using Application.Core.Dtos;
using Application.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AnalyticsApplication.Controllers
{
    public class DisplayController : Controller
    {
        public readonly IClientService _clientService;
        public DisplayController(IClientService clientService)
        {
                _clientService = clientService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DisplayAnalytics()
        {
            return View();
        }

        //[HttpPost]
        //public List<object> GetClientData()
        //{
        //    List<object> data = new List<object>();

        //    //Number of udsers per location
        //    List<string> locationLabel = _clientService.DisplayAllClients().Select(x => x.Location).ToList();
        //    data.Add(locationLabel);
        //    List<int> systemUserNumber = _clientService.DisplayAllClients().Select(x => x.NumberOfSystemUsers).ToList();
        //    data.Add(systemUserNumber);

        //    //Number of Users overall across the clients
        //    List<string> clientLabel = _clientService.DisplayAllClients().Select(x => x.ClientName).ToList();
        //    data.Add(clientLabel);
        //    /*List<int> systemUserNumber = _clientService.DisplayAllClients().Select(x => x.NumberOfSystemUsers).ToList();
        //    data.Add(systemUserNumber);*/

        //    //Number of Clients created per Date (not Time)
        //    List<DateTime> dateLabel = _clientService.DisplayAllClients().Select(x => x.DateRegisterd).ToList();
        //    data.Add(dateLabel);


        //    return data;
        //}


        [HttpPost]
        public List<object> GetClientData()
        {
            List<object> data = new List<object>();

            //List<int> numberOfClientsPerDate = _clientService.GetNumberOfClientsPerdate();
            //data.Add(numberOfClientsPerDate);


            //Number of users per location
            List<double> numberOfUserPerLocation = _clientService.GetNumberOfUsersPerLocation();
            data.Add(numberOfUserPerLocation);
            List<string> locationPerNumberOfUser = _clientService.GetLocationPerNumberOfUser();
            data.Add(locationPerNumberOfUser);

            


            //Number of Users overall across the clients
            List<string> clientLabel = _clientService.DisplayAllClients().Select(x => x.ClientName).ToList();
            data.Add(clientLabel);
            List<int> systemUserNumber = _clientService.DisplayAllClients().Select(x => x.NumberOfSystemUsers).ToList();
            data.Add(systemUserNumber);


            //Number of Clients created per Date (not Time)
            List<int> numberOfClientsPerDate = _clientService.GetNumberOfClientsPerdate();
            data.Add(numberOfClientsPerDate);
            List<string> datePerClient = _clientService.GetDatePerClient();
            data.Add(datePerClient);


            return data;
        }
    }
}
