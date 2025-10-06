using System;

namespace LojaApi.Entities;

public class Produto
{
    public int Id { get; set; }
    public string Codigo { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public decimal Estoque { get; set; } = decimal.Zero;
}
