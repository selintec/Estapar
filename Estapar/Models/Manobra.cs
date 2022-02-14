using System;
using System.ComponentModel.DataAnnotations;

namespace Estapar.Models
{
    public class Manobra
    {
        public int Id { get; set; }
        public virtual Manobrista Manobrista { get; set; }
        public virtual Carro Carro { get; set; }

        [Display(Name = "Motorista")]
        public int ManobristaId { get; set; }

        [Display(Name = "Carro")]
        public int CarroId { get; set; }

        [Display(Name = "Data Manobra")]
        [DataType(DataType.Text)]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime dat_manobra { get; set; }

        [Display(Name = "Tipo")]
        [Required]
        [StringLength(25)]
        public string tip_manobra { get; set; }

    }
}
