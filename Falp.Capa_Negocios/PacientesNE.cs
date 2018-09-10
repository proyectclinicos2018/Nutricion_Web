using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Falp.Entidades;
using Falp.Capa_Datos;

namespace Falp.Capa_Negocios
{
    public class PacientesNE
    {
        string res = "";
        PacientesDA var = new PacientesDA();
        Pacientes pac = new Pacientes();
        public Pacientes Cargar_paciente(int tipo,string filtro)
        {
            return var.Cargar_paciente(tipo,filtro);
        }

        public Pacientes Cargar_paciente(string cod_paciente)
        {
            return var.Cargar_paciente(cod_paciente);
        }

        public string Registrar_Paciente(string ficha, string folio, string tipo_doc, string num_doc, string nombres)
        {

            pac._Ficha = Convert.ToInt32(ficha);
            pac._Folio = Convert.ToInt32(folio);
            pac._Tipo_doc = tipo_doc;
            pac._Num_doc = num_doc;
            pac._Nombres = nombres;

            return var.Registrar_Paciente(pac);
        }

    }
}
