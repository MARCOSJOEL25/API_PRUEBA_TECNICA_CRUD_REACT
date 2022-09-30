using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_PRUEBA_TECNICA_CRUD_REACT.Models;

namespace API_PRUEBA_TECNICA_CRUD_REACT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactoEntityExampleController : ControllerBase
    {
        private readonly API_CONTACTO_PRUEBA_TECNINA_REACT_FRONTContext _context;

        public ContactoEntityExampleController(API_CONTACTO_PRUEBA_TECNINA_REACT_FRONTContext context)
        {
            _context = context;
        }

        // GET: api/ContactoEntityExample
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contacto>>> GetContactos()
        {
            return await _context.Contactos.ToListAsync();
        }

        // GET: api/ContactoEntityExample/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contacto>> GetContacto(int id)
        {
            var contacto = await _context.Contactos.FindAsync(id);

            if (contacto == null)
            {
                return NotFound();
            }

            return contacto;
        }

        // PUT: api/ContactoEntityExample/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContacto(int id, Contacto contacto)
        {
            if (id != contacto.IdContacto)
            {
                return BadRequest();
            }

            _context.Entry(contacto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ContactoEntityExample
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Contacto>> PostContacto(Contacto contacto)
        {
            _context.Contactos.Add(contacto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContacto", new { id = contacto.IdContacto }, contacto);
        }

        // DELETE: api/ContactoEntityExample/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Contacto>> DeleteContacto(int id)
        {
            var contacto = await _context.Contactos.FindAsync(id);
            if (contacto == null)
            {
                return NotFound();
            }

            _context.Contactos.Remove(contacto);
            await _context.SaveChangesAsync();

            return contacto;
        }

        private bool ContactoExists(int id)
        {
            return _context.Contactos.Any(e => e.IdContacto == id);
        }
    }
}
