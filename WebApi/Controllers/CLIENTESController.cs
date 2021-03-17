using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Web.Http.Description;

namespace WebApi.Controllers
{
    public class CLIENTESController : ApiController

    {
        //Inicializa la base de datos
        private PRUEBAHCEntities db = new PRUEBAHCEntities();

        // GET: api/CLIENTES
        [HttpGet]
        public IEnumerable<CLIENTES> Get()
        {
            var listClientes = db.CLIENTES.ToList();
            return listClientes;
        }

        // GET: api/CLIENTES/5
        [HttpGet]
        public CLIENTES Get(int id)
        {
            var Cliente = db.CLIENTES.FirstOrDefault(x => x.CLI_ID == id);
            return Cliente;
        }

        [HttpPost]
        // POST: api/CLIENTES
        [ResponseType(typeof(CLIENTES))]
        public IHttpActionResult Post(CLIENTES cLIENTES)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CLIENTES.Add(cLIENTES);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CLIENTESExists(cLIENTES.CLI_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = cLIENTES.CLI_ID }, cLIENTES);
        }

        [HttpPut]
        // PUT: api/CLIENTES/5
        public IHttpActionResult Put(int id, CLIENTES cLIENTES)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cLIENTES.CLI_ID)
            {
                return BadRequest();
            }

            db.Entry(cLIENTES).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CLIENTESExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete]
        // DELETE: api/CLIENTES/5
        public void Delete(int id)
        {

            CLIENTES cLIENTES = db.CLIENTES.Find(id);
            if (cLIENTES != null)
            {
                db.CLIENTES.Remove(cLIENTES);
                db.SaveChanges();
            }

        }
        private bool CLIENTESExists(int id)
        {
            return db.CLIENTES.Count(e => e.CLI_ID == id) > 0;
        }
    }
}
