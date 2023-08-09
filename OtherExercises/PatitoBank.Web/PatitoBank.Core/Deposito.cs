using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatitoBank.Core
{
    public class Deposito : Transaccion
    {

        public string Concepto { get; set; }
    }
}
