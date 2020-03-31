using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using library; //Añadimos la librería para poder utilizar los EN y CAD correspondientes

namespace usuWeb
{
    public partial class Formulario_web1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //-----------------------------------------    FUNCIONES AUXILIARES    --------------------------------------------------------------------

        /// <summary>
        /// Función que printea el borrado de un usuario
        /// </summary>
        protected void print_Deleted()
        {
            InformationLbl.Text = "El usuario con nif: " + TextBoxNIF.Text + " ha sido borrado con éxito"; 
        }
        
        /// <summary>
        /// Función que printea resultado de la creación de un usuario
        /// </summary>
        protected void print_Created()
        {
            InformationLbl.Text = "Usuario Creado con éxito";
        }
        
        /// <summary>
        /// Función que printea la salida de valores para leer 
        /// </summary>
        /// <param name="en">En que contiene los valores a mostrar</param>
        protected void print_Valores(ENUsuario en)
        {
            InformationLbl.Text = "Usuario encontrado, NIF: " + en.nifUser + "\n" + "Nombre: " + en.nombreUser + " Edad: " + en.edadUser + "\n";
        }
        
        /// <summary>
        /// Función que printea la actualización de un usuario en la tabla 
        /// </summary>
        /// <param name="en"></param>
        protected void print_Updated(ENUsuario en)
        {
            InformationLbl.Text = "Usuario actualizado, NIF: " + en.nifUser + " Nombre: " + en.nombreUser + " Edad: " + en.edadUser + "\n";
        }
        
        /// <summary>
        /// Función que printea error al no encontrar el nif especificado
        /// </summary>
        protected void printError_Nif_NotFound()
        {
            InformationLbl.Text = "ERROR, no se ha encontrado ningún usuario con el NIF introducido asignado";
        }
        
        /// <summary>
        /// Función que printea error al ser el primer resultado de la tabla y no tener valor anterior
        /// </summary>
        protected void printError_First_in_Table()
        {
            InformationLbl.Text = "ERROR, el valor es el primero en la lista, luego no tiene un valor anterior o el nif no se encuentra en la base de datos, utilize la función leer para comprobar que el ID introducido se encuentra registrado";
        }

        /// <summary>
        /// Función que printea error al encontrarse en ultima posición o no encontrar el nif , usada en leer siguiente
        /// </summary>
        protected void printError_Last_in_Table() {
            InformationLbl.Text = "ERROR, el valor es el último en la lista, luego no tiene un valor siguiente o el nif no se encuentra en la base de datos, utilize la función leer para comprobar que el ID introducido se encuentra registrado";
        }

        /// <summary>
        /// Función que printea salida si un nif ya está en la tabla
        /// </summary>
        protected void printError_Nif_Already_In_Table()
        {
            InformationLbl.Text = "ERROR, el NIF ya se encuentra en la base registrado";
        }
        
        /// <summary>
        /// Función que printea si alguno de los valores es incorrecto
        /// </summary>
        protected void printError_Unfit_Data()
        {
            InformationLbl.Text = "ERROR, alguno de los valores introducidos no es correcto o está vacío";
        }
        
        /// <summary>
        /// Función que muestra un mensaje cuando no se encuentra ningún valor en la tabla
        /// </summary>
        protected void printError_No_Data()
        {
            InformationLbl.Text = "ERROR, No se ha encontrado ningún valor en la tabla";
        }
       
        
        //-----------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Función que muestra los valores asociados a un NIF en la tabla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLeer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBoxNIF.Text))
            {
                printError_Unfit_Data();
                return;
            }

            ENUsuario en = new ENUsuario(TextBoxNIF.Text,"",0); //Creamos un ENUsuario para almacenar el valor
            if (en.readUsuario())
            {
                print_Valores(en);
            }
            else
            {
                printError_Nif_NotFound();
            }
        }

        /// <summary>
        /// Función que muestra el primer valor en la tabla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLeerPrimero_Click(object sender, EventArgs e)
        {
            ENUsuario en = new ENUsuario();
            if (en.readFirstUsuario())
            {
                print_Valores(en);
            }
            else
            {
                printError_No_Data();
            }
        }

        /// <summary>
        /// Función que muestra los valores de la fila anterior al nif introducido
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLeerAnterior_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBoxNIF.Text))
            {
                printError_Unfit_Data();
                return;
            }
            ENUsuario en = new ENUsuario(TextBoxNIF.Text, "", 0);
            if (en.readPrevUsuario())
            {
                print_Valores(en);
            }
            else
            {
                printError_First_in_Table();
            }
        }

        /// <summary>
        /// Función que muestra los valores de la fila siguiente al nif introducido
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLeerSiguiente_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBoxNIF.Text))
            {
                printError_Unfit_Data();
                return;
            }
            ENUsuario en = new ENUsuario(TextBoxNIF.Text, "", 0);
            if (en.readNextUsuario())
            {
                print_Valores(en);
            }
            else
            {
                printError_Last_in_Table();
            }
        }

        
        //------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Función que inserta un nif en la tabla tras pulsar el botón crear
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCrear_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBoxNIF.Text) || string.IsNullOrWhiteSpace(TextBoxNombre.Text) || string.IsNullOrWhiteSpace(TextBoxEdad.Text))
            {
                printError_Unfit_Data();
                return;
            }
                    
            ENUsuario en = new ENUsuario(TextBoxNIF.Text, TextBoxNombre.Text, int.Parse(TextBoxEdad.Text));

            if (en.createUsuario())
            {
                print_Created();
            }
            else
            {
                printError_Nif_Already_In_Table();
            }
        }

        /// <summary>
        /// Función que actualiza los valores asociados al nif introducido trás pulsar el botón actualizar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            //Error nombre nif o edad
            if (string.IsNullOrWhiteSpace(TextBoxNIF.Text) || string.IsNullOrWhiteSpace(TextBoxNombre.Text) || string.IsNullOrWhiteSpace(TextBoxEdad.Text))
            {
                printError_Unfit_Data();
                return;
            }

            ENUsuario en = new ENUsuario(TextBoxNIF.Text, TextBoxNombre.Text, int.Parse(TextBoxEdad.Text));
            en.updateUsuario();
            print_Updated(en);
        }
    
        /// <summary>
        /// Función que borra de la tabla una fila que coincida con el nif introducido
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBoxNIF.Text))
            {
                printError_Unfit_Data();
                return;
            }
            
            ENUsuario en = new ENUsuario(TextBoxNIF.Text,"",0);
         
            if (en.deleteUsuario())
            {
                print_Deleted();
            }
            else
            {
                printError_Nif_NotFound();
            }
        }
    }
}