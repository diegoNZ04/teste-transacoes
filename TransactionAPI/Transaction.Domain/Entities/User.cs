using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Transaction.Domain.Entities
{
    public class User
    {   // Identificador Único 	
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        // Nome 
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        // Idade
        [Required]
        public int Age { get; set; }
        // Lista de Transações
        public ICollection<Trade> Trades { get; set; } = [];
    }
}