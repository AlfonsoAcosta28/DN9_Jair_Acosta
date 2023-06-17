using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;

namespace AudioManager
{
    public class Vehiculo
    {
        public virtual void VehiculoSonido()
        {
            Console.WriteLine("Reproduciendo: "+ToString());
    }
    }
}
