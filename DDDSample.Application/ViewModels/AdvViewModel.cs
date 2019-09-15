using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DDDSample.Application.ViewModels
{
    public class AdvViewModel
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "A marca é necessária")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Marca")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "O modelo é necessário")]
        [MinLength(1)]
        [MaxLength(100)]
        [DisplayName("Modelo")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "A Versão é necessária")]
        [MinLength(1)]
        [MaxLength(100)]
        [DisplayName("Versao")]
        public string Versao { get; set; }

        [Required(ErrorMessage = "O ano é necessário")]
        [DisplayName("Ano")]
        public int Ano { get; set; }

        [Required(ErrorMessage = "A Quilometragem é necessária")]
        [DisplayName("Quilometragem")]
        public int Quilometragem { get; set; }

        [Required(ErrorMessage = "A Observação é necessária")]
        [DisplayName("Observacao")]
        public string Observacao { get; set; }
    }
}
