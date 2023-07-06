using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPsGymManager.DataAccess.Entities
{
    public class Members
    {
        [Key]
        public int Id { get; set; }
        public DateTime fi_meb { get; set; }
        public DateTime ff_meb { get; set; }
        public int User { get; set; }
        public int MemTyp { get; set; }
        public string nom_memT { get; set; }

    }
}
