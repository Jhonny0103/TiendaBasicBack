using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TiendaBasic.Models;
using TiendaBasic.Repositories;

namespace TiendaBasic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private RepositoryCliente repo;
        public ClienteController(RepositoryCliente repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cliente>>> GetClientes()
        {
            return await this.repo.GetClientesAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Cliente>> InsertCliente(string nombre, string apellido, int telefono, string email)
        {
            Cliente newCliente = await this.repo.InsertClienteAsync(nombre, apellido, telefono, email);
            return Ok(newCliente);
        }

        [HttpPut]
        public async Task<ActionResult<Cliente>> UpdateCliente(int idCliente, string nombre, string apellido, int telefono, string email)
        {
            Cliente updatedCliente = await this.repo.UpdateClienteAsync(idCliente, nombre, apellido, telefono, email);
            return Ok(updatedCliente);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteCliente(int idCliente)
        {
            await this.repo.DeleteClienteAsync(idCliente);
            return Ok();
        }
    }
}
