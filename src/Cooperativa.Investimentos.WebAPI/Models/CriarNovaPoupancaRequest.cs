﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Cooperativa.Investimentos.WebAPI.Models
{
    public class CriarNovaPoupancaRequest
    {
        [Required]
        public string CooperativaId { get; set; }
        [Required]
        public string PostoAtendimentoId { get; set; }
        [Required]
        public string ContaCorrenteId { get; set; }
        [Required]
        public int Numero { get; set; }
        [Required]
        public int Digito { get; set; }
        [Required]
        [Range(1, 999999)]
        public decimal Valor { get; set; }
    }
}