using Microsoft.Win32;
using System;
using System.Collections.Generic;
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

//test@example.com
//password

namespace Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.mvvm.view
{
    public partial class Senas : UserControl
    {
        String globarCoordenadas, globalRGB, globalSideRGB;
        public Senas()
        {
            InitializeComponent();
            comboBox1.Text = "Tipo";
            comboBox2.Text = "Lado";
            comboBox3.Text = "Vista";
            comboBox4.Text = "Cantidad";
        }

        private void image_userIn(object sender, MouseButtonEventArgs e)
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
        }

        private void BuscarLado(String RGBside)
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

        private void BuscarParte(String RGB)
        {
            switch (RGB) {
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

        private Color ObtenerColorPixel(int x, int y, int state)
        {
            BitmapSource imagen;

            if (state == 0)
            {
                imagen = (BitmapSource)imageColorMap.Source;
            }
            else
            {
                imagen = (BitmapSource)imageSide.Source;
            }

            //Crear un arreglo de bytes para almacenar los datos de los píxeles
            byte[] datos = new byte[4];

            //Bloquear el bitmap para acceder a los datos de los píxeles
            imagen.CopyPixels(new Int32Rect(x, y, 1, 1), datos, 4, 0);

            //Crear y devolver el color del píxel en formato RGB
            return Color.FromRgb(datos[2], datos[1], datos[0]);
        }

        private void image_userSelect(object sender, MouseButtonEventArgs e)
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
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar el archivo seleccionado: " + ex.Message);
                }
            }
        }
        private void ReplaceDescripcion(object sender, RoutedEventArgs e)
        {
            if (DescriptionBox.Text == "Descripción")
            {
                DescriptionBox.Text = "";
                DescriptionBox.Foreground = Brushes.Black;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (textBox1.Text != "" && comboBox1.Text != "" && comboBox2.Text != "" && comboBox4.Text != "" && comboBox3.Text != "" && DescriptionBox.Text != "" && globalRGB != "")
            {
                int contadorFilas = 0;

                // Incrementa el contador de filas
                contadorFilas += 1;

                // Obtener imagen
                ImageSource imagenSource = pictureBox4.Source;

                // Crea un array para representar los datos de una fila
                object[] nuevaFila = { contadorFilas, textBox1.Text, comboBox1.Text, comboBox2.Text, comboBox4.Text, comboBox3.Text, DescriptionBox.Text, globalRGB };

                // Agrega la nueva fila al DataGridView
                dataGridView1.Items.Add(nuevaFila);
            }
            
        }

        private void ReplaceBlankDescripcion(object sender, RoutedEventArgs e)
        {
            if (DescriptionBox.Text == "")
            {
                DescriptionBox.Foreground = Brushes.DarkGray;
                DescriptionBox.Text = "Descripción";
            }
        }
    }
}
