namespace dto;
using model;

public class RespostaIngressoDto
{
    public int Id {get;set;}
    public int SessaoId{get;set;}
    public decimal Preco{get;set;}

    public RespostaIngressoDto() {}

    public RespostaIngressoDto(int id,int sessaoId, decimal preco)
    {
        Id = id;
        SessaoId = sessaoId;
        Preco = preco;
    }
}
