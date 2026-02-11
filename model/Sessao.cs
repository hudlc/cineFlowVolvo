using System.ComponentModel.DataAnnotations;

namespace model;

public class Sessao
{
    [Key]
    public int Id{get;set;}
    public DateTime DataHoraInicio{get;set;}
    public DateTime DataHoraFim{get;set;}


    public int FilmeId{get;set;}
    public Filme Filme{get;set;} = null!;
    public int SalaId{get;set;}
    public Sala Sala{get;set;} = null!;

    public Sessao() { }

    public Sessao (int filmeId, int salaId, DateTime dataHoraInicio, DateTime dataHoraFim)
    {
        FilmeId = filmeId;
        SalaId = salaId;
        DataHoraInicio = dataHoraInicio;
        DataHoraFim = dataHoraFim;

    }


}