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
    public class ENUsuario
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

        /// <summary>
        /// Constructor por defecto de la clase
        /// </summary>
        public ENUsuario()
        {

        }
        
        /// <summary>
        /// Constructor con parámetros de la clase
        /// </summary>
        /// <param name="nif">El nif a registrar</param>
        /// <param name="nombre">Nombre asociado a un nif</param>
        /// <param name="edad">Edad asociada a un nif</param>
        public ENUsuario(string nif, string nombre, int edad)
        {
            this.nif = nif;
            this.nombre = nombre;
            this.edad = edad;
        }


        //--------------------- C

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
            return cad.createUsuario(this);
        }


        //--------------------- R


        /// <summary>
        /// Recupera el usuario indicado de la BD. 
        /// Para ello hará uso de los métodos apropiados de​CADUsuario​.
        /// </summary>
        /// <returns>
        /// Devuelve false si no se ha podido realizar la operación.True si se ha podido.
        /// </returns>
        public bool readUsuario()
        {
            CADUsuario cad = new CADUsuario();
            return cad.readUsuario(this);
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
            CADUsuario cad = new CADUsuario();
            return cad.readFirstUsuario(this);
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
            CADUsuario cad = new CADUsuario();
            return cad.readNextUsuario(this);
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
            CADUsuario cad = new CADUsuario();
            return cad.readPrevUsuario(this);
        }


        //--------------------- U


        /// <summary>
        /// ​Actualiza este usuario en la BD.
        /// Para ello hará uso de los métodos apropiados de ​CADUsuario​.         
        /// </summary>
        /// <returns>
        /// Devuelve false si no se ha podido realizar la operación. 
        /// </returns>
        public bool updateUsuario()
        {
            CADUsuario cad = new CADUsuario();
            return cad.updateUsuario(this);
        }


        //--------------------- D


        /// <summary>
        /// ​Borra este usuario de la BD.
        /// Para ello hará uso de los métodos apropiados de ​CADUsuario​. ///
        /// </summary>
        /// <returns>
        /// Devuelve false si no se ha podido realizar la operación. 
        /// </returns>
        public bool deleteUsuario()
        {
            CADUsuario cad = new CADUsuario();
            return cad.deleteUsuario(this);
        }
    }
}
