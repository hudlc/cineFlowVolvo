using System.ComponentModel.DataAnnotations;

namespace model;

public class Ingresso
{
    [Key]
    public int Id{get;set;}
    public int SessaoId{get;set;}
    public Sessao Sessao {get;set;} = null!;

    public decimal Preco{get;set;}

    public Ingresso() {}

    public Ingresso(int sessaoId, decimal preco)
    {
        
        SessaoId = sessaoId;
        Preco = preco;
    }



}