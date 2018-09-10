using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Falp.Entidades
{
   public  class Usuarios
    {
        protected string usuario;
        protected string password;


        public string _Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        public string _Password
        {
            get { return password; }
            set { password = value; }
        }


         public Usuarios()
        { }

         public Usuarios(string usuario,
                          string password)
         {
             this._Password = password;
             this._Usuario = usuario;

         }
    }
}
