﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace App_Teste.Models
{
    public partial class SelectDependentesTBResult
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public int? FuncionarioId { get; set; }
        public int? GeneroID { get; set; }
    }
}
