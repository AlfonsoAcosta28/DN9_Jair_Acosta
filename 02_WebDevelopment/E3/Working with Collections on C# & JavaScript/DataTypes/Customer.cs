using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypes
{
    internal class Customer
    {
        public int Id { get; set; } 
        public string Name { get; set; }

        public string Email { get; set; }   

        public DateTime fechaRegistro { get; set; }

        public string datos()
        {
            return "Nombre: "+this.Name +" Fecha de registro: "+this.fechaRegistro;
        }

    }
}
