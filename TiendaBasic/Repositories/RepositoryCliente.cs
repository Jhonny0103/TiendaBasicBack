using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TiendaBasic.Data;
using TiendaBasic.Models;

namespace TiendaBasic.Repositories
{
    public class RepositoryCliente : IRepositoryCliente
    {
        private TiendaContext context;
        public RepositoryCliente(TiendaContext context)
        {
            this.context = context;
        }

        public async Task<List<Cliente>> GetClientesAsync()
        {
            return await this.context.Clientes.ToListAsync();
        }

        public async Task<Cliente> InsertClienteAsync(string nombre, string apellido, int telefono, string email)
        {
            string sql = "InsertCliente @Nombre, @Apellido, @Telefono, @Email, @EsActivo, @FechaCreado";
            SqlParameter pamNombre = new SqlParameter("@Nombre", nombre);
            SqlParameter pamApellido = new SqlParameter("@Apellido", apellido);
            SqlParameter pamTelefono = new SqlParameter("@Telefono", telefono);
            SqlParameter pamEmail = new SqlParameter("@Email", email);
            SqlParameter pamEsActivo = new SqlParameter("@EsActivo", 1);
            SqlParameter pamFechaCreado = new SqlParameter("@FechaCreado", DateTime.Now);
            await this.context.Database.ExecuteSqlRawAsync(sql, pamNombre, pamApellido, pamTelefono, pamEmail, pamEsActivo, pamFechaCreado);

            Cliente? newCliente = await this.context.Clientes
                .Where(c => c.Nombre == nombre && c.Apellido == apellido && c.Telefono == telefono && c.Email == email)
                .FirstOrDefaultAsync();
            return newCliente!;
        }

        public async Task<Cliente> UpdateClienteAsync(int idCliente, string nombre, string apellido, int telefono, string email)
        {
            string sql = "UpdateCliente @IdCliente, @Nombre, @Apellido, @Telefono, @Email";
            SqlParameter pamIdCliente = new SqlParameter("@IdCliente", idCliente);
            SqlParameter pamNombre = new SqlParameter("@Nombre", nombre);
            SqlParameter pamApellido = new SqlParameter("@Apellido", apellido);
            SqlParameter pamTelefono = new SqlParameter("@Telefono", telefono);
            SqlParameter pamEmail = new SqlParameter("@Email", email);
            await this.context.Database.ExecuteSqlRawAsync(sql, pamIdCliente, pamNombre, pamApellido, pamTelefono, pamEmail);
            Cliente? updatedCliente = await this.context.Clientes
                .Where(c => c.IdCliente == idCliente)
                .FirstOrDefaultAsync();
            return updatedCliente!;
        }

        public async Task DeleteClienteAsync(int idCliente)
        {
            string sql = "DeleteCliente @IdCliente";
            SqlParameter pamIdCliente = new SqlParameter("@IdCliente", idCliente);
            await this.context.Database.ExecuteSqlRawAsync(sql, pamIdCliente);
        }
    }
}
