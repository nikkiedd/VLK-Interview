using Microsoft.AspNetCore.Mvc;
using VLK_Interview.Models;
using VLK_Interview.Repositories;

namespace VLK_Interview.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StockController : ControllerBase
    {
        private readonly IStockRepository stockRepository;
        private readonly IClientRepository clientRepository;

        public StockController(IStockRepository stockRepository, IClientRepository clientRepository)
        {
            this.stockRepository = stockRepository;
            this.clientRepository = clientRepository;
        }

        // GET stock
        // Return the stockId of the stock with the given name
        [HttpGet]
        [Route("{stockName:alpha}")]
        public IActionResult GetStockId(string stockName) {
            Guid? stockId = stockRepository.GetId(stockName);
            if (stockId == null)
                return NotFound("Stock not found.");
            else
                return Ok(stockId);
        }

       // GET stock/stockId
       // Returns the price of a given number of Apple stocks
       [HttpGet("{stockId}")]
       [Route("{stockId:guid}")]
        public IActionResult GetStockPrice(Guid stockId)
        {
            float? stockPrice = this.stockRepository.GetPrice(stockId);
            if (stockPrice == null)
            {
                return NotFound("Stock not found.");
            }
            else
                return Ok(stockPrice);
        }

        // POST stock
        // Buy a given number of Apple stocks
        [HttpPost]
        public IActionResult BuyStocks([FromBody] Transaction transaction)
        {
            Guid clientId = transaction.ClientId;
            Guid stockId = transaction.StockId;
            int numberOfStocks = transaction.NumberOfStocks;

            float? stockPrice = stockRepository.GetPrice(stockId);
            ClientAccount? clientAccount = clientRepository.GetClient(clientId);
            if (clientAccount == null)
            {
                return NotFound("Client not found.");
            }
            else if (stockPrice == null)
            {
                return NotFound("Stock not found");
            }
            else
            {
                //execute the transaction on the stock exchange
                // decrease the balance of the client's account
                float value = (float)(stockPrice * numberOfStocks);
                float newBalance = clientAccount.Balance - value;
                this.clientRepository.ChangeBalance(clientId, newBalance);
                return Ok(newBalance);
            }

        }

    }
}
