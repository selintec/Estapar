using System.ComponentModel.DataAnnotations;

namespace Estapar.Models
{
    public class Carro
    {
        public int Id { get; set; }

        [Display(Name = "Marca")]
        [Required]
        [StringLength(25)]
        public string nom_marca { get; set; }    

        [Display(Name = "Modelo")]
        [Required]
        [StringLength(25)]
        public string nom_modelo { get; set; }

        [Display(Name = "Placa")]
        [Required]
        [StringLength(10)]
        public string num_placa { get;set; }
    }
}
