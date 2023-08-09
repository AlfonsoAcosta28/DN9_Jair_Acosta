using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatitoBank.Core
{
    public class Cuenta
    {
        [Key]
        public int Id { get; set; }
        public decimal Saldo { get; set; }
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public List<Retiro> Retiros { get; set; }
        public List<Deposito> Depositos { get; set; }

        public Cuenta()
        {
            Retiros = new List<Retiro>();
            Depositos = new List<Deposito>();
            Saldo = 0;
            Usuario = new Usuario();
        }
    }
}
