using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using data;
using model;
using dto;


[ApiController]
[Route("api/[controller]")]
public class SessoesController : ControllerBase
{
    private readonly AppDbContext _context;

    public SessoesController(AppDbContext context)
    {
        _context = context;
    }
    [HttpGet]
    public async Task<ActionResult<List<Sessao>>> GetAll()
    {
        return await _context.Sessoes.ToListAsync();
    }
    [HttpGet("detalhe")]
    public async Task<ActionResult<List<RespostaSessaoDto>>> GetAllDetalhe()
    {
         var sessoesDetalhadas = await _context.Sessoes
        .Select(s => new RespostaSessaoDto(
            s.Id,
            s.DataHoraInicio,
            s.DataHoraFim,
            s.Filme.Titulo,
            s.Sala.Nome
        ))
        .ToListAsync();

    return Ok(sessoesDetalhadas);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Sessao>> GetById(int id)
    {
        var sessao = await _context.Sessoes.FindAsync(id);

        if (sessao == null)
        {
            return NotFound($"Sessao de id {id} não encontrada");
        }

        return sessao;
    }
    [HttpGet("detalhe/{id}")]
    public async Task<ActionResult<RespostaSessaoDto>> GetByIdDetalhe(int id)
    {
        var sessao = await _context.Sessoes.FindAsync(id);

        if (sessao == null)
        {
            return NotFound($"Sessao de id {id} não encontrada");
        }

        var filme = await _context.Filmes.FindAsync(sessao.FilmeId);
        var sala = await _context.Salas.FindAsync(sessao.SalaId);

        if (filme == null || sala == null) {
            return NotFound("Sala ou filme não encontrado!");
        }


        RespostaSessaoDto detalhe = new RespostaSessaoDto(id, sessao.DataHoraInicio, sessao.DataHoraFim, filme.Titulo, sala.Nome); 
        

        return detalhe;
    }
    [HttpPost]
    public async Task<ActionResult<Sessao>> AddSessao(CriarSessaoDto sessaodto)
    {

        var filme = await _context.Filmes.FindAsync(sessaodto.FilmeId);
        if (filme == null)
        {
            return NotFound($"Filme com id {sessaodto.FilmeId} não existe!");
        }

        var sala = await _context.Salas.FindAsync(sessaodto.SalaId);
        if(sala == null)
        {
            return NotFound($"Sala com id {sessaodto.SalaId} não existe!");
        }

        var conflitoAgendamento = await _context.Sessoes.AnyAsync
        (
            s =>
            s.SalaId == sessaodto.SalaId && 
            sessaodto.DataHoraInicio < s.DataHoraFim &&
            sessaodto.DataHoraFim > s.DataHoraInicio

        );

        if (conflitoAgendamento){
            return BadRequest("Já existe um filme passando nesse horário nessa sala!");
        }

        Sessao sessao = new Sessao {FilmeId = sessaodto.FilmeId, SalaId = sessaodto.SalaId, DataHoraInicio = sessaodto.DataHoraInicio, DataHoraFim = sessaodto.DataHoraFim};

        _context.Sessoes.Add(sessao);
        await _context.SaveChangesAsync();

        var response = new RespostaSessaoDto
        {
            Id = sessao.Id,
            DataHoraInicio = sessao.DataHoraInicio,
            DataHoraFim = sessao.DataHoraFim,
            TituloFilme = filme.Titulo,
            NomeSala = sala.Nome!
        };  

        return CreatedAtAction(nameof(GetById), new { id = sessao.Id }, response);

    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSessao(int id)
    {
        var sessao = await _context.Sessoes.FindAsync(id);

        if (sessao == null)
        {
            return NotFound($"Sessao de ID:{id} não existe!");
        }

        _context.Sessoes.Remove(sessao);
        await _context.SaveChangesAsync();

        return Ok($"Sessao {id} removida com sucesso!");
    }
    [HttpGet("Cartaz")]
    public async Task<ActionResult<Sessao>> GetCartaz(int? dias)
    {
        var agora =  DateTime.Now;
        var limite = agora.AddDays(dias ?? 7);

        var sessoes = await _context.Sessoes.Where(s=> s.DataHoraInicio > agora && s.DataHoraInicio < limite ).ToListAsync();

        return Ok(sessoes);
        
    }
    [HttpGet("Ocupacao")]
public async Task<ActionResult<List<OcupacaoDto>>> GetOcupacao()
{
    var ocupacao = await _context.Sessoes
        .Include(s => s.Filme)
        .Include(s => s.Sala)
        .Select(s => new OcupacaoDto
        {
            SessaoId = s.Id,
            FilmeTitulo = s.Filme.Titulo,
            SalaNome = s.Sala.Nome,
            CapacidadeMaxima = s.Sala.CapacidadeTotal,
            IngressosVendidos = _context.Ingressos
                .Count(i => i.SessaoId == s.Id)
        })
        .ToListAsync();

    return Ok(ocupacao);
}
}