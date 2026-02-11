using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using data;
using model;
using dto;


[ApiController]
[Route("api/[controller]")]
public class SalasController : ControllerBase
{
    private readonly AppDbContext _context;

    public SalasController(AppDbContext context)
    {
        _context = context;
    }
    [HttpGet]
    public async Task<ActionResult<List<Sala>>> GetAll()
    {
        return await _context.Salas.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Sala>> GetById(int id)
    {
        var sala = await _context.Salas.FindAsync(id);

        if (sala == null)
        {
            return NotFound();
        }

        return sala;
    }

    [HttpPost]
    public async Task<ActionResult<Sala>> AddSala(CriarSalaDto saladto)
    {

        Sala sala = new Sala(saladto.Nome, saladto.Capacidade);
        _context.Salas.Add(sala);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = sala.Id }, sala);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSala(int id)
    {
        var sala = await _context.Salas.FindAsync(id);

        if (sala == null)
        {
            return NotFound($"Sala de ID:{id} não existe!");
        }

        _context.Salas.Remove(sala);
        await _context.SaveChangesAsync();

        return Ok($"Sala {id} removida com sucesso!");
    }

}