namespace dto;
using model;

public class OcupacaoDto
{

    public int SessaoId { get; set; }
    public string FilmeTitulo { get; set; } = null!;
    public string SalaNome { get; set; } = null!;
    public int CapacidadeMaxima { get; set; }
    public int IngressosVendidos { get; set; }

    public OcupacaoDto(){}

    
}