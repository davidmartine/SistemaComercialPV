using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Aplicacion_Comercial.Logica;

namespace Aplicacion_Comercial.Datos
{
    public class CADLicencias
    {

        private DateTime FechaFinal;
        private DateTime FechaInical;
        private string Estado;
        private string SerialPCLicencia;
        private DateTime FechaSistema = DateTime.Now;
        private string SerialPC;

        public void Validar_licencias(ref string Resultado, ref string ResultFechaFinal)
        {

            try
            {
                Logica.BasesPCProgram.obtener_serial_pc(ref SerialPC);
                DataTable dt = new DataTable();
                Conexiones.CADMaestra.abrir();
                SqlDataAdapter data = new SqlDataAdapter("SELECT * FROM Marca", Conexiones.CADMaestra.conectar);
                data.Fill(dt);
                Conexiones.CADMaestra.cerrar();
                foreach (DataRow row in dt.Rows)
                {
                    Estado = Logica.BasesPCProgram.Desencriptar(row["E"].ToString());
                    FechaFinal = Convert.ToDateTime(Logica.BasesPCProgram.Desencriptar(row["F"].ToString()));
                    FechaInical = Convert.ToDateTime(Logica.BasesPCProgram.Desencriptar(row["FA"].ToString())).Date;
                    SerialPCLicencia = row["S"].ToString();

                }
                if (Estado == "VENCIDA")
                {
                    Resultado = "VENCIDA";
                }
                else
                {
                    if (FechaFinal >= FechaSistema)
                    {
                        if (FechaInical <= FechaSistema)
                        {
                            if (SerialPCLicencia == SerialPC)
                            {
                                if (Estado == "VENCIDA")
                                {
                                    Resultado = Estado;
                                    ResultFechaFinal = FechaFinal.ToString("dd/MM/yyyy");


                                }

                            }
                        }
                        else
                        {
                            Resultado = "VENCIDA";
                        }
                    }
                    else
                    {
                        Resultado = "VENCIDA";
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message +" " + ex.StackTrace);
            }
        }

        public static void Editar_marcas_vencidas()
        {
            try
            {
                Conexiones.CADMaestra.abrir();
                SqlCommand cmd = new SqlCommand("Editar_Marcas_Vencidas", Conexiones.CADMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@E",Logica.BasesPCProgram.Encriptar("VENCIDA"));
                cmd.ExecuteNonQuery();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                
               
            }
            finally
            {
                Conexiones.CADMaestra.cerrar();
            }
        }
        
    }
}
