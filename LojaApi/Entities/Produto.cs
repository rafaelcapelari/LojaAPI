using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LojaApi.Entities;

[Table("TB_PRODUTOS")]
public class Produto
{
    [Key]
    [Column("id_produto")]
    public int Id { get; set; }

    [Column("codigo")]
    [Required(ErrorMessage = "O codigo do produto é obrigatorio.")]
    [StringLength(15)]
    public string Codigo { get; set; } = string.Empty;

    [Column("descricao")]
    [Required(ErrorMessage = "A descrição do produto é obrigatorio.")]
    [StringLength(150, ErrorMessage = "O tamanho da descrição deve ter no maximo 150 caracteres.")]
    public string Descricao { get; set; } = string.Empty;

    [Column("estoque", TypeName = "decimal(18,3)")]
    public decimal Estoque { get; set; } = decimal.Zero;
    
    [Column("data_cadastro")]
    public DateTime DataCadastro { get; set; }

    [Column("id_categoria")]
    [Required(ErrorMessage = "A categoria é obrigatorio.")]
    public int CategoriaId { get; set; }

    [ForeignKey("CategoriaId")]
    public Categoria? Categoria { get; set; }

}