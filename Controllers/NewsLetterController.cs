
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Supabase.API.Contracts;
using Supabase.API.Models;

namespace Supabase.API.Controllers;

[ApiController]
[Route("[controller]/api")]
public class NewsLetterController : ControllerBase
{
    private readonly Client _client;

    public NewsLetterController(Supabase.Client client)
    {
        _client = client;
    }

    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<NewsLetter>>> GetNewsLetter()
    {
        var newsLetterResponse = new List<NewsLetterResponse>();

        var response = await _client.From<NewsLetter>().Get();

        var result = response.Models;

        

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<NewsLetterResponse>> GetNewsLetter([FromRoute] int id)
    {
        var response = await _client.From<NewsLetter>().Where(NewsLetter => NewsLetter.Id == id).Get();        
        
        var newsLetter = response.Models.FirstOrDefault();

        if(newsLetter is null) return NotFound();
        
        var newsLetterResponse = new NewsLetterResponse
        {
            Id = newsLetter.Id,
            Name = newsLetter.Name,
            Description = newsLetter.Name,
            ReadTime = newsLetter.ReadTime,
            CreatedAt = newsLetter.CreatedAt
        };

        return Ok(newsLetterResponse);
    }

    [HttpPost]
    public async Task<ActionResult<NewsLetterResponse>> CreateNewsLetter([FromBody] CreateNewsLetterRequest request)
    {
        var newsLetter = new NewsLetter
        {
            Name = request.Name,
            Description = request.Description,
            ReadTime = request.ReadTime
        };

        var response = await _client.From<NewsLetter>().Insert(newsLetter);

        var newNewsLetter = response.Models.First();

        return Created("",new { id = newNewsLetter.Id } );
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> RemoveNewsLetter([FromRoute] int id)
    {
        await _client
            .From<NewsLetter>()
            .Where(NewsLetter => NewsLetter.Id == id)
            .Delete();

        return NoContent();
    }
}