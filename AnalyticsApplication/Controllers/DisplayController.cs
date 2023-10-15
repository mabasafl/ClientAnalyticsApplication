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

        public IActionResult DisplayAnalytics()
        {
            return View();
        }

        [HttpPost]
        public List<object> GetClientData()
        {
            List<object> data = new List<object>();

            //Number of users per location
            List<double> numberOfUserPerLocationLabel = _clientService.GetNumberOfUsersPerLocation();
            data.Add(numberOfUserPerLocationLabel);
            List<string> locationPerNumberOfUserLabel = _clientService.GetLocationPerNumberOfUser();
            data.Add(locationPerNumberOfUserLabel);

            //Number of Users overall across the clients
            List<string> clientLabel = _clientService.DisplayAllClients().Select(x => x.ClientName).ToList();
            data.Add(clientLabel);
            List<int> systemUserNumberLabel = _clientService.DisplayAllClients().Select(x => x.NumberOfSystemUsers).ToList();
            data.Add(systemUserNumberLabel);

            //Number of Clients created per Date (not Time)
            List<int> numberOfClientsPerDateLabel = _clientService.GetNumberOfClientsPerdate();
            data.Add(numberOfClientsPerDateLabel);
            List<string> datePerClientLabel = _clientService.GetDatePerClient();
            data.Add(datePerClientLabel);

            return data;
        }
    }
}
