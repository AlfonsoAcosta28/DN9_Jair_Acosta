using PatitoBank.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PatitoBank.Client
{
    public class Program
    {
        private static readonly string menu = "0.=EXIT\n" +
            "1.-Create an account\n" +
            "2.-Account balance\n" +
            "3.-Deposit to account\n" +
            "4.-Withdraw from the account\n" +
            "5.-Total revenues and expenses\n" +
            "6.-Transaction history of an account";
        public static void Main(string[] args)
        {
            var prueba = crearCuenta(new Cuenta
            {
                Usuario = new Usuario
                {
                    Name = "Jair Alfonso",
                    RFC = "AODJ2811003HMN"
                },
                Saldo = 100
            }).Result;
            var salida = true;
            do
            {

                Console.WriteLine(menu);
                int number = int.Parse(Console.ReadLine());

                switch (number)
                {
                    case 1:
                        Console.WriteLine("\nEnter the name of the Account Holder");
                        var name = Console.ReadLine();

                        Console.WriteLine("\nEnter of the RFC of the Account Holder");
                        var rfc = Console.ReadLine();
                        Usuario usu = new Usuario()
                        {
                            Name = name,
                            RFC = rfc
                        };
                        Cuenta cuenta = new Cuenta()
                        {
                            Usuario = usu

                        };
                        Cuenta respuesta = crearCuenta(cuenta).Result;
                        if (respuesta != null)
                        {

                            Console.Clear();
                            Console.WriteLine("\n\n***************  Successfully created  ***************\n\n");
                        }
                        break;
                    case 2:
                        Console.WriteLine("\nEnter the Id of the account");
                        number = int.Parse(Console.ReadLine());
                        respuesta = GetCuenta(number).Result;
                        if (respuesta != null)
                        {

                            Console.Clear();
                            Console.WriteLine("\n\n***************  Account Balance  ***************\n\n");
                            Console.WriteLine("Name: " + respuesta.Usuario.Name);
                            Console.WriteLine("Balance: " + respuesta.Saldo);
                            Console.WriteLine("\n\n");
                        }
                        else
                        {

                            Console.Clear();
                            Console.WriteLine("\n\n***************  Not account found  ***************\n\n");

                        }
                        break;
                    case 3:
                        Console.WriteLine("\nEnter the Id of the account");
                        number = int.Parse(Console.ReadLine());
                        respuesta = GetCuenta(number).Result;
                        if (respuesta == null)
                        {
                            Console.Clear();
                            Console.WriteLine("\n\n***************  Not account found  ***************\n\n");
                            break;
                        }

                        Console.WriteLine("\nName of the acount: " + respuesta.Usuario.Name);
                        Console.WriteLine("\nEnter the amount to deposit");
                        decimal amount = decimal.Parse(Console.ReadLine());

                        Console.WriteLine("\nEnter the concept");
                        string concept = Console.ReadLine();

                        Deposito transaction = new Deposito()
                        {
                            Concepto = concept,
                            Fecha = DateTime.Now,
                            CuentaId = respuesta.Id,
                            //  tipoTransaccion = TipoTransaccion.Deposito,
                            Monto = amount
                        };

                        respuesta.Depositos.Add(transaction);
                        respuesta = transaccionCuenta(transaction).Result;

                        if (respuesta != null)
                        {
                            Console.Clear();
                            Console.WriteLine("\n\n***************  Successfully  ***************\n\n");
                        }
;                       break;
                    case 4:
                        Console.WriteLine("\nEnter the Id of the account");
                        number = int.Parse(Console.ReadLine());
                        respuesta = GetCuenta(number).Result;
                        if (respuesta == null)
                        {
                            Console.Clear();
                            Console.WriteLine("\n\n***************  Not account found  ***************\n\n");
                            break;
                        }
                        if (respuesta.Saldo == 0)
                        {
                            Console.Clear();
                            Console.WriteLine("\n\n***************  Insufficient Balance  ***************\n\n");
                            break;
                        }
                        Console.WriteLine("\nName of the acount: " + respuesta.Usuario.Name);
                        Console.WriteLine("\nEnter the amount to withdraw");
                        amount = decimal.Parse(Console.ReadLine());

                        

                        Retiro retiro = new Retiro()
                        {
                            
                            Fecha = DateTime.Now,
                            CuentaId = respuesta.Id,
                            //  tipoTransaccion = TipoTransaccion.Deposito,
                            Monto = amount
                        };
                        respuesta = transaccionCuenta(retiro).Result;

                        if (respuesta != null)
                        {
                            Console.Clear();
                            Console.WriteLine("\n\n***************  Successfully  ***************\n\n");
                        }
                        break;
                    case 5:
                        var movimientos = GetTransacciones().Result;
                        Console.Clear();
                        Console.WriteLine("\n\n***************  Bank Income and Exponces  ***************\n\n");
                        decimal ingresos = 0, egresos = 0;
                        foreach(var element in movimientos.Depositos)
                        {
                            ingresos += element.Monto;
                        }
                        foreach (var element in movimientos.Retiros)
                        {
                            egresos += element.Monto;
                        }
                        Console.WriteLine("INCOME: "+ingresos);
                        Console.WriteLine("\nEXPENCES: "+egresos);

                        break;
                    case 6:
                        Console.WriteLine("\nEnter the Id of the account");
                        number = int.Parse(Console.ReadLine());
                        Console.WriteLine("\nEnter the Password");
                        string passworc = Console.ReadLine();

                        if(passworc == null || !passworc.Equals("1234"))
                        {
                            Console.Clear();
                            Console.WriteLine("\n\n***************  Incorrect Password  ***************\n\n");
                            break;
                        }
                        respuesta = GetCuenta(number).Result;
                        if (respuesta == null)
                        {
                            Console.Clear();
                            Console.WriteLine("\n\n***************  Not account found  ***************\n\n");
                            break;
                        }
                        Console.Clear();
                        Console.WriteLine("NAME: "+respuesta.Usuario.Name);
                        Console.WriteLine("\nAMOUNT: "+respuesta.Saldo);
                        Console.WriteLine("\nDEPOSITS");
                        foreach(var element in respuesta.Depositos)
                        {
                            Console.WriteLine("DATE: " + element.Fecha+" AMOUNT: "+element.Monto+" CONCEPT: "+element.Concepto);
                        }
                        Console.WriteLine("\nRETREATS");

                        foreach (var element in respuesta.Retiros)
                        {
                            Console.WriteLine("DATE: " + element.Fecha + " AMOUNT: " + element.Monto);
                        }
                        break;
                    case 0:
                        salida = false;
                        break;
                    default:
                        Console.WriteLine("Número no válido");
                        break;
                }
            } while (salida);
        }
        private static async Task<Cuenta> crearCuenta(Cuenta cuenta)
        {
            string jsonContent = Newtonsoft.Json.JsonConvert.SerializeObject(cuenta);

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var requestContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync("https://localhost:7294/api/PatitoBank", requestContent);
                    // HttpResponseMessage response = await client.PostAsync("https://localhost:7294/api/PatitoBank", new StringContent(jsonContent, Encoding.UTF8, "application/json"));
                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();

                    Cuenta cuenta2 = Newtonsoft.Json.JsonConvert.DeserializeObject<Cuenta>(responseBody);

                    return cuenta2;
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine($"Error de solicitud HTTP: {ex.Message}");
                    return null;
                }
            }

        }

        public static async Task<List<Cuenta>> GetCuentas()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://localhost:7294/api/PatitoBank");
            response.EnsureSuccessStatusCode();

            string respondeBody = await response.Content.ReadAsStringAsync();
            List<Cuenta> list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Cuenta>>(respondeBody);

            return list;
        }

        public static async Task<Cuenta> GetCuenta(int id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"https://localhost:7294/api/PatitoBank/{id}");
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();

            Cuenta cuenta = Newtonsoft.Json.JsonConvert.DeserializeObject<Cuenta>(responseBody);

            return cuenta;
        }

        public static async Task<Movimientos> GetTransacciones()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://localhost:7294/api/PatitoBank/Transacciones");
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();

            Movimientos cuenta = Newtonsoft.Json.JsonConvert.DeserializeObject<Movimientos>(responseBody);

            return cuenta;
        }

        private static async Task<Cuenta> transaccionCuenta(Transaccion cuenta)
        {
            string jsonContent = Newtonsoft.Json.JsonConvert.SerializeObject(cuenta);

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = null;
                    var requestContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                    if (cuenta is Deposito)
                    {
                        response = await client.PostAsync($"https://localhost:7294/api/PatitoBank/Deposito", requestContent);
                    }
                    else if (cuenta is Retiro)
                    {
                        response = await client.PostAsync($"https://localhost:7294/api/PatitoBank/Retiro", requestContent);

                    }
                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();

                    Cuenta cuenta2 = Newtonsoft.Json.JsonConvert.DeserializeObject<Cuenta>(responseBody);

                    return cuenta2;
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine($"Error de solicitud HTTP: {ex.Message}");
                    return null;
                }
            }

        }


    }
}
