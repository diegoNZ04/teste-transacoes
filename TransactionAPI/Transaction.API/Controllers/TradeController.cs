using Microsoft.AspNetCore.Mvc;
using Transaction.Domain.Dtos.Requests;
using Transaction.Application.Services.Interfaces;

namespace Transaction.API.Controllers;
#pragma warning disable CS1591
[ApiController]
[Route("api/trades")]
public class TradeController : ControllerBase
{
    private readonly ITradeService _tradeService;
    public TradeController(ITradeService tradeService)
    {
        _tradeService = tradeService;
    }

    /// <summary>
    /// Create a new Trade.
    /// </summary>
    /// <param name="request"></param>
    /// <returns>A newly created Trade</returns>
    /// <remarks>
    /// Sample request:
    /// POST /api/trades/create-trade
    /// {
    ///    "description": "monthly salary",
    ///    "amount": 1500,
    ///    "userId": 1,
    ///    "type": 0
    /// }
    /// 
    /// "type" can be 0 for income and 1 for expense
    /// </remarks>
    /// <response code="201">Returns the newly created Trade</response>
    [HttpPost("create-trade")]
    public async Task<IActionResult> CreateTrade([FromBody] CreateNewTradeRequest request)
    {
        var response = await _tradeService.CreateNewTradeAsync(request.Description, request.Amount, request.UserId, request.Type);
        return CreatedAtAction(nameof(GetTradeById), new { id = response.Id }, response);
    }

    /// <summary>
    /// Get all transactions with the related user ID.
    /// </summary>
    /// <returns> Return all trades</returns>
    /// <response code="200">Returns trades with the related user ID.</response>
    /// <response code="204">If trades no content</response>
    [HttpGet("get-all-trades")]
    public async Task<IActionResult> GetAllTrades()
    {
        var response = await _tradeService.GetAllTradesAsync();

        if (!response.Any())
            return NoContent();

        return Ok(new { response });
    }

    /// <summary>
    /// Get a transaction by ID with the related user ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns> Returns trade by ID</returns>
    /// <response code="200">Returns a transaction by ID with the related user ID</response>
    /// <response code="404">If trade is not found</response>
    [HttpGet("get-trade-by-id")]
    public async Task<IActionResult> GetTradeById(int id)
    {
        var response = await _tradeService.GetTradeByIdAsync(id);

        if (response == null)
            return NotFound($"Trade with ID {id} not found.");

        return Ok(response);
    }
}
#pragma warning restore CS1591