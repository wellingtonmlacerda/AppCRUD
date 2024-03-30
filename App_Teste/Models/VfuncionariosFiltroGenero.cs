﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace App_Teste.Models;

[Keyless]
public partial class VfuncionariosFiltroGenero
{
    [Column("ID")]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    [Unicode(false)]
    public string Nome { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime DataNascimento { get; set; }

    public double Salario { get; set; }

    [Column("GeneroID")]
    public int? GeneroId { get; set; }

    [Required]
    [StringLength(100)]
    [Unicode(false)]
    public string NomeGenero { get; set; }
}