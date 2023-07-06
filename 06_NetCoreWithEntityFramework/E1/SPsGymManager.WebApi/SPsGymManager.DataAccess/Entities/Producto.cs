using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPsGymManager.DataAccess.Entities
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }
        public string nom_proTyp { get; set; }
        public int can_inv { get; set; }
    }
}
