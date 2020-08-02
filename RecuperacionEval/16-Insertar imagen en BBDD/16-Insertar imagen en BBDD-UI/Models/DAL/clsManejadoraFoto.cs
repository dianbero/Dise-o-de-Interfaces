using _16_Insertar_imagen_en_BBDD_UI.Models.Ent;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_Insertar_imagen_en_BBDD_UI.Models.DAL
{
    public class clsManejadoraFoto
    {

        /// <summary>
        /// Función que añade una persona a la tabla correspondiente.
        /// </summary>
        /// <param name="persona">Recibe un objeto de la clase persona.</param>
        /// <returns>Devuelve un entero que corresponde a las filas afectadas.</returns>
        public int insertarImagenDAL(clsMyConnection pConexion, clsImagen pImagen)
        {

            int resultado = 0;
            SqlConnection connection = new SqlConnection();

            
          

            SqlCommand miComando = new SqlCommand();

            //Añadimos los datos al comando
                        
            miComando.Parameters.Add("@arrayFoto", System.Data.SqlDbType.Image).Value = pImagen.arrayFoto;
            miComando.Parameters.Add("@valorPK", System.Data.SqlDbType.Int).Value = pImagen.valorPK;

            try
            {
                connection = pConexion.getConnection();
                
                
                miComando.CommandText = "UPDATE " + pImagen.nombreTabla +" SET "+ pImagen.nombreCampoImagen + " =@arrayFoto WHERE " + pImagen.nombrePK + " =@valorPK";
                miComando.Connection = connection;
                resultado = miComando.ExecuteNonQuery();


            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                pConexion.closeConnection(ref connection);
            }
            return resultado;
        }
    }
}
