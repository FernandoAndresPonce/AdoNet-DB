using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pokemonWinForm
{
    public partial class Form1 : Form

    {
        // Atributo
        private List<Pokemon> listaPokemon;
        public Form1()
        {
            InitializeComponent();
        }



        //metodo especial, porque tenemos evento, por ese motivo.
        private void Form1_Load(object sender, EventArgs e)
        {
            // Cuando carge el formulario necesito traer la informacion que traje de la base de datos.

            PokemonNegocio negocio = new PokemonNegocio();
            // a esa grilla que puse en el formulario data grid view , le asigno lo que traje de la base de dato.

            //dataGridViewPokemon.DataSource = negocio.Listar(); MOSTRABA TABLA, CON SUS PROPIEDADES.

            listaPokemon = negocio.Listar();

            //El dataSource despliega al objeto, y agarra estas propiedades en la pones en cada uno en sus columna.
            dataGridViewPokemon.DataSource = listaPokemon;
            pictureBoxPokemon.Load(listaPokemon[1].UrlImagen);

            //Colocar imagenes, y agarrarla desde una base de dato y pasarla al framewoork, con la libreria
            //ado.net, a traves de forma local, o con una url// 
        }

        private void dataGridViewPokemon_SelectionChanged(object sender, EventArgs e)
        {
            // podemos elegir cualquier evento de seleccion , hay varios pero cada uno
            //cargadara diferente la imagen, en el sentido de que cada celda que toque, carge la imagen de nuevo.

            // Para cambiar de pokemon de acuerdo, si seleccionamos una celda o otra.
            // de la grilla, de la fila actual,  dame el objeto enlazado(dataBoundItem)
            Pokemon seleccionado = (Pokemon)dataGridViewPokemon.CurrentRow.DataBoundItem;
            
            //pictureBoxPokemon.Load(seleccionado.UrlImagen); // se que es un objeto del tipo pokemon, entonces debo decirle que propiedad quiero
            
            cargarImagen(seleccionado.UrlImagen);// cuando creamos un metodo la evitar esa exception, hacemos lo siguiente
        }

        //Ahora creamos un metodo privado , para cuando eliminamos un imagen, o no tiene su url, no salte un error
        // o exeption
        private void cargarImagen(string imagenSeleccionado)
        {
            try
            {
                pictureBoxPokemon.Load(imagenSeleccionado);
            }
            catch (Exception ex)
            {
                //Tal vez no tenga imagen, pero puedo cargar un placeHolder, sin imagenes.
                // copyi image addres, o copiar dirreccion de imagen.
                // en una exption ademas de mensajes puedo pasar imagenes.
                pictureBoxPokemon.Load("https://upload.wikimedia.org/wikipedia/commons/thumb/3/3f/Placeholder_view_vector.svg/681px-Placeholder_view_vector.svg.png");
            }
            
        }
    }
}
