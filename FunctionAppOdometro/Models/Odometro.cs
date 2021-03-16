using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FunctionAppOdometro.Models
{
    class Odometro
    {
        [Key]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
        [DataType(DataType.DateTime)]
        [Required]
        public DateTime DateTime { get; set; }
        [Required]
        public int Step { get; set; }
    }
}
