using System.ComponentModel.DataAnnotations.Schema;

namespace App_Teste.Models
{
    [Table("GeneroDB")]
    public class Genero
    {
        public int Id { get; set; }
        public string NomeGenero { get; set; } = "";
    }
}
