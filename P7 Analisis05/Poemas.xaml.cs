using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;

namespace P7_Analisis05
{
    // Clase para los poemas
    public class Poema_class
    {
        public string Titulo { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;
        public string Contenido { get; set; } = string.Empty;
        public string Icono { get; set; } = "📜";
    }

    public partial class Poema : FlyoutPage
    {
        private ObservableCollection<Poema_class> _poemas;
        private ContentPage _detailPage;

        public Poema()
        {
            InitializeComponent();
            
            // Inicializar la colección de poemas
            _poemas = new ObservableCollection<Poema_class>
            {
                new Poema_class
                {
                    Titulo = "Cultivo una rosa blanca",
                    Autor = "José Martí",
                    Icono = "🌹",
                    Contenido = "Cultivo una rosa blanca\n" +
                               "en junio como en enero,\n" +
                               "para el amigo sincero\n" +
                               "que me da su mano franca.\n\n" +
                               "Y para el cruel que me arranca\n" +
                               "el corazón con que vivo,\n" +
                               "cardo ni ortiga cultivo,\n" +
                               "cultivo la rosa blanca."
                },
                new Poema
                {
                    Titulo = "Rima XXI",
                    Autor = "Gustavo Adolfo Bécquer",
                    Icono = "🌙",
                    Contenido = "¿Qué es poesía? dices mientras clavas\n" +
                               "en mi pupila tu pupila azul.\n" +
                               "¿Qué es poesía? ¿Y tú me lo preguntas?\n" +
                               "Poesía... eres tú."
                },
                new Poema
                {
                    Titulo = "Soneto XXIII",
                    Autor = "Garcilaso de la Vega",
                    Icono = "🌊",
                    Contenido = "En tanto que de rosa y azucena\n" +
                               "se muestra la color en vuestro gesto,\n" +
                               "y que vuestro mirar ardiente, honesto,\n" +
                               "enciende el corazón y lo refrena;\n\n" +
                               "y en tanto que el cabello, que en la vena\n" +
                               "del oro se escogió, con vuelo presto,\n" +
                               "por el hermoso cuello blanco, enhiesto,\n" +
                               "el viento mueve, esparce y desordena:\n\n" +
                               "coged de vuestra alegre primavera\n" +
                               "el dulce fruto, antes que el tiempo airado\n" +
                               "cubra de nieve la hermosa cumbre.\n\n" +
                               "Marchitará la rosa el viento helado,\n" +
                               "todo lo mudará la edad ligera,\n" +
                               "por no hacer mudanza en su costumbre."
                },
                new Poema
                {
                    Titulo = "Canción del pirata",
                    Autor = "José de Espronceda",
                    Icono = "⚓",
                    Contenido = "Con diez cañones por banda,\n" +
                               "viento en popa a toda vela,\n" +
                               "no corta el mar, sino vuela\n" +
                               "un velero bergantín;\n\n" +
                               "bajel pirata que llaman,\n" +
                               "por su bravura, El Temido,\n" +
                               "en todo mar conocido\n" +
                               "del uno al otro confín.\n\n" +
                               "La luna en el mar riela,\n" +
                               "en la lona gime el viento,\n" +
                               "y alza en blando movimiento\n" +
                               "olas de plata y azul."
                },
                new Poema
                {
                    Titulo = "A un olmo seco",
                    Autor = "Antonio Machado",
                    Icono = "🌳",
                    Contenido = "Al olmo viejo, hendido por el rayo\n" +
                               "y en su mitad podrido,\n" +
                               "con las lluvias de abril y el sol de mayo,\n" +
                               "algunas hojas verdes le han salido.\n\n" +
                               "¡Olmo centenario en la colina\n" +
                               "que lame el Duero! Un musgo amarillento\n" +
                               "mancha la corteza blanquecina\n" +
                               "al tronco carcomido y polvoriento."
                },
                new Poema
                {
                    Titulo = "El cuervo",
                    Autor = "Edgar Allan Poe",
                    Icono = "🐦‍⬛",
                    Contenido = "Una vez, en una lúgubre media noche,\n" +
                               "mientras, débil y cansado, en mis libros\n" +
                               "acariciaba el recuerdo de una olvidada leyenda,\n" +
                               "cuando me adormecía, llegó de repente\n" +
                               "un golpe, como si alguien suavemente llamara,\n" +
                               "llamara a mi puerta.\n\n" +
                               "«Es un visitante —murmuré—,\n" +
                               "que llama a mi puerta, eso es todo.»\n\n" +
                               "¡Ah, y bien lo recuerdo! Era en el crudo diciembre,\n" +
                               "y cada brasa moribunda esparcía su fantasma\n" +
                               "sobre el suelo."
                }
            };

            // Asignar los datos al ListView
            PoemasListView.ItemsSource = _poemas;
            
            // Obtener referencia a la página de detalle
            _detailPage = (ContentPage)((NavigationPage)Detail).CurrentPage;
            
            // Evento de selección
            PoemasListView.ItemSelected += OnPoemaSelected;
        }

        private void OnPoemaSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is Poema_class poemaSeleccionado)
            {
                // Actualizar la página de detalle
                _detailPage.Title = $"📖 {poemaSeleccionado.Titulo}";
                
                // Buscar los controles en la página de detalle
                var tituloLabel = _detailPage.FindByName<Label>("TituloPoema");
                var autorLabel = _detailPage.FindByName<Label>("AutorPoema");
                var contenidoLabel = _detailPage.FindByName<Label>("ContenidoPoema");
                
                if (tituloLabel != null)
                    tituloLabel.Text = poemaSeleccionado.Titulo;
                
                if (autorLabel != null)
                    autorLabel.Text = $"✍️ {poemaSeleccionado.Autor}";
                
                if (contenidoLabel != null)
                    contenidoLabel.Text = poemaSeleccionado.Contenido;
                
                // Cerrar el Flyout
                IsPresented = false;
                
                // Limpiar selección
                PoemasListView.SelectedItem = null;
            }
        }
    }
}