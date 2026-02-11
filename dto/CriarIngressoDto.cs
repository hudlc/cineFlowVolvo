namespace dto;
using model;

public class CriarIngressoDto
{
    public int SessaoId{get;set;}
    public decimal Preco{get;set;}

    public CriarIngressoDto() {}

    public CriarIngressoDto(int sessaoId, decimal preco)
    {
        SessaoId = sessaoId;
        Preco = preco;
    }
}
