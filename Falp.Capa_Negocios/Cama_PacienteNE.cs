using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Falp.Entidades;
using Falp.Capa_Datos;

namespace Falp.Capa_Negocios
{
    public class Cama_PacienteNE
    {

        string res = "";
        Cama_Pacientes cam_pac = new Cama_Pacientes();
        Cama_PacienteDA var = new Cama_PacienteDA();

        public List<Cama_Pacientes> ListadoCamaPacientes(int tipo_doc, string rut, int cod_servicio, int cod_turno, int cod_estado, int cod_tipo_comida,string nombre,string ficha, string fecha)
        {
            return var.ListadoCamaPacientes( tipo_doc, rut, cod_servicio,  cod_turno, cod_estado, cod_tipo_comida,nombre,ficha,fecha);
        }

        public List<Cama_Pacientes> ListadoCamaPacientes2(int cod_paciente, string fecha)
        {
            return var.ListadoCamaPacientes2( cod_paciente,  fecha);
        }

        public List<Cama_Pacientes> Listadoestadistico()
        {
            return var.Listadoestadistico();
        }

        

        public string Liberar_cama(string cod_cama,string cod_paciente)
        {
            return var.Liberar_cama(cod_cama,cod_paciente);
        }

        public string Verificar_paciente(string cod_cama, string cod_paciente,string cod_servicio)
        {
            return var.Verificar_paciente(cod_cama, cod_paciente,cod_servicio);
        }

        public string Actualizar_paciente()
        {
            return var.Actualizar_paciente();
        }
    }
}
