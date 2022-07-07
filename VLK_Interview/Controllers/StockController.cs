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
        /// <summary>  
        /// Get the id of the stock with the given name
        /// </summary>  
        /// <param name="stockName"> the name of the stock</param>  
        /// <returns>
        /// the id of the stock with the given name, if found
        /// 404 if not found
        /// </returns>  
        [HttpGet]
        [Route("{stockName:alpha}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetStockId(string stockName) {
            Guid? stockId = stockRepository.GetId(stockName);
            if (stockId == null)
                return NotFound("Stock not found.");
            else
                return Ok(stockId);
        }


        // GET stock/stockId
        /// <summary>  
        /// Get the price of a stock with the given id
        /// </summary>  
        /// <param name="stockId"> the id of the stock</param>  
        /// <returns>
        /// the price of the stock with the given id, if found
        /// 404 if not found
        /// </returns>  
        [HttpGet("{stockId}")]
        [Route("{stockId:guid}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
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
        /// <summary>  
        /// Buy a given number of stocks with the given id, for the client with the given id
        /// </summary>  
        /// <param name="transaction"> 
        /// Transaction object containing the stock id, the client id and the number of stocks
        /// </param>  
        /// <returns>
        /// the updated of the client with the given id, if purchase is successful
        /// 404 if client or stock not found
        /// </returns>  
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
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
