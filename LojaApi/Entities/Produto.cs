using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaApi.Entities
{
    [Table("TB_PRODUTOS")]
    public class Produto
    {
        [Key]
        [Column("id_produto")]
        public int Id { get; set; }

        [Column("codigo")]
        [Required]
        [StringLength(15)]
        public string Codigo { get; set; } = string.Empty;

        [Column("descricao")]
        [Required]
        [StringLength(150)]
        public string Descricao { get; set; } = string.Empty;

        [Column("estoque")]
        public decimal Estoque { get; set; } = decimal.Zero;
        
        [Column("data_cadastro")]
        public DateTime DataCadastro { get; set; }

    }
}