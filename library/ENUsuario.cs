using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace library
{
    class ENUsuario
    {
        private string nif;
        private string nombre;
        private int edad;

        /// <summary>
        /// Propiedad pública con campos de respaldo para NIF
        /// </summary>
        public string nifUser
        {
            get
            {
                return nif;
            }
            set
            {
                nif = value;
            }
        }

        /// <summary>
        /// Propiedad pública con campos de respaldo para Nombre
        /// </summary>
        public string nombreUser
        {
            get
            {
                return nombre;
            }
            set
            {
                nombre = value;
            }
        }

        /// <summary>
        /// Propiedad pública con campos de respaldo para Edad
        /// </summary>
        public int edadUser
        {
            get
            {
                return edad;
            }
            set
            {
                edad = value;
            }
        }


        public ENUsuario()
        {

        }
        public ENUsuario(string nif, string nombre, int edad)
        {
            this.nif = nif;
            this.nombre = nombre;
            this.edad = edad;
        }

        /// <summary>
        /// Guarda este usuario en la BD.
        /// Para ello hará uso de los métodos apropiados de​ CADUsuario​. 
        /// </summary>
        /// <returns>
        /// Devuelve false si no se ha podido realizar la operación.
        /// </returns>
        public bool createUsuario()
        {
            CADUsuario cad = new CADUsuario();
        }

        /// <summary>
        /// Recupera el usuario indicado de la BD. 
        /// Para ello hará uso de los métodos apropiados de​CADUsuario​.
        /// </summary>
        /// <returns>
        /// Devuelve false si no se ha podido realizar la operación.True si se ha podido.
        /// </returns>
        public bool readUsuario()
        {

        }

        /// <summary>
        ///  ​Recupera todos los usuarios de la BD y devuelve solo el primer usuario.
        ///  Para ello hará uso de los métodos apropiados de ​CADUsuario​.
        /// </summary>
        /// <returns>
        ///  Devuelve false si no se ha podido realizar la operación.
        /// </returns>
        public bool readFirstUsuario()
        {

        }

        /// <summary>
        /// ​Recupera todos los usuarios de la BD y devuelve solo el usuario siguiente al indicado. 
        /// Para ello hará uso de los métodos apropiados de ​CADUsuario​.
        /// </summary>
        /// <returns>
        /// Devuelve false si no se ha podido realizar la operación. 
        /// </returns>
        public bool readNextUsuario()
        {

        }

        /// <summary>
        /// ​Recupera todos los usuarios de la BD y devuelve solo el usuario anterior al indicado. 
        /// Para ello hará uso de los métodos apropiados de ​CADUsuario​. 
        /// </summary>
        /// <returns>
        /// Devuelve false si no se ha podido realizar la operación.
        /// </returns>
        public bool readPrevUsuario()
        {

        }

        /// <summary>
        /// ​Actualiza este usuario en la BD.
        /// Para ello hará uso de los métodos apropiados de ​CADUsuario​.         
        /// </summary>
        /// <returns>
        /// Devuelve false si no se ha podido realizar la operación. 
        /// </returns>
        public bool updateUsuario()
        {

        }

        /// <summary>
        /// ​Borra este usuario de la BD.
        /// Para ello hará uso de los métodos apropiados de ​CADUsuario​. ///
        /// </summary>
        /// <returns>
        /// Devuelve false si no se ha podido realizar la operación. 
        /// </returns>
        public bool deleteUsuario()
        {

        }
    }
}
