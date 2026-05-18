using TiendaBasic.Models;

namespace TiendaBasic.Repositories
{
    public interface IRepositoryCliente
    {
        public Task<Cliente> InsertClienteAsync(string nombre, string apellido, int telefono, string email);
        public Task<Cliente> UpdateClienteAsync(int idCliente, string nombre, string apellido, int telefono, string email);
        public Task DeleteClienteAsync(int idCliente);
        public Task<List<Cliente>> GetClientesAsync();
    }
}
