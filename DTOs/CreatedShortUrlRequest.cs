using System.ComponentModel.DataAnnotations;

namespace ShortCutURLs.DTOs;

public class CreatedShortUrlRequest
{
    [Required]
    [Url]
    public string Url  { get; set; } = string.Empty;
}