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

        }

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

        }

        /// <summary>
        /// Actualiza los datos de un usuario en la BD con los datos del usuario representado por el parámetro
        /// </summary>
        /// <param name="en">
        /// Representa el usuario introducido
        /// </param>
        /// <returns>False si se produce un error</returns>
        public bool updateUsuario(ENUsuario en)
        {

        }

        /// <summary>
        /// Borra el usuario representado por "en" de la DB
        /// </summary>
        /// <param name="en">
        /// Representa el usuario introducido
        /// </param>
        /// <returns>False si se produce un error</returns>
        public bool deleteUsuario(ENUsuario en)
        {

        }
    }
}
