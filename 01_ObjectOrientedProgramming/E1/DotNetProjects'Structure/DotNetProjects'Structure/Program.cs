using AudioManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetProjects_Structure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vehiculo vehiculo = null;
            vehiculo = new Automovil();
            vehiculo.VehiculoSonido();

            vehiculo = new Avion();
            vehiculo.VehiculoSonido();

            vehiculo = new Camion();
            vehiculo.VehiculoSonido();

            vehiculo = new Moto();
            vehiculo.VehiculoSonido();

            vehiculo = new Tren();
            vehiculo.VehiculoSonido();

            Console.ReadKey();
        }
    }
}
