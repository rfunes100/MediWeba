using MediWeb.Datos;
using MediWeb.Models;
using System.Data;
using System.Data.SqlClient;

namespace MediWeb.Consultas
{
    public class CategoriaConsulta
    {


        public List<CategoriaModel> Listar()
        {

            var olista = new List<CategoriaModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.GetCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("categoriaGet", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dataRead = cmd.ExecuteReader())
                {
                    while (dataRead.Read())
                    {


                        olista.Add(new CategoriaModel
                        {
                            Id = Convert.ToInt32(dataRead["Id"]),
                            Descripcion = dataRead["Descripcion"].ToString()


                        });
                    }
                }



            }

            return olista;

        }


    }
}
