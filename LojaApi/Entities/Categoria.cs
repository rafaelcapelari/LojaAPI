using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LojaApi.Entities;

[Table("TB_CATEGORIAS")]
public class Categoria
{
    [Key]
    [Column("id_categoria")]
    public int Id { get; set; }

    [Column("descricao")]
    [Required(ErrorMessage = "O descrição da categoria é obrigatorio.")]
    [StringLength(150)]
    public string Descricao { get; set; } = string.Empty;
    
    [JsonIgnore]
    public ICollection<Produto> Produtos { get; set; } = new List<Produto>();
}