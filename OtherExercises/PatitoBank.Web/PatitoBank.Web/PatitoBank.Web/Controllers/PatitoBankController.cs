using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using PatitoBank.Core;
using PatitoBank.DataAccess;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PatitoBank.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatitoBankController : ControllerBase
    {
        protected TestServer server;
        private PatitoBankContext context;
        private int count  = 1;
        // GET: api/<PatitoBankController>
        public PatitoBankController()
        {
            this.server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            var manager = server.Host.Services.GetService<PatitoBankContext>();
            context = manager;
        }
        [HttpGet]
        public async Task<IEnumerable<Cuenta>> Get()
        {
            //await context.Cuentas.AddAsync(cuenta);
            //await context.SaveChangesAsync();
            var list = context.Cuentas.ToList();
            return list;
        }

        // GET api/<PatitoBankController>/5
        [HttpGet("{id}")]
        public async Task<Cuenta> Get(int id)
        {
            //var element = await context.Cuentas.FindAsync(id);
            var element = await context.Cuentas
                .Include(x => x.Usuario)
                .Include(x => x.Depositos)
                .FirstOrDefaultAsync(x => x.Id == id);
            return element;
        }

        // POST api/<PatitoBankController>
        [HttpPost]
        public async Task<Cuenta> Post([FromBody] Cuenta value)
        {
            var usuario = value.Usuario;

           var existingUsuario = await context.Usuarios.FirstOrDefaultAsync(u => u.RFC == usuario.RFC);
            if (existingUsuario == null)
            {
                context.Usuarios.Add(usuario);
               await context.SaveChangesAsync();
            }
            else
            {
                usuario = existingUsuario;
            }
            var nuevaCuenta = new Cuenta
            {
                Saldo = value.Saldo,
                Usuario = usuario
            };
            
            await context.Cuentas.AddAsync(value);
            await context.SaveChangesAsync();

            return value;
        }


        // PUT api/<PatitoBankController>/Deposito
        [HttpPost]
        [Route(nameof(Deposito))]
        public async Task<ActionResult<Cuenta>> Deposito([FromBody] Deposito value)
        {
            try
            {
                var cuenta = await Get(value.CuentaId);

                if (cuenta == null)
                {
                    return NotFound("Cuenta no encontrada");
                }

                cuenta.Saldo += value.Monto;
                cuenta.Depositos.Add(value);
                context.Cuentas.Update(cuenta);

                context.Depositos.Add(value);
                context.SaveChanges();

                return Ok(cuenta);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest($"Error: {ex.Message}");
            }
        }
        [HttpPost]
        [Route(nameof(Retiro))]
        public async Task<ActionResult<Cuenta>> Retiro([FromBody] Retiro value)
        {
            try
            {
                var cuenta = await Get(value.CuentaId);

                if (cuenta == null)
                {
                    return NotFound("Cuenta no encontrada");
                }

                if (cuenta.Saldo < value.Monto)
                {
                    return null;
                }

                cuenta.Saldo -= value.Monto;
                cuenta.Retiros.Add(value);
                context.Cuentas.Update(cuenta);

                context.Retiros.Add(value);
                context.SaveChanges();

                return Ok(cuenta);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpGet]
        [Route(nameof(Transacciones))]
        public async Task<Movimientos> Transacciones()
        {

            var list = context.Depositos.ToList();
            var list2 = context.Retiros.ToList();

            var movimeintos = new Movimientos
            {
                Depositos = list,
                Retiros = list2
            };
            return movimeintos;
        }
    }
}
