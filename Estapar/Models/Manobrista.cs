using System;
using System.ComponentModel.DataAnnotations;

namespace Estapar.Models
{
    public class Manobrista
    {
        public int Id { get; set; }

        [Display(Name = "CPF")]
        [Required]
        [StringLength(25)]
        public string num_cpf { get; set; }

        [Display(Name = "Nome")]
        [Required]
        [StringLength(100)]
        public string nom_manobrista { get; set; }

        [Display(Name = "Data Nascimento")]
        [DataType(DataType.Text)]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime dat_nascimento { get; set; }
    }
}
