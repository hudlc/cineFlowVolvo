namespace dto;
public class RespostaSessaoDto
{
    public int Id { get; set; }
    public DateTime DataHoraInicio { get; set; }
    public DateTime DataHoraFim { get; set; }

    public string TituloFilme { get; set; } = null!;
    public string NomeSala { get; set; } = null!;


    public RespostaSessaoDto(){}
    public RespostaSessaoDto(int id, DateTime dataHoraInicio, DateTime dataHoraFim, string tituloFilme, string nomeSala)
    {
        Id = id;
        DataHoraInicio = dataHoraInicio;
        DataHoraFim = dataHoraFim;
        TituloFilme = tituloFilme;
        NomeSala = nomeSala;
    }
}
