using static Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.mvvm.viewmodel.SenasParticularesViewModel;
using Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.mvvm.model;
using Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.mvvm.viewmodel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.mvvm.view
{
    /// <summary>
    /// Lógica de interacción para Captura.xaml
    /// </summary>
    public partial class Captura : UserControl
    {
        private ObservableCollection<caracDato> dataRegis = new ObservableCollection<caracDato>();
        String globarCoordenadas, globalRGB, globalSideRGB;
        int dataTableCounter = 0, imageTest = 0;
        public Captura()
        {
            ;
            DataContext = new MainViewModel();
                InitializeComponent();
                comboBox1.Text = "Tipo";
                comboBox2.Text = "Lado";
                comboBox3.Text = "Vista";
                comboBox4.Text = "Cantidad";
            scrollBarVertical.ValueChanged += ScrollBarVertical_ValueChanged;
            dataGridView1.ItemsSource = dataRegis;

            }
            

        private void addBodyData() //Obtener y añadir los datos a la tabla
            {
                int no = dataTableCounter;
                string region = textBox1.Text;
                string tipo = comboBox1.Text;
                string lado = comboBox2.Text;
                string vista = comboBox3.Text;
                string cantidad = comboBox4.Text;
                string descripcion = DescriptionBox.Text;
                string rutaImagen = pictureBox4.Tag as string;
                string coordenadas = globalRGB;

                // Crear un nuevo objeto caracDato y agregarlo a la colección
                dataRegis.Add(new caracDato { No = no, Region = region, Tipo = tipo, Lado = lado, Vista = vista, Cantidad = cantidad, Descripcion = descripcion, RutaImagen = rutaImagen, Coordenadas = coordenadas });
            }
            private void image_userIn(object sender, MouseButtonEventArgs e) //Obtener colores y coordenadas
            {
                //Obtener las coordenadas del clic
                Point posicionClic = e.GetPosition(imageUnix);

                //Convertir las coordenadas a enteros
                int x = (int)posicionClic.X;
                int y = (int)posicionClic.Y;

                globarCoordenadas = x + ", " + y;

                int state = 0;

                //Obtener el color del píxel en las coordenadas del clic
                Color parteColor = ObtenerColorPixel(x, y, state);
                globalRGB = parteColor.R + ", " + parteColor.G + ", " + parteColor.B;

                state++;

                Color sideColor = ObtenerColorPixel(x, y, state);
                globalSideRGB = sideColor.R + ", " + sideColor.G + ", " + sideColor.B;

                //Mostrar valores obtenidos
                text1.Content = "Coordenadas: " + globarCoordenadas + "\nRGB: " + globalRGB + "\nRGBside: " + globalSideRGB;

                BuscarParte(globalRGB);
                BuscarLado(globalSideRGB);

                textBox1.Foreground = Brushes.Black;
                comboBox3.Foreground = Brushes.Black;
            }
            private void BuscarLado(String RGBside) //Identificar la vista dependiendo de la zona seleccionada por el usuario
            {
                switch (RGBside)
                {
                    case "237, 28, 36":
                        comboBox3.Text = "LATERAL";
                        break;
                    case "255, 127, 39":
                        comboBox3.Text = "FRONTAL";
                        break;
                    case "255, 242, 0":
                        comboBox3.Text = "DORSAL";
                        break;
                }
            }
            private void BuscarParte(String RGB) //Identificar la parte del cuerpo seleccionada
            {
                switch (RGB)
                {
                    case "255, 0, 0":
                        textBox1.Text = "BORDE INTERNO DEL PIE";
                        break;
                    case "255, 97, 2":
                        textBox1.Text = "BORDE EXTERNO DEL PIE";
                        break;
                    case "255, 157, 3":
                        textBox1.Text = "CARA DORSAL DE LA MANO";
                        break;
                    case "255, 204, 3":
                        textBox1.Text = "CARA INTERNA DEL MUSLO";
                        break;
                    case "255, 245, 2":
                        textBox1.Text = "CARA PLANTAR O PLANTA DEL PIE";
                        break;
                    case "217, 255, 0":
                        textBox1.Text = "CARA POSTERIOR DE LA MUÑECA";
                        break;
                    case "133, 255, 0":
                        textBox1.Text = "CARA POSTERIOR DE LA PIERNA";
                        break;
                    case "51, 255, 2":
                        textBox1.Text = "CARA POSTERIOR DEL ANTEBRAZO";
                        break;
                    case "0, 255, 52":
                        textBox1.Text = "CARA POSTERIOR DEL BRAZO";
                        break;
                    case "255, 179, 179":
                        textBox1.Text = "CARA PORTERIOR DEL CODO";
                        break;
                    case "0, 255, 250":
                        textBox1.Text = "CARA PORSTERIOR DEL MUSLO";
                        break;
                    case "0, 158, 255":
                        textBox1.Text = "DEDOS DE LA MANO";
                        break;
                    case "0, 3, 255":
                        textBox1.Text = "HUECO POPLITEO";
                        break;
                    case "237, 0, 255":
                        textBox1.Text = "PARED POSTERIOR DE LA AXILA";
                        break;
                    case "255, 1, 172":
                        textBox1.Text = "REGION DEL TRAPECIO";
                        break;
                    case "255, 0, 76":
                        textBox1.Text = "REGION CLUTEA";
                        break;
                    case "255, 241, 29":
                        textBox1.Text = "REGION LUMBAR";
                        break;
                    case "255, 120, 30":
                        textBox1.Text = "REGION LUMBAR EXTERNA FLANCO";
                        break;
                    case "255, 30, 30":
                        textBox1.Text = "REGION MASTOIDEA";
                        break;
                    case "255, 236, 31":
                        textBox1.Text = "REGION OCCIPITAL";
                        break;
                    case "122, 255, 32":
                        textBox1.Text = "REGION POSTERIOR DEL CUELLO";
                        break;
                    case "33, 255, 58":
                        textBox1.Text = "REGION SACRA";
                        break;
                    case "31, 255, 224":
                        textBox1.Text = "TALON";
                        break;
                    case "20, 67, 255":
                        textBox1.Text = "TENDON DE AQUILES";
                        break;
                    case "132, 86, 255":
                        textBox1.Text = "REGION PALMAR";
                        break;
                    case "50, 20, 255":
                        textBox1.Text = "CARA PALMAR DE LA 2A. FALANGE";
                        break;
                    case "149, 19, 255":
                        textBox1.Text = "CARA PALMAR DE LA 3A. FALANGE";
                        break;
                    case "255, 21, 190":
                        textBox1.Text = "CARA PALMAR DE LA 1A. FALANGE";
                        break;
                    case "255, 22, 102":
                        textBox1.Text = "TOBILLO";
                        break;
                    case "255, 40, 245":
                        textBox1.Text = "DORDOS DEL PIE";
                        break;
                    case "255, 40, 59":
                        textBox1.Text = "EPIGASTRO";
                        break;
                    case "164, 40, 255":
                        textBox1.Text = "FLANCO";
                        break;
                    case "80, 42, 255":
                        textBox1.Text = "FOSA ILIACA";
                        break;
                    case "255, 79, 70":
                        textBox1.Text = "REGION FRONTAL";
                        break;
                    case "43, 120, 255":
                        textBox1.Text = "HIPOCONDRIO";
                        break;
                    case "42, 219, 255":
                        textBox1.Text = "MALEOLO EXTERNO";
                        break;
                    case "44, 255, 206":
                        textBox1.Text = "MALEOLO INTERNO";
                        break;
                    case "46, 255, 99":
                        textBox1.Text = "MASETERINA";
                        break;
                    case "255, 90, 90":
                        textBox1.Text = "REGION INGUINAL O INGLE";
                        break;
                    case "137, 255, 48":
                        textBox1.Text = "MENTON O BARBILLA";
                        break;
                    case "253, 255, 47":
                        textBox1.Text = "PARED ANTERIOR DE LA AXILA";
                        break;
                    case "255, 155, 49":
                        textBox1.Text = "REGION CLAVICULAR";
                        break;
                    case "255, 50, 50":
                        textBox1.Text = "REGION ESTERNAL";
                        break;
                    case "251, 85, 255":
                        textBox1.Text = "REGION PECTORAL";
                        break;
                    case "255, 83, 159":
                        textBox1.Text = "REGION PERIBUCAL";
                        break;
                    case "255, 83, 86":
                        textBox1.Text = "REGION PUBIANA";
                        break;
                    case "255, 102, 105":
                        textBox1.Text = "REGION TORULEANA O ROTULA";
                        break;
                    case "255, 121, 202":
                        textBox1.Text = "REGION SUPRACLAVICULAR";
                        break;
                    case "245, 119, 255":
                        textBox1.Text = "REGION XIFOIDEA";
                        break;
                    case "194, 118, 255":
                        textBox1.Text = "REGION MANO";
                        break;
                    case "118, 132, 255":
                        textBox1.Text = "REGION PIE";
                        break;
                    case "118, 184, 255":
                        textBox1.Text = "REGION HOMBRO";
                        break;
                    case "255, 253, 85":
                        textBox1.Text = "REGION LATERAL DEL CUELLO";
                        break;
                    case "119, 255, 255":
                        textBox1.Text = "REGION TIBIA";
                        break;
                    case "87, 255, 110":
                        textBox1.Text = "REGION METATARZO";
                        break;
                    case "210, 255, 85":
                        textBox1.Text = "REGION MALAR O POMULO";
                        break;
                    case "118, 255, 172":
                        textBox1.Text = "REGION ABDOMEN INFERIOR";
                        break;
                    case "132, 255, 118":
                        textBox1.Text = "REGION ABDOMEN SUPERIOR";
                        break;
                    case "222, 255, 120":
                        textBox1.Text = "REGION BOCA";
                        break;
                    case "86, 255, 200":
                        textBox1.Text = "REGION NARIZ";
                        break;
                    case "255, 187, 138":
                        textBox1.Text = "REGION NASAL";
                        break;
                    case "255, 137, 137":
                        textBox1.Text = "REGION OREJA";
                        break;
                    case "1, 255, 23":
                        textBox1.Text = "REGION CARA";
                        break;
                    case "4, 236, 255":
                        textBox1.Text = "REGION ESPALDA INFERIOR";
                        break;
                    case "41, 255, 125":
                        textBox1.Text = "REGION ESPALDA SUPERIOR";
                        break;
                    case "146, 255, 227":
                        textBox1.Text = "REGION CABEZA";
                        break;
                    case "255, 245, 163":
                        textBox1.Text = "REGION NUCA";
                        break;
                    case "255, 209, 164":
                        textBox1.Text = "REGION ANTEBRAZO";
                        break;
                    case "255, 162, 162":
                        textBox1.Text = "REGION BRAZO";
                        break;
                    case "255, 85, 85":
                        textBox1.Text = "REGION MAMILAR O TETILLA";
                        break;
                    case "0, 255, 172":
                        textBox1.Text = "REGION CODO";
                        break;
                    case "255, 112, 112":
                        textBox1.Text = "REGION CUELLO";
                        break;
                    case "255, 86, 89":
                        textBox1.Text = "REGIOL MUSLO";
                        break;
                    case "255, 188, 189":
                        textBox1.Text = "REGION MUÑECA";
                        break;
                    case "255, 186, 228":
                        textBox1.Text = "REGION OMOPLATO";
                        break;
                    case "191, 9, 255":
                        textBox1.Text = "REGION RODILLA";
                        break;
                    case "86, 167, 255":
                        textBox1.Text = "REGION ORBITARIA";
                        break;
                    case "255, 227, 227":
                        textBox1.Text = "REGION FRENTE";
                        break;
                    case "63, 72, 204":
                        textBox1.Text = "NINGUNA SELECCION";
                        break;
                    default:
                        textBox1.Text = "NO REGISTRADO";
                        break;
                }
            }
            private Color ObtenerColorPixel(int x, int y, int state) //Obtener colores dependiendo de los parametros obtenidos
            {
                BitmapSource imagen;

                if (state == 0)
                {
                    imagen = (BitmapSource)imageColorMap.Source; //Si es cero buscar los colores en el mapeo completo
                }
                else
                {
                    imagen = (BitmapSource)imageSide.Source; //Si es diferente a cero buscar los colores en el mapeo de las vistas
                }

                //Crear un arreglo de bytes para almacenar los datos de los píxeles
                byte[] datos = new byte[4];

                //Bloquear el bitmap para acceder a los datos de los píxeles
                imagen.CopyPixels(new Int32Rect(x, y, 1, 1), datos, 4, 0);

                //Crear y devolver el color del píxel en formato RGB
                return Color.FromRgb(datos[2], datos[1], datos[0]);
            }
            private void image_userSelect(object sender, MouseButtonEventArgs e) //Perimite al usuario seleccionar y mostrar una imagen
            {
                //Crear un cuadro de diálogo para seleccionar un archivo
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Archivos de imagen (*.png;*.jpg)|*.png;*.jpg|Todos los archivos (*.*)|*.*";

                //Mostrar el cuadro de diálogo y esperar a que el usuario seleccione un archivo
                if (openFileDialog.ShowDialog() == true)
                {
                    //Obtener la ruta del archivo seleccionado
                    string rutaImagen = openFileDialog.FileName;

                    try
                    {
                        //Crear un objeto BitmapImage y establecer la fuente en la imagen seleccionada
                        BitmapImage bitmapImage = new BitmapImage(new Uri(rutaImagen));

                        //Mostrar la imagen en el elemento Image
                        ((Image)sender).Source = bitmapImage;

                        imageTest = 1;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cargar el archivo seleccionado:" + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }

            private void Button_Click(object sender, RoutedEventArgs e) //Accion para verificar si todos los datos fueron introduccidos, guardar y mostrar en una tabla
            {
                if (textBox1.Text != "Region del cuerpo" &&
                    textBox1.Text != "NINGUNA SELECCION" &&
                    comboBox1.Text != "Tipo" &&
                    comboBox2.Text != "Lado" &&
                    comboBox4.Text != "Vista" &&
                    comboBox3.Text != "Cantidad" &&
                    DescriptionBox.Text != "Descripción" &&
                    imageTest == 1)
                {
                    //Todo lo que esta en comentario es para reemplazar la imagen subida por el usuario por la imagen por default
                    //string defaultImage = "C:/Users/davfa/source/repos/desktop_cebv/media/images/senas/Minus loadIcon.png";

                    //if (File.Exists(defaultImage))
                    //{
                    //BitmapImage bitmapImage = new BitmapImage(new Uri(defaultImage));
                    //pictureBox4.Source = new BitmapImage(new Uri(defaultImage, UriKind.Relative));

                    MessageBox.Show("Se guardó la información correctamente", "", MessageBoxButton.OK, MessageBoxImage.Information);

                    dataTableCounter += 1; // Incrementa el contador de filas
                    addBodyData(); // Añade los datos

                    textBox1.Text = "Region del cuerpo";
                    comboBox1.Text = "Tipo";
                    comboBox2.Text = "Lado";
                    comboBox4.Text = "Cantidad";
                    comboBox3.Text = "Vista";
                    DescriptionBox.Text = "Descripción";
                    imageTest = 0;

                    textBox1.Foreground = Brushes.DarkGray;
                    comboBox1.Foreground = Brushes.DarkGray;
                    comboBox2.Foreground = Brushes.DarkGray;
                    comboBox3.Foreground = Brushes.DarkGray;
                    comboBox4.Foreground = Brushes.DarkGray;
                    DescriptionBox.Foreground = Brushes.DarkGray;
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Error al cargar los recursos del proyecto. \nNo se encontró:\n" + defaultImage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    //}
                }
                else
                {
                    MessageBox.Show("Llena los campos requeridos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        


        private void ScrollBarVertical_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            scrollViewer.ScrollToVerticalOffset(e.NewValue);
        }
        private void changeBlankTipo(object sender, RoutedEventArgs e) //Identificar si el usuario hizo un cambio en la casilla de Tipo y cambiar los colores
        {
            if (comboBox1.Text == "Tipo")
            {
                comboBox1.Foreground = Brushes.DarkGray;
            }
            else
            {
                comboBox1.Foreground = Brushes.Black;
            }
        }
        private void changeBlankLado(object sender, RoutedEventArgs e) //Identificar si el usuario hizo un cambio en la casilla de Lado y cambiar los colores
        {
            if (comboBox2.Text == "Lado")
            {
                comboBox2.Foreground = Brushes.DarkGray;
            }
            else
            {
                comboBox2.Foreground = Brushes.Black;
            }
        }
        private void changeBlankVista(object sender, RoutedEventArgs e) //Identificar si el usuario hizo un cambio en la casilla de Vista y cambiar los colores
        {
            if (comboBox3.Text == "Vista")
            {
                comboBox3.Foreground = Brushes.DarkGray;
            }
            else
            {
                comboBox3.Foreground = Brushes.Black;
            }
        }
        private void changeBlankCantidad(object sender, RoutedEventArgs e) //Identificar si el usuario hizo un cambio en la casilla de Cantidad y cambiar los colores
        {
            if (comboBox4.Text == "Cantidad")
            {
                comboBox4.Foreground = Brushes.DarkGray;
            }
            else
            {
                comboBox4.Foreground = Brushes.Black;
            }
        }
        private void ReplaceDescripcion(object sender, RoutedEventArgs e) //Si es seleccionado la descripcion se le cambia el color de la fuente
        {
            if (DescriptionBox.Text == "Descripción")
            {
                DescriptionBox.Text = "";
                DescriptionBox.Foreground = Brushes.Black;
            }
        }
        private void ReplaceBlankDescripcion(object sender, RoutedEventArgs e) //Si la descripcion se deja en blanco se pone un texto por default
        {
            if (DescriptionBox.Text == "")
            {
                DescriptionBox.Foreground = Brushes.DarkGray;
                DescriptionBox.Text = "Descripción";
            }
        }

    }
}
