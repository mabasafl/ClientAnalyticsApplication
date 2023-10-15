using Application.Core.Dtos;
using Application.Core.Interfaces;
using Application.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace CapturingApplication.Controllers
{
    public class ClientController : Controller
    {
        public readonly IClientService _clientService;
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public IActionResult Capture()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Capture(Client client)
        {
            try
            {
                var clienAlreadyExist = _clientService.DoesClientExist(client.ClientName);
                if (clienAlreadyExist)
                {
                    ModelState.AddModelError("ClientName", $"A record of a client with the same name:{client.ClientName} already exist. Please add a different client.");
                }

                if (ModelState.IsValid)
                {
                    var response = _clientService.CaptureClientsDetails(client);
                    TempData["AlertMessage"] = $"Record of client: {client.ClientName} has successfully been captured.";
                    return RedirectToAction("Capture");
                }
                else
                {
                    return View();
                }

            }
            catch (Exception ex)
            {
                return RedirectToAction("Capture");
            }

        }
    }
}
