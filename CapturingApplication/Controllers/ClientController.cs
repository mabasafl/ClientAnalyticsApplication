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
        public IActionResult Index()
        {
            return View();
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
                if(ModelState.IsValid) 
                {
                    var response = _clientService.CaptureClientsDetails(client);
                    return View();
                }
                else
                {
                    return RedirectToAction("Capture");
                }
                
                //return RedirectToAction("Capture");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error");
            }
            
        }
    }
}
