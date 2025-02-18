using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Transaction.Domain.Enums;

namespace Transaction.Domain.Entities
{
    public class Trade
    {
        // Identificador Único
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        // Descrição
        [Required]
        [MaxLength(255)]
        public string Description { get; set; } = string.Empty;
        // Valor
        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Amount { get; set; }
        // Tipo
        [Required]
        public TradeType Type { get; set; }
        // Id do Usuário - Foreign Key
        [Required]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; } = null!;
    }
}