using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VLK_Interview.Models;
using VLK_Interview.Repositories;

namespace VLK_Interview.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ClientAccountController : ControllerBase
    {

        private readonly IClientRepository clientRepository;

        public ClientAccountController(IClientRepository clientRepository) {
            this.clientRepository = clientRepository;
        }

        [HttpGet]
        public IActionResult GetAccount() {
            ClientAccount client = this.clientRepository.GetOnlyClient();
            return Ok(client);
        }

        [HttpGet("{clientId}")]
        public IActionResult GetClientAccount(Guid clientId) {
            // TODO: Absolutely change this
            ClientAccount? client = clientRepository.GetClient(clientId);
            if (client == null)
            {
                return NotFound("Client not found.");
            }
            else
                return Ok(client);
        }

    }
}
