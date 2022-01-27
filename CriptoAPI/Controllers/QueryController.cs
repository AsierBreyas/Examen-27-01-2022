using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cripto.Models;

namespace CriptoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueryController : ControllerBase
    {
        private readonly CryptoContext db;

        public QueryController(CryptoContext context)
        {
            db = context;
        }

        [HttpGet("0")]
        public ActionResult Query0(int ValorActual = 50)
        {
            // Ejemplo de método en controlador
            var list = db.Moneda.ToListAsync();

            return Ok(new
            {
                ValorActual = "Parámetros para usar cuando sea posible",
                Descripcion = "Monedas con valor actual superior a 50€ ordenadas alfabéticamente ",
                Valores = list,
            });
        }
        [HttpGet("1")]
        public ActionResult Query1(int ValorActual = 50)
        {
            // Ejemplo de método en controlador
            var list = db.Moneda.Where(m => m.Actual > 50M).OrderByDescending( m => m.Actual).ToListAsync();

            return Ok(new
            {
                ValorActual = "Parámetros para usar cuando sea posible",
                Descripcion = "Ejemplo en MODO NO ASYNC - DEBE SER ASÍNCRONOS",
                Valores = list,
            });
        }
        [HttpGet("2")]
        public ActionResult Query2()
        {
            // Ejemplo de método en controlador
            var list =db.Cartera.Where(c => c.Contratos.Count > 2).Select(c => new{
                    CarteraId = c.CarteraId,
                    TotalMonedas = c.Contratos.Count
                }).ToListAsync();

            return Ok(new
            {
                ValorActual = "Parámetros para usar cuando sea posible",
                Descripcion = "Carteras con más de 2 monedas contratadas",
                Valores = list,
            });
        }
        [HttpGet("3")]
        public ActionResult Query3()
        {
            // Ejemplo de método en controlador
            var list =db.Cartera.GroupBy(c => c.Exchange).Select(c => new
                {
                    Exchange = c.Key,
                    TotalCarteras = c.Count()
                }).OrderByDescending(c => c.TotalCarteras).ToListAsync();

            return Ok(new
            {
                ValorActual = "Parámetros para usar cuando sea posible",
                Descripcion = "Exchanges ordenados por números de carteras",
                Valores = list,
            });
        }
         [HttpGet("4")]
        public ActionResult Query4()
        {
            // Ejemplo de método en controlador
            var list = db.Cartera.SelectMany(c => c.Contratos, (ca,co) => new{
                    Exchange = ca.Exchange,
                    TotalMonedas = co.Cantidad
                }).ToListAsync();

            return Ok(new
            {
                ValorActual = "Parámetros para usar cuando sea posible",
                Descripcion = "Exchanges ordenados por cantidad de monedas",
                Valores = list,
            });
        }
         [HttpGet("5")]
        public ActionResult Query5()
        {
            // Ejemplo de método en controlador
            var list = db.Moneda.SelectMany(c => c.Contratos, (mo, co) => new{
                    Moneda = mo.MonedaId,
                    Contrato = mo.MonedaId + co.CarteraId,
                    ValorContrato = mo.Actual * co.Cantidad,
                }).OrderByDescending(x => x.Moneda).ToListAsync();

            return Ok(new
            {
                ValorActual = "Parámetros para usar cuando sea posible",
                Descripcion = "Ejemplo en MODO NO ASYNC - DEBE SER ASÍNCRONOS",
                Valores = list,
            });
        }
         [HttpGet("6")]
        public ActionResult Query6()
        {
            // Ejemplo de método en controlador
            var list = db.Moneda.ToListAsync();

            return Ok(new
            {
                ValorActual = "Parámetros para usar cuando sea posible",
                Descripcion = "Ejemplo en MODO NO ASYNC - DEBE SER ASÍNCRONOS",
                Valores = list,
            });
        }
         [HttpGet("7")]
        public ActionResult Query7()
        {
            // Ejemplo de método en controlador
            var list = db.Moneda.SelectMany(c => c.Contratos, (mo, co) => new{
                    Moneda = mo.MonedaId,
                    ValorContrato = mo.Actual * co.Cantidad,
                    Contratos = mo.Contratos.Count()
                }).ToListAsync();

            return Ok(new
            {
                ValorActual = "Parámetros para usar cuando sea posible",
                Descripcion = "Ejemplo en MODO NO ASYNC - DEBE SER ASÍNCRONOS",
                Valores = list,
            });
        }
    }
}
