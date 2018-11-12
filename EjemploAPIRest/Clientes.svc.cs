using System.Collections.Generic;
using System.Linq;

namespace EjemploAPIRest
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Clientes" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Clientes.svc or Clientes.svc.cs at the Solution Explorer and start debugging.
    public class Clientes : IClientes
    {
        private List<Cliente> repo;

        public Clientes()
        {
            repo = new List<Cliente>();
            repo.Add(new Cliente() { Id = 1, Mail = "mail1@google.com", Nombre = "Cliente1", Telefono = "1111" });
            repo.Add(new Cliente() { Id = 2, Mail = "mail2@google.com", Nombre = "Cliente2", Telefono = "2222" });
            repo.Add(new Cliente() { Id = 3, Mail = "mail3@google.com", Nombre = "Cliente3", Telefono = "3333" });
            repo.Add(new Cliente() { Id = 4, Mail = "mail4@google.com", Nombre = "Cliente4", Telefono = "4444" });
        }

        public Cliente Create(Cliente cliente)
        {
            if (cliente != null)
            {
                if (cliente.Id == 0)
                {
                    int maxCliente = repo.Max(c => c.Id);
                    cliente.Id = maxCliente + 1;
                }
                repo.Add(cliente);
            }
            return cliente;
        }

        public void Delete(int idCliente)
        {
            if (idCliente > 0)
            {
                Cliente cli = ObtenerCliente(idCliente);
                if (cli != null)
                {
                    repo.Remove(cli);
                }
            }
        }

        public Cliente Get(string idCliente)
        {
            int id = 0;
            int.TryParse(idCliente, out id);
            return ObtenerCliente(id);
        }

        private Cliente ObtenerCliente(int idCliente)
        {
            Cliente cli = repo.Where(c => c.Id == idCliente).Select(c => c).SingleOrDefault();
            return cli;
        }

        public List<Cliente> GetAll()
        {
            return repo;
        }

        public Cliente Update(Cliente cliente)
        {
            Cliente cli = null;
            if (cliente != null)
            {
                cli = ObtenerCliente(cliente.Id);
                if (cli != null)
                {
                    cli.Nombre = cliente.Nombre;
                    cli.Mail = cliente.Mail;
                    cli.Telefono = cliente.Telefono;
                }
            }
            return cli;
        }
    }
}
