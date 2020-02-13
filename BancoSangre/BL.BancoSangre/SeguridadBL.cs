using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BancoSangre
{
    public class SeguridadBL
    {
        public bool Autorizar(string usuario,string password)
        {
            if (usuario == "admin" && password == "321")
            {
                return true;
            }
            else
            {
                if (usuario == "usuario" && password == "789")
                {
                    return true;
                }

            }
            return false;
        }
         
    }
}
