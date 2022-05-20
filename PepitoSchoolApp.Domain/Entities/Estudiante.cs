using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PepitoSchoolApp.Domain.Entities
{
    public partial class Estudiante
    {
        public int Id { get; set; }
        public string Names { get; set; }
        public string Lastnames { get; set; }
        public string Carnet { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int Matematica { get; set; }
        public int Contabilidad { get; set; }
        public int Programacion { get; set; }
        public int Estadistica { get; set; }
    }
}
