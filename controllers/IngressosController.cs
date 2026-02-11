using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using data;
using model;
using dto;

[ApiController]
[Route("api/[controller]")]
public class IngressosController : ControllerBase
{
    private readonly AppDbContext _context;

    public IngressosController(AppDbContext context)
    {
        _context = context;
    }
    [HttpGet]
    public async Task<ActionResult<List<Ingresso>>> GetAll()
    {
        return await _context.Ingressos.ToListAsync();
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Ingresso>> GetById(int id)
    {
        var ingresso = await _context.Ingressos.FindAsync(id);

        if (ingresso == null)
        {
            return NotFound();
        }

        return ingresso;
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteIngresso(int id)
    {
        var ingresso = await _context.Ingressos.FindAsync(id);

        if (ingresso == null)
        {
            return NotFound($"ingresso de ID:{id} não existe!");
        }

        _context.Ingressos.Remove(ingresso);
        await _context.SaveChangesAsync();

        return Ok($"Ingresso {id} removido com sucesso!");
    }
    [HttpPost]
    public async Task<ActionResult<CriarIngressoDto>> AddIngresso(CriarIngressoDto ingressodto)
    {

        var sessao = await _context.Sessoes.Include(s => s.Sala).FirstOrDefaultAsync(s => s.Id == ingressodto.SessaoId);

        if(sessao == null)
        {
            return NotFound("Sessao não encotrada!");
        }

        int contIngressos = await _context.Ingressos.CountAsync(i => i.SessaoId == ingressodto.SessaoId);

        if (contIngressos >= sessao.Sala.CapacidadeTotal)
        {
            return BadRequest("Capacidade máxima já foi atingida!");
        }

        Ingresso ingresso = new Ingresso(ingressodto.SessaoId, ingressodto.Preco);
        _context.Ingressos.Add(ingresso);
        await _context.SaveChangesAsync();

        RespostaIngressoDto resposta = new RespostaIngressoDto(ingresso.Id, ingressodto.SessaoId, ingressodto.Preco);

        return CreatedAtAction(nameof(GetById), new { id = ingresso.Id }, resposta);
    }
    
}