using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using data;
using model;
using dto;


[ApiController]
[Route("api/[controller]")]
public class FilmesController : ControllerBase
{
    private readonly AppDbContext _context;

    public FilmesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Filme>>> GetAll()
    {
        return await _context.Filmes.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Filme>> GetById(int id)
    {
        var filme = await _context.Filmes.FindAsync(id);

        if (filme == null)
        {
            return NotFound();
        }

        return filme;
    }

    [HttpPost]
    public async Task<ActionResult<Filme>> AddFilme(CriarFilmeDto filmedto)
    {

        Filme filme = new Filme(filmedto.Titulo, filmedto.DuracaoMinutos, filmedto.Genero);
        _context.Filmes.Add(filme);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = filme.Id }, filme);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFilme(int id)
    {
        var filme = await _context.Filmes.FindAsync(id);

        if (filme == null)
        {
            return NotFound($"Filme de ID:{id} não existe!");
        }

        _context.Filmes.Remove(filme);
        await _context.SaveChangesAsync();

        return Ok($"Filme {id} removido com sucesso!");
    }
}
