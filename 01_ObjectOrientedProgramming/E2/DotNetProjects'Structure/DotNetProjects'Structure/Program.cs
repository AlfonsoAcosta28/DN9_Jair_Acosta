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
           for (int i = 1; i <= 10; i++) { 
                Console.WriteLine("Type the vehicle\nIteration number: "+i+"\n\nAuto\nAvion\nCamion\nMoto\nTren");
                string seleccion = Console.ReadLine().ToLower();

                Vehiculo vehiculo = null;

                switch (seleccion)
                {
                    case "auto":
                        vehiculo = new Automovil();
                        break;
                    case "avion":
                        vehiculo = new Avion();
                        break;
                    case "camion":
                        vehiculo = new Camion();
                        break;
                    case "moto":
                        vehiculo = new Moto();
                        break;
                    case "tren":
                        vehiculo = new Tren();
                        break;
                    default:
                        Console.WriteLine("Not found");
                        break;
                }

                if (vehiculo != null)
                {
                    vehiculo.VehiculoSonido();
                }
            }
        }
    }
}
