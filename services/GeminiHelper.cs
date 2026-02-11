using Google.GenAI;
using Microsoft.Extensions.Configuration;

public class GeminiService
{
    private readonly string _apiKey;

    public GeminiService(IConfiguration configuration)
    {
        _apiKey = configuration["Gemini:ApiKey"] ?? throw new Exception("Chave API não definida!");
    }

    public async Task<string> GenerateTextAsync(string prompt)
    {
        var client = new Client(apiKey: _apiKey);

        var response = await client.Models.GenerateContentAsync(
            model: "gemini-2.5-flash",
            contents: prompt
        );

        return response.Candidates[0].Content.Parts[0].Text;
    }
}
