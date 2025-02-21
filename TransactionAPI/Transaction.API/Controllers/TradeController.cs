using Microsoft.AspNetCore.Mvc;
using Transaction.Domain.Dtos.Requests;
using Transaction.Application.Services.Interfaces;

namespace Transaction.API.Controllers
{
    [ApiController]
    [Route("api/trades")]
    public class TradeController : ControllerBase
    {
        private readonly ITradeService _tradeService;
        public TradeController(ITradeService tradeService)
        {
            _tradeService = tradeService;
        }

        [HttpPost("create-trade")]
        public async Task<IActionResult> CreateTrade([FromBody] CreateNewTradeRequest request)
        {
            var response = await _tradeService.CreateNewTradeAsync(request.Description, request.Amount, request.UserId, request.Type);
            return Ok(response);
        }

        [HttpGet("get-all-trades")]
        public async Task<IActionResult> GetAllTrades()
        {
            var response = await _tradeService.GetAllTradesAsync();
            return Ok(new { response });
        }

        [HttpGet("get-trade-by-id")]
        public async Task<IActionResult> GetTradeById(int id)
        {
            var response = await _tradeService.GetTradeByIdAsync(id);
            return Ok(response);
        }
    }
}