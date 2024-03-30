
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace App_Teste.Models
{
    public partial class Funcionario
    {
        public int ID { get; set; }
        public string Nome { get; set; } = "";
        public DateTime DataNascimento { get; set; }
        public double Salario { get; set; }
        public int? GeneroID { get; set; }
    }
}
