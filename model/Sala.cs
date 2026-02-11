using System.ComponentModel.DataAnnotations;

namespace model;

public class Sala
{

    [Key]
    public int Id{get;set;}

    public string Nome{get;set;} = null!;

    public int CapacidadeTotal{get;set;}

    public List<Sessao> Sessoes {get;set;} = new();
    public Sala() {}

    public Sala(string nome, int capacidadeTotal)
    {
        Nome = nome;
        CapacidadeTotal = capacidadeTotal;
    }


    
}