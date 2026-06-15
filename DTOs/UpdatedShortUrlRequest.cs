using System.ComponentModel.DataAnnotations;

namespace ShortCutURLs.DTOs;

public class UpdatedShortUrlRequest
{
    [Required]
    [Url]
    public string Url { get; set; } = string.Empty;
    //public string ShortCode { get; set; } = string.Empty;
}