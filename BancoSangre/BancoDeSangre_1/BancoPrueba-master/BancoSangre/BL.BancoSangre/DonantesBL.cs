using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BancoSangre
{
    public class DonantesBL
    {
        Contexto _contexto;
        public BindingList<Donantes> ListaDonantes { get; set; }

        public DonantesBL()
        {
            _contexto = new Contexto();
            ListaDonantes = new BindingList<Donantes>();

        }

        public BindingList<Donantes> ObtenerDonantes()
        {
            _contexto.Donantes.Load();
            ListaDonantes = _contexto.Donantes.Local.ToBindingList();

            return ListaDonantes;
        }
        public Resultado GuardarDonante(Donantes donante)
        {
            var resultado = Validar(donante);
            if (resultado.Exitoso == false)
            {
                return resultado;
            }

            _contexto.SaveChanges();

            resultado.Exitoso = true;
            return resultado;
        }

        public void AgregarDonante()
        {
            var nuevoDonante = new Donantes();
            ListaDonantes.Add(nuevoDonante);
        }

        public bool EliminarDonante(int id)
        {
            foreach (var donante in ListaDonantes)
            {
                if (donante.Id == id)
                {
                    ListaDonantes.Remove(donante);
                    _contexto.SaveChanges();
                    return true;
                }
            }

            return false;
        }

        private Resultado Validar(Donantes donante)
        {
            var resultado = new Resultado();
            resultado.Exitoso = true;

            if (string.IsNullOrEmpty(donante.Nombre) == true)
            {
                resultado.Mensaje = "Ingrese el Nombre del Donante";
                resultado.Exitoso = false;
            }

            else
            {
                if (string.IsNullOrEmpty(donante.Identidad) == true)
                {
                    resultado.Mensaje = "Ingrese un número de identidad válido";
                    resultado.Exitoso = false;
                }
                else
                {
                    if (string.IsNullOrEmpty(donante.Telefono) == true)
                    {
                        resultado.Mensaje = "Ingrese un número de teléfono válido";
                        resultado.Exitoso = false;
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(donante.Direccion) == true)
                        {
                            resultado.Mensaje = "Ingrese una dirección válida";
                            resultado.Exitoso = false;
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(donante.Fecha) == true)
                            {
                                resultado.Mensaje = "Ingrese una fecha válida";
                                resultado.Exitoso = false;
                            }
                            else
                            {
                                if (donante.TipoId == 0)
                                {
                                    resultado.Mensaje = "Seleccione un tipo";
                                    resultado.Exitoso = false;
                                }

                            }
                        }
                    }
                }
      
            }

            
            

            return resultado;
        }

    }

    public class Donantes
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Identidad { get; set; }
        public string Fecha { get; set; }
        public string Telefono { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        public int TipoId { get; set; }
        public Tipo Tipo { get; set; }
        public byte[] foto { get; set; }      
        public string Direccion { get; set; }
    }
    public class Resultado
    {
        public bool Exitoso { get; set; }
        public string Mensaje { get; set; }
    }

}
