//using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class agreda
    {
        [Key]
        public int agredaID { get; set; }

        [Required]
        [DisplayName("Nombre Completo")]
        [StringLength(24, ErrorMessage = "This field must contain between {2} and {1} characters", MinimumLength = 2)]
        public string Friendofagreda { get; set; }

        [Required]
        public Place Place_lista { get; set; }

        public enum Place
        { 
        Colegio,
        Universidad,
        Parque,
        Museo,
        Cine
        }
        [EmailAddress]
        public string email { get; set; }

        [DisplayName("Cumpleaños")]
        [DataType(DataType.Date)]

        public DateTime Birthday { get; set; }

    }
}