﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocio
{
    public class Entrega
    {

        //Atributos
        ConexionSQL cn = new ConexionSQL();
        public DateTime fecha;
        public string departamento;
        public string aDomicilio;



        //Métodos
        public Entrega()
        {

        }

        public Entrega(DateTime fecha, string departamento, string aDomicilio)
        {
            this.fecha = fecha;
            this.departamento = departamento;
            this.aDomicilio = aDomicilio;
            
        }

        public DataTable ConsultaDTEnvios()
        {
            return cn.consultaTablaEnvios();
        }

        public int InsertarDatosEnvio(double total, string fecha, string envio, string departamento)
        {
            return cn.InsertarDatosEnvio(total, fecha, envio, departamento);
        }

        public DataTable ConsultaOrdenadaDepartamento(string departamento)
        {
            return cn.ConsultaOrdenadaDepartamento(departamento);
        }

        public DataTable ConsultaOrdenadaEnvio(string envio)
        {
            return cn.ConsultaOrdenadaEnvio(envio);
        }
    }
}
