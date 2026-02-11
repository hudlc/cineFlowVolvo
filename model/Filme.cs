using System.ComponentModel.DataAnnotations;

namespace model;

public class Filme
{
    [Key]
    public int Id { get; set; }
    public string Titulo { get; set; } = null!;
    public int DuracaoMinutos { get; set; }
    public string Genero { get; set; } = null!;
    

    public List<Sessao> sessoes = new();

    protected Filme() { }

    public Filme(string titulo, int duracaoMinutos, string genero)
    {
        Titulo = titulo;
        DuracaoMinutos = duracaoMinutos;
        Genero = genero;
    }
}
