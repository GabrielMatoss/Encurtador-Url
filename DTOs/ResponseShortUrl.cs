namespace ShortCutURLs.DTOs;

public class ResponseShortUrl
{
    public string OriginalUrl { get; set; } = string.Empty;
    public string ShortCode { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}