using API.Controllers.Base;
using Application.Contracts;
using Application.Features.Commands;
using Application.Features.Queries;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class CatFactController : BaseApiController
{
    /// <summary>
    /// Get cat fact and save it to file
    /// </summary>
    /// <returns>Cat fact obtained from HTTP Request</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<CatFact>> GetCatFactWithSave()
    {
        var result = await Mediator.Send(new GetAndSaveCatFactCommand());

        if (result.Length == 0)
            return StatusCode(500);

        return result;
    }

    /// <summary>
    /// Get all saved cat facts
    /// </summary>
    /// <returns>Cat facts from file</returns>
    [HttpGet("saved-facts")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<string>> GetSavedFacts()
    {
        var result = await Mediator.Send(new GetSavedCatFactsQuery());

        if (string.IsNullOrEmpty(result))
            return NotFound("File not found or empty...");

        return result;
    }
}