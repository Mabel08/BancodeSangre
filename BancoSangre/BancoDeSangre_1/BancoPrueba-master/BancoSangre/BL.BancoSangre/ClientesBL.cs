using BL.BancoSangre;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BancoSangre
{
    public class ClientesBL
    {
        Contexto _contexto;
        public BindingList<Cliente> ListadeClientes { get; set; }
        public ClientesBL()
        {
            _contexto = new Contexto();
            ListadeClientes = new BindingList<Cliente>();
        }

        public BindingList<Cliente> ObtenerClientes()
        {
            _contexto.Clientes.Load();
            ListadeClientes = _contexto.Clientes.Local.ToBindingList();
            return ListadeClientes;
        }

        public void CancelarCambios()
        {
            foreach (var item in _contexto.ChangeTracker.Entries())
            {
                item.State = EntityState.Unchanged;
                item.Reload();
            }
        }

        public Res GuardarCliente(Cliente cliente)
        {
            var res = Validar(cliente);
            if (res.Exitoso ==false)
            {
                return res;
            }
            _contexto.SaveChanges();
            res.Exitoso = true;
            return res;
        }



        public void AgregarClientes()
        {
            var nuevoCliente = new Cliente();
            ListadeClientes.Add(nuevoCliente);

        }


        public bool EliminarCliente(int id)
        {
            foreach (var item in ListadeClientes)
            {
                if (item.Id==id)
                {
                    ListadeClientes.Remove(item);
                    _contexto.SaveChanges();
                    return true;
                }
            }
            return false;
        }
        private Res Validar(Cliente cliente)
        {
            var res = new Res();
            res.Exitoso = true;
            if (string.IsNullOrEmpty(cliente.Nombre) == true) 
            {
                res.Mensaje = "Ingrese un nombre";
                res.Exitoso = false;
            }


            return res;
        }
    }

    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
    public class Res
    {
        public bool Exitoso { get; set; }
        public string Mensaje { get; set; }
    }
}
      
        
    

