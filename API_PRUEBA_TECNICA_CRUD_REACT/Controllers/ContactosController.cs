using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_PRUEBA_TECNICA_CRUD_REACT.Models;
using Microsoft.EntityFrameworkCore;


namespace API_PRUEBA_TECNICA_CRUD_REACT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactosController : ControllerBase
    {
        private readonly API_CONTACTO_PRUEBA_TECNINA_REACT_FRONTContext _context;

        public ContactosController(API_CONTACTO_PRUEBA_TECNINA_REACT_FRONTContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("ListData")]
        public async Task<IActionResult> ListData()
        {
            List<Contacto> lista = await _context.Contactos.OrderByDescending(c => c.IdContacto).ToListAsync();

            return StatusCode(StatusCodes.Status200OK, lista);
        }

        [HttpPost]
        [Route("SaveData")]
        public async Task<IActionResult> Save([FromBody] Contacto contacto)
        {
            await _context.Contactos.AddAsync(contacto);
            await _context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, "ok");
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] Contacto contacto)
        {
            _context.Contactos.Update(contacto);
            await _context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, "ok");
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete([FromBody] int id)
        {
            Contacto contactoDelete = _context.Contactos.Find(id);

            _context.Contactos.Remove(contactoDelete);
            await _context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, "ok");
        }


    }
}
