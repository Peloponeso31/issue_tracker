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
        String globarCoordenadas, globalRGB;
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

            //Obtener el color del píxel en las coordenadas del clic
            Color colorPixel = ObtenerColorPixel(x, y);

            globalRGB = colorPixel.R + ", " + colorPixel.G + ", " + colorPixel.B;

            //Mostrar valores obtenidos
            text1.Content = "Coordenadas: " + globarCoordenadas + " RGB: " + globalRGB;

            BuscarParte(globalRGB);
        }

        private void BuscarParte(String RGB)
        {
            switch (RGB) {
                case "":
                    break;
            }
        }

        private Color ObtenerColorPixel(int x, int y)
        {
            //Obtener el bitmap de la imagen
            BitmapSource imagen = (BitmapSource)imageColorMap.Source;

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
