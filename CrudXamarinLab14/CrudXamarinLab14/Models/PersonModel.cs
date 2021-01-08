using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudXamarinLab14.Models
{
    public class PersonModel
    {
        [Key]
        public int Id { get; set; }
        public String Nombre { get; set; }
        public String FechaNacimiento { get; set; }
        public String Estado { get; set; }
    }

}
