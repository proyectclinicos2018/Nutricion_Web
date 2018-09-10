using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Falp.Entidades;
using Falp.Capa_Datos;

namespace Falp.Capa_Negocios
{
    public class UsuariosNE
    {
        string res = "";
        UsuariosDA var = new UsuariosDA();
        Usuarios ped = new Usuarios();


        public Usuarios Validar_usuario(string usuario, string password)
        {
            return var.Validar_usuario(usuario, password);
        }



    }
}
