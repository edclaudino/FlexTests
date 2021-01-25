using System;
using System.ComponentModel.DataAnnotations;

namespace ValidaParametros.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} é um campo obrigatório")]
        [MinLength(11, ErrorMessage = "{0} deve ter 11 caracteres")]
        [MaxLength(11, ErrorMessage = "{0} deve ter 11 caracteres")]
        public string CPF { get; set; }

        public int CallId { get; set; }

        public DateTime Data { get; set; }
        
        [Required(ErrorMessage = "{0} é um campo obrigatório")]
        [MinLength(10, ErrorMessage = "{0} deve ter no mínimo 10 caracteres")]
        [MaxLength(11, ErrorMessage = "{0} deve ter no máximo 11 caracteres")]
        public string Telefone { get; set; }
    }
}