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

        // GET account
        /// <summary>  
        /// Get the account of the client
        /// (a bit of a work-around; we would of course not have this
        /// in an application with multiple clients)
        /// </summary>  
        /// <returns> the client as a ClientAccount object </returns>  
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAccount() {
            ClientAccount client = this.clientRepository.GetOnlyClient();
            return Ok(client);
        }

        // GET account/clientId
        /// <summary>  
        /// Get the account of the client with the given id
        /// <param name="clientId"> the client id</param>  
        /// </summary>  
        /// <returns>
        /// the client as a ClientAccount object, if found
        /// 404 otherwise
        /// </returns>  
        [HttpGet("{clientId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
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
