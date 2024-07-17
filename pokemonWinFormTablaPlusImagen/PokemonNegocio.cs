using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace pokemonWinForm
{
    class PokemonNegocio
    {
        public List<Pokemon> Listar()
        {
            List<Pokemon> listaPokemones = new List<Pokemon>();
            // Permite conectarme
            SqlConnection conexion = new SqlConnection();
            // Para realizar acciones con esa conexion
            SqlCommand comando = new SqlCommand();
            // y para guardar esa informacion , y alojarlo es..., 
            // y no se crea un objeto, porque cuando leo ese dato, voy a tener una instacia de un obejto...
            SqlDataReader lector;

            try
            {
                // este es conector de base de dato local, si fuera remote se colocaria un IP.
                //("server = DESKTOP-KSD96OA \\SQLEXPRESS";)  DESKTOP-KSD96OA = esto se puede reemplazar con un . (punto) , hace alusion a tu pc.
                // luego debemos poner a que DB  nos vamos a conectar (database)
                // y por ultimo como me voy a conectar (para conectarme uso window authentication o sql authentication)
                conexion.ConnectionString = "server = .\\SQLEXPRESS; database = POKEDEX_DB; integrated security = true";
                
                // aca debemos realizar la accion.
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Select Numero, Nombre, Descripcion, UrlImagen  From POKEMONS";
                
                // para luego ejectuar este comando con esa conexion.
                comando.Connection = conexion;
                
                //Luego necesito abrir esa conexion.
                conexion.Open();
                
                // hago una lectura de eso..., y tengo los datos en la variable "lector".
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    // me creo un aux de tipo pokemon, para ir guardndo la informacion del lector.
                    // ya que si tiene informacion, el puntero se va a posicion en la primera fila, 
                    // y va a dar los datos de esa primera fila.
                    Pokemon aux = new Pokemon();// en cada vuelta se crea una nueva instancia de ese objeto.

                    // para ver que get conseguir, debo posicionarme sobre la variable, en este caso numero
                    //y ver que type date es, y de ahi buscar getint, 16 es short, 32 int, 64 long.
                    aux.Numero = lector.GetInt32(0);// luego deberia poner el indice (0), que si vemos 
                    //comando.CommandText = "Select Numero indice=0, Nombre indice=1, Descripcion indice=2From POKEMONS";
                    aux.Nombre = (string)lector["Nombre"];//<< tambien lo podemos hacer de esta manera
                    aux.Descripcion = (string)lector["Descripcion"];
                    aux.UrlImagen = lector.GetString(3);

                    listaPokemones.Add(aux);
                }

                
                return listaPokemones;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conexion.Close();
            }

          

        }
    }
}
