using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
       

namespace Datos
{
    public class ConexionSQL
    {
      
            MySqlConnection conexion = new MySqlConnection("Server=localhost; Database=TuGestor; Uid=root; Pwd=1234");
        

        public int consultaLogin(string Usuario, string Contraseña)
        {
         
            int count;

            conexion.Open();

            string Query = "Select Count(*) From Usuarios where Usuario='" + Usuario + "'" + "and Contraseña='" + Contraseña + "'";

            MySqlCommand cmd = new MySqlCommand(Query, conexion);

            count = Convert.ToInt32(cmd.ExecuteScalar());

            conexion.Close();

            return count;
           
        }

        public int InsertarUsuario(string nombre, string dni, string direccion, string departamento, string telefono,string nick, string password)
        {
            int flag = 0;

            conexion.Open();

            MySqlCommand cmd = new MySqlCommand("insert into Usuarios values('" + nick + "','" +password+ "','" + nombre + "','" + dni+ "','"+direccion+ "','"
                + departamento+ "','" + telefono +"')", conexion);

            try
            {
                flag = cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message);
            }
            finally
            {
                conexion.Close();
            }
            return flag;

        }



        public int EliminarUsuario(string password, string dni)
        {
            int flag = 0;

            conexion.Open();

            MySqlCommand cmd = new MySqlCommand("Delete from Usuarios where Dni='" + dni + "' AND Contraseña='" + password + "'", conexion);

            flag = cmd.ExecuteNonQuery();

            conexion.Close();

            return flag;
        }

        public DataTable ConsultarTablaUsuarios()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select Dni from Usuarios", conexion);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(cmd);
                DataTable tablaUsuarios = new DataTable();
                mySqlDataAdapter.Fill(tablaUsuarios);

                return tablaUsuarios;
            }catch(Exception e)
            {
                MySqlCommand cmd = new MySqlCommand("select Dni from Usuarios", conexion);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(cmd);
                DataTable tablaUsuarios = new DataTable();
                mySqlDataAdapter.Fill(tablaUsuarios);

                return tablaUsuarios;
            }
            
        }


        public DataTable ConsultarTablaClientes()
        {

           MySqlCommand cmd = new MySqlCommand("select * from Clientes", conexion);
           MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(cmd);
           DataTable tablaClientes = new DataTable();
           mySqlDataAdapter.Fill(tablaClientes);

           return tablaClientes;

            
        }

        public int Insertar(string nombre, string dni, string direccion, string departamento, string telefono)
        {
            int flag = 0;

            conexion.Open();

            MySqlCommand cmd = new MySqlCommand("insert into Clientes values('" + nombre + "','" + dni + "','" + direccion
                + "','" + departamento + "','" + telefono + "')",conexion);
             //EXCEPCION Duplicate entry,dni.PrimaryKey

            try
            {
                flag = cmd.ExecuteNonQuery();

            } catch (Exception e)
            {
                //Console.WriteLine(e.Message);
            }
            finally
            {
                conexion.Close();
            }
            return flag;
            
        }

       

        public int Eliminar(string dni)
        {
            int flag = 0;

            conexion.Open();

            MySqlCommand cmd = new MySqlCommand("Delete from Clientes where dni='" + dni + "'" , conexion);

            flag = cmd.ExecuteNonQuery();

            conexion.Close();

            return flag;
        }

      /*  public string comparaDni(string dni)
        {
            string resultado;

            conexion.Open();      

            MySqlCommand cmd = new MySqlCommand("Select Dni From Usuar", conexion);
            MySqlDataReader reg = cmd.ExecuteReader();

            if (reg.Read())
            {

                resultado = reg["Nombre"].ToString();
            }
            else
            {

                resultado = "Null";

            }

            conexion.Close();


            return resultado;
        }*/

        public DataTable ConsultarTablaInventario()
        {

            MySqlCommand cmd = new MySqlCommand("select * from Inventario", conexion);
            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(cmd);
            DataTable tablaInventario = new DataTable();
            mySqlDataAdapter.Fill(tablaInventario);

            return tablaInventario;


        }

        public int InsertarProducto(string codigo, string nombre, string stock, string pCosto, string pVenta)
        {
            int flag = 0;

            conexion.Open();

            MySqlCommand cmd = new MySqlCommand("insert into Inventario values('" + codigo + "','" + nombre + "','" + stock + "','"
                + pCosto + "','" + pVenta + "')", conexion);

            //EXCEPCION Duplicate entry,Codigo.PrimaryKey

            try
            {
                flag = cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message);
            }
            finally
            {
                conexion.Close();
            }
            return flag;
        }



        public int EliminarProducto(string codigo)
        {
            int flag = 0;

            conexion.Open();

            MySqlCommand cmd = new MySqlCommand("Delete from Inventario where codigo='" + codigo + "'", conexion);

            flag = cmd.ExecuteNonQuery();

            conexion.Close();

            return flag;
        }

        public DataTable ConsultarTablaVentas()
        {

            MySqlCommand cmd = new MySqlCommand("select * from Inventario", conexion);
            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(cmd);
            DataTable tablaInventario = new DataTable();
            mySqlDataAdapter.Fill(tablaInventario);

            return tablaInventario;


        }

        public int TraerStock(string codigo)
        {
            
            int cant = 0;

            conexion.Open();

            string query = "Select Stock from Inventario where Codigo='" + codigo + "'";

            MySqlCommand cmd = new MySqlCommand(query, conexion);
            MySqlDataReader reg = cmd.ExecuteReader();

            if (reg.Read())
            {

                cant = Convert.ToInt32(reg["Stock"]);
            }


            conexion.Close();

            return cant;

            
        }

        public int ActualizarStock(string codigo, int stocknuevo)
        {
            int flag;

            conexion.Open();

            MySqlCommand cmd = new MySqlCommand("Update Inventario set Stock='" + stocknuevo + "'where Codigo='" + codigo + "'", conexion);

            flag = cmd.ExecuteNonQuery();

            conexion.Close();

            return flag;
        }

        public double consultaVenta(string codigo)
        {
            double res=0;

            conexion.Open();

            string query= "select * from Inventario where Codigo='"+codigo+"'";

            MySqlCommand cmd = new MySqlCommand(query, conexion);
            MySqlDataReader reg = cmd.ExecuteReader();

            if (reg.Read())
            {
                
                res = Convert.ToDouble(reg["Precio Venta"]);
            }
           

            conexion.Close();

            return res;



        }   

        public string consultaProducto(string codigo)
        {
            string res;
            string query = "select Nombre from Inventario where Codigo='" + codigo + "'";

           
            conexion.Open();


            MySqlCommand cmd = new MySqlCommand(query, conexion);
            MySqlDataReader reg = cmd.ExecuteReader();

                if (reg.Read())
                {
                    
                    res = reg["Nombre"].ToString();
                }
                else
                {
                    
                    res= "Null";

                }

            conexion.Close();

            return res;


        }

        public DataTable consultaTablaEnvios()
        {
            MySqlCommand cmd = new MySqlCommand("select * from Envios", conexion);
            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(cmd);
            DataTable tablaEnvios = new DataTable();
            mySqlDataAdapter.Fill(tablaEnvios);

            return tablaEnvios;
        }

        public int InsertarDatosEnvio(double total, string fecha, string envio, string departamento)
        {
            int flag = 0;

            conexion.Open();

            MySqlCommand cmd = new MySqlCommand("insert into Envios values('" + total + "','" + fecha + "','" + envio + "','" 
                + departamento + "')", conexion);

            flag = cmd.ExecuteNonQuery();

            conexion.Close();

            return flag;
        }

        public DataTable ConsultaOrdenadaDepartamento(string departamento)
        {

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM envios WHERE Departamento='" + departamento+"'",conexion);
            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(cmd);
            DataTable tablaEnviosOrd = new DataTable();
            mySqlDataAdapter.Fill(tablaEnviosOrd);

            return tablaEnviosOrd;
  
        }

        public DataTable ConsultaOrdenadaEnvio(string envio)
        {

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM envios WHERE Envio='" + envio + "'", conexion);
            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(cmd);
            DataTable tablaEnviosOrd = new DataTable();
            mySqlDataAdapter.Fill(tablaEnviosOrd);

            return tablaEnviosOrd;

        }
    }   
}
