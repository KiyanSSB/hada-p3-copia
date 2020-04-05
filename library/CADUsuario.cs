using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Configuration;

namespace library
{
    public class CADUsuario
    {   
        /// <summary>
        /// Contiene la cadena de conexión a la base de datos (Configurada en Web.config)
        /// </summary>
        private string constring;

        /// <summary>
        /// Inicializa la cadena de conexión de la BD
        /// </summary>
        public CADUsuario()
        {
            constring = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
        }

        //--------------------- C

        /// <summary>
        /// Crea un nuevo usuario en la BD con los datos del usuario representado por el parámetro en
        /// </summary>
        /// <param name="en">
        /// Representa el EN del usuario, se modifican los valores por parametro de manera predeterminada
        /// </param>
        /// <returns>
        /// Devuelve false si se ha producido algún eror, true en caso contrario;
        /// </returns>
        public bool createUsuario(ENUsuario en)
        {
            //Creamos la conexión a la base de datos
            SqlConnection c = new SqlConnection(constring);
            try
            {   
                //Abrimos la conexión
                c.Open();
                //Creamos el comando accediendo a los valores de 
                SqlCommand command = new SqlCommand("Insert into Usuarios (nombre,nif,edad) VALUES ('" + en.nombreUser + "' , '" + en.nifUser + "','" + en.edadUser + "')", c);
                command.ExecuteNonQuery();
                //Cerramos la conexión con la base de datos
                c.Close();
                return true;
            }
            catch (SqlException e)
            {
                Console.WriteLine("User operation has failed. Error {0} " ,e.Message);
                c.Close();
                return false;
            }
        }

        //--------------------- R

        /// <summary>
        /// Devuelve solo el usuairo indicado leído de la DB
        /// </summary>
        /// <param name="en">
        /// Representa el usuario introducido
        /// </param>
        /// <returns>
        /// False si se produce un error
        /// </returns>
        public bool readUsuario(ENUsuario en)
        {
            SqlConnection c = new SqlConnection(constring);
            try
            {
                c.Open();
                SqlCommand command = new SqlCommand("Select * from Usuarios where nif = '" + en.nifUser + "'", c);
                SqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    en.nifUser = dr["nif"].ToString();
                    en.nombreUser = dr["nombre"].ToString();
                    en.edadUser = int.Parse(dr["edad"].ToString());
                }
                dr.Close();

                //Si NO encontramos un usuario con dicho nombre, devolvemos false
                if(en.nombreUser == "" || en.edadUser == 0)
                {
                    c.Close();
                    return false;
                }
                c.Close();
                return true;
            }
            catch (SqlException e)
            {
                Console.WriteLine("User operation has failed. Error {0} ", e.Message);
                c.Close();
                return false;
            }
        }

        /// <summary>
        /// Devuelve solo el primer usuario de la BD
        /// </summary>
        /// <param name="en">
        /// Representa el usuario introducido
        /// </param>
        /// <returns>False si se produce un error</returns>
        public bool readFirstUsuario(ENUsuario en)
        {
            SqlConnection c = new SqlConnection(constring);
            try
            {
                c.Open();
                SqlCommand command = new SqlCommand("Select * from Usuarios", c);
                SqlDataReader dr = command.ExecuteReader();

                //Leemos la primera linea y la almacenamos en EN
                if (dr.HasRows) {
                    if (dr.Read())
                    {
                        en.nifUser = dr["nif"].ToString();
                        en.nombreUser = dr["nombre"].ToString();
                        en.edadUser = int.Parse(dr["edad"].ToString());
                        dr.Close();
                        c.Close();
                        return true;
                    }
                    return false;
                }
                else
                {
                    dr.Close();
                    c.Close();
                    return false;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("User operation has failed. Error {0} ", e.Message);
                c.Close();
                return false;
            }
        }

        /// <summary>
        /// Devuelve solo el usuario siguiente al indicado
        /// </summary>
        /// <param name="en">
        /// Representa el usuario introducido
        /// </param>
        /// <returns>False si se produce un error</returns>
        public bool readNextUsuario(ENUsuario en)
        {
            SqlConnection c = new SqlConnection(constring);
            try
            {
                c.Open();
                SqlCommand command = new SqlCommand("Select * from Usuarios", c);
                SqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    if (dr["nif"].ToString() == en.nifUser)
                    {
                        if (dr.Read())
                        {
                            en.nifUser = dr["nif"].ToString();
                            en.edadUser = int.Parse(dr["edad"].ToString());
                            en.nombreUser = dr["nombre"].ToString();
                            dr.Close();
                            c.Close();
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                return false;
            }catch(SqlException e)
            {
                Console.WriteLine("User operation has failed. Error {0} ", e.Message);
                c.Close();
                return false;
            }
        }

        /// <summary>
        /// Devuelve solo el usuario anterior al indicado
        /// </summary>
        /// <param name="en">
        /// Representa el usuario introducido
        /// </param>
        /// <returns>False si se produce un error</returns>
        public bool readPrevUsuario(ENUsuario en)
        {
            SqlConnection c = new SqlConnection(constring);
            string nif;
            bool primero = false;
            bool encontrado = false;
            ENUsuario aux = new ENUsuario();
            
            try
            {
             
                c.Open();
                SqlCommand command = new SqlCommand("Select * from Usuarios", c);
                SqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    //Comprobamos si el nif es igual al que buscamos
                    nif = dr["nif"].ToString();
                    if(nif == en.nifUser)
                    {
                        //Si primero es false en la primera iteración devuelve falso puesto que no hay un elemento antes que el primero
                        if(!primero)
                        {
                            c.Close();
                            dr.Close();
                            return false;
                        }
                        //Colocamos encontrado a true puesto que es nuestro nif y guardamos los valores auxiliares en el original para devolverlo
                        encontrado = true;
                        en.nifUser = aux.nifUser;
                        en.nombreUser = aux.nombreUser;
                        en.edadUser = aux.edadUser;
                        c.Close();
                        dr.Close();
                        return true;
                    }
                    else
                    {
                        aux.nifUser = dr["nif"].ToString();
                        aux.nombreUser = dr["nombre"].ToString();
                        aux.edadUser = int.Parse(dr["edad"].ToString());
                        primero = true;
                    }
                }

                c.Close();
                dr.Close();

                //Si no encontramos el NIF , devolvemos falso
                if (!encontrado)
                {
                    return false;
                }

                //Para controlar el primer elemento, se puede controlar de mejor manera, pero es mucho más enrevesado que comprobar si se devuelven datos vacíos para ese caso
                if (string.IsNullOrWhiteSpace(en.nombreUser) || (en.edadUser == 0))
                {
                    dr.Close();
                    c.Close();
                    return false;
                }
                return true;

            }catch (SqlException e)
            {
                Console.WriteLine("User operation has failed. Error {0} ", e.Message);
                c.Close();
                return false;
            }
        }

        //--------------------- U

        /// <summary>
        /// Actualiza los datos de un usuario en la BD con los datos del usuario representado por el parámetro
        /// </summary>
        /// <param name="en">
        /// Representa el usuario introducido
        /// </param>
        /// <returns>False si se produce un error</returns>
        public bool updateUsuario(ENUsuario en)
        {
            SqlConnection c = new SqlConnection(constring);
            try
            {
                c.Open();
                SqlCommand command = new SqlCommand("Update Usuarios set nombre = '" + en.nombreUser + "', edad = '" + en.edadUser + "' where nif = '" + en.nifUser + "'", c);
                command.ExecuteNonQuery();
                c.Close();
                return true;
            }
            catch (SqlException e)
            {
                Console.WriteLine("User operation has failed. Error {0} ", e.Message);
                c.Close();
                return false;
            }
        }

        //--------------------- D

        /// <summary>
        /// Borra el usuario representado por "en" de la DB
        /// </summary>
        /// <param name="en">
        /// Representa el usuario introducido
        /// </param>
        /// <returns>False si se produce un error</returns>
        public bool deleteUsuario(ENUsuario en)
        {
            SqlConnection c = new SqlConnection(constring);
            c.Open();
            try
            {
                SqlCommand command2 = new SqlCommand("Delete from Usuarios where nif = '" + en.nifUser + "'", c);
                    command2.ExecuteNonQuery();
                    c.Close();
                    return true;
            }
            catch (SqlException e)
            {
                Console.WriteLine("User operation has failed. Error {0} ", e.Message);
                c.Close();
                return false;
            }
        }
    }
}
