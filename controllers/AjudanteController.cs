using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using data;
using model;
using dto;
using System.Text.Json;


[ApiController]
[Route("api/[controller]")]
public class GeminiController : ControllerBase
{
    private readonly GeminiService _geminiService;
    private readonly AppDbContext _context;

    public GeminiController(GeminiService geminiService,AppDbContext context)
    {
        _geminiService = geminiService;
        _context = context;
    }




    [HttpPost]
    public async Task<ActionResult<string>> Generate([FromBody] string prompt)
    {
        var contextoCinema = await _context.Sessoes
        .Select(s => new RespostaSessaoDto(
            s.Id,
            s.DataHoraInicio,
            s.DataHoraFim,
            s.Filme.Titulo,
            s.Sala.Nome
        ))
        .ToListAsync();

        string programacaoJson = JsonSerializer.Serialize(contextoCinema, new JsonSerializerOptions
        {
        WriteIndented = true
        });
        
        string instrucoes = "Você é um ajudante de cinema e quer ajudar o seu cliente, em seguida você recebera a programacao do cinema e logo após isso, o que o cliente deseja: \n";
        string promptFinal = String.Concat(instrucoes, "Programação: \n",programacaoJson, "Mensagem do cliente: \n",prompt);

        var result = await _geminiService.GenerateTextAsync(promptFinal);
        return Ok(result);
    }
}
