using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BL.BancoSangre.Contexto;

namespace BL.BancoSangre
{
    public class DatosdeInicio: CreateDatabaseIfNotExists<Contexto>
    {
        protected override void Seed(Contexto contexto)
        {
            var usuarioAdmin = new Usuario();
            usuarioAdmin.Nombre = "admin";
            usuarioAdmin.password = "123";

            contexto.Usuarios.Add(usuarioAdmin);

            var categoria1 = new Categoria();
            categoria1.Descripcion = "Primer Vez";
            contexto.Categorias.Add(categoria1);

            var categoria2 = new Categoria();
            categoria2.Descripcion = "Frecuente";
            contexto.Categorias.Add(categoria2);

            var categoria3 = new Categoria();
            categoria2.Descripcion = "Muy Frecuente";
            contexto.Categorias.Add(categoria3);

            var tipo1 = new Tipo();
            tipo1.Descripcion = "Tipo O+";
            contexto.Tipos.Add(tipo1);

            var tipo2 = new Tipo();
            tipo2.Descripcion = "Tipo O-";
            contexto.Tipos.Add(tipo2);

            var tipo3 = new Tipo();
            tipo3.Descripcion = "Tipo A-";
            contexto.Tipos.Add(tipo3);

            var tipo4 = new Tipo();
            tipo4.Descripcion = "Tipo A+";
            contexto.Tipos.Add(tipo4);

            var tipo5 = new Tipo();
            tipo5.Descripcion = "Tipo B+";
            contexto.Tipos.Add(tipo5);

            var tipo6 = new Tipo();
            tipo6.Descripcion = "Tipo B-";
            contexto.Tipos.Add(tipo6);

            var tipo7 = new Tipo();
            tipo7.Descripcion = "Tipo AB+";
            contexto.Tipos.Add(tipo7);

            var tipo8 = new Tipo();
            tipo8.Descripcion = "Tipo AB-";
            contexto.Tipos.Add(tipo8);



            base.Seed(contexto);
        }
    }
}
