using System.ComponentModel.DataAnnotations.Schema;

namespace App_Teste.Models
{
    [Table("DependenteDB")]
    public class Dependente
    {
        public int ID { get; set; }
        public string Nome { get; set; } = "";
        public DateTime DataNascimento { get; set; }
        public int? FuncionarioId { get; set; }
        public int? GeneroID { get; set; }
    }
}
