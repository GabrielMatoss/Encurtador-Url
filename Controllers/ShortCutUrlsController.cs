using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShortCutURLs.Data;
using ShortCutURLs.DTOs;
using ShortCutURLs.Models;

namespace ShortCutURLs.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShortCutUrlsController : ControllerBase
{
    private readonly AppDbContext _context;

    public ShortCutUrlsController(AppDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Cria uma nova URL encurtada.
    /// </summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create(CreatedShortUrlRequest request)
    {
        if (!Uri.IsWellFormedUriString(request.Url, UriKind.Absolute))
        {
            return BadRequest("URL inválida.");
        }

        string shortCode;

        do
        {
            shortCode = Guid
                .NewGuid()
                .ToString("N")
                .Substring(0, 6);

        } while (await _context.ShortUrls
            .AnyAsync(x => x.ShortCode == shortCode));

        var shortUrl = new ShortUrl
        {
            OriginalUrl = request.Url,
            ShortCode = shortCode,
            CreatedAt = DateTime.UtcNow
        };

        _context.ShortUrls.Add(shortUrl);

        await _context.SaveChangesAsync();

        var response = new CreatedShortUrlResponse
        {
            ShortCode = shortUrl.ShortCode,

            ShortUrl = $"{Request.Scheme}://{Request.Host}/r/{shortUrl.ShortCode}"
        };

        return CreatedAtAction(
            nameof(GetByCode),
            new { code = shortUrl.ShortCode },
            response
        );
    }

    /// <summary>
    /// Lista todas as URLs encurtadas.
    /// </summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var urls = await _context.ShortUrls.ToListAsync();

        var response = await _context.ShortUrls .Select(x => new ResponseShortUrl{
            OriginalUrl = x.OriginalUrl,
            ShortCode = x.ShortCode,
            CreatedAt = x.CreatedAt
        }).ToListAsync();

        return Ok(response);
    }

    /// <summary>
    /// Busca uma URL encurtada pelo código.
    /// </summary>
    [HttpGet("{code}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByCode(string code)
    {
        var url = await _context.ShortUrls
            .FirstOrDefaultAsync(e => e.ShortCode == code);

        if (url == null)
        {
            return NotFound(new
            {
                Message = $"Código '{code}' não encontrado."
            });
        }

        var response = new ResponseShortUrl
        {
            OriginalUrl = url.OriginalUrl,
            ShortCode = url.ShortCode,
            CreatedAt = url.CreatedAt
        };

        return Ok(response);
    }

    /// <summary>
    /// Atualiza a URL associada a um código.
    /// </summary>
    [HttpPut("{code}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(
        string code,
        UpdatedShortUrlRequest request)
    {
        if (!Uri.IsWellFormedUriString(request.Url, UriKind.Absolute))
        {
            return BadRequest("URL inválida.");
        }

        var url = await _context.ShortUrls
            .FirstOrDefaultAsync(x => x.ShortCode == code);

        if (url == null)
        {
            return NotFound(new
            {
                Message = $"Código '{code}' não encontrado."
            });
        }

        url.OriginalUrl = request.Url;

        await _context.SaveChangesAsync();

        return Ok(url);
    }

    /// <summary>
    /// Remove uma URL encurtada.
    /// </summary>
    [HttpDelete("{code}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(string code)
    {
        var url = await _context.ShortUrls
            .FirstOrDefaultAsync(e => e.ShortCode == code);

        if (url == null)
        {
            return NotFound(new
            {
                Message = $"Código '{code}' não encontrado."
            });
        }

        _context.ShortUrls.Remove(url);

        await _context.SaveChangesAsync();

        return NoContent();
    }

    /// <summary>
    /// Redireciona para a URL original.
    /// </summary>
    [HttpGet("/r/{code}")]
    [ProducesResponseType(StatusCodes.Status302Found)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> RedirectToUrl(string code)
    {
        var url = await _context.ShortUrls
            .FirstOrDefaultAsync(e => e.ShortCode == code);

        if (url == null)
        {
            return NotFound(new
            {
                Message = $"Código '{code}' não encontrado."
            });
        }

        url.ClickCount++;

        await _context.SaveChangesAsync();

        return Redirect(url.OriginalUrl);
    }
}