using API.Controllers.Base;
using Application.Contracts;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class CatFactController : BaseApiController
{
    private readonly ICatFactService _catFactService;

    public CatFactController(ICatFactService catFactService)
    {
        _catFactService = catFactService;
    }
    
    [HttpGet]
    public async Task<ActionResult<CatFact>> GetCatFact()
    {
        var result = await _catFactService.GetFact();

        return result;
    }

    [HttpGet("file-content")]
    public async Task<ActionResult<string>> GetSavedFacts()
    {
        var result = await _catFactService.GetSavedToFileFacts();

        if (string.IsNullOrEmpty(result)) 
            return NotFound("File empty or not found");

        return result;
    }
}