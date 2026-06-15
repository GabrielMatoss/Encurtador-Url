namespace ShortCutURLs.Service;

public class ShortUrlService
{
    public string GenerateShortCode()
    {
        return Guid
            .NewGuid()
            .ToString()
            .Substring(0, 6);
    }
}