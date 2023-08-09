
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PatitoBank.Core
{
    public class Transaccion
    {
        [Key]
        public int Id { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }

        public int CuentaId { get; set; }
      //  [JsonIgnore]
     //   public Cuenta Cuenta { get; set; }
       // public TipoTransaccion tipoTransaccion { get; set; }

        public Transaccion()
        {
          // Cuenta = new Cuenta();
        }
    }

    public enum TipoTransaccion
    {
        Deposito, Retiro
    }
}
