using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace try_02_SpartaPaint
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BitMap _bitmap;
        int _pixelSize;

        public MainWindow()
        {
            InitializeComponent();

            // Custom initialization
            _pixelSize = 1;
        }

        /// <summary>
        /// Load bitmap from file
        /// </summary>
        /// <param name="filePath">Path of the bitmap file</param>
        public void LoadBitmap(string filePath)
        {
            if (!File.Exists(filePath)) throw new Exception("File not found");

            var bf = new BitmapFileHeader();
            var bi = new BitmapInfoHeader();
            int padding;
            RGBTriple[] pixelmap;

            using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
            {
                // Read the bitmap file header
                bf.bfType1 = reader.ReadByte();
                bf.bfType2 = reader.ReadByte();
                bf.bfSize = reader.ReadUInt32();
                bf.bfReserved1 = reader.ReadUInt16();
                bf.bfReserved2 = reader.ReadUInt16();
                bf.bfOffBits = reader.ReadUInt32();

                // Read the bitmap info header
                bi.biSize = reader.ReadUInt32();
                bi.biWidth = reader.ReadInt32();
                bi.biHeight = reader.ReadInt32();
                bi.biPlanes = reader.ReadUInt16();
                bi.biBitCount = reader.ReadUInt16();
                bi.biCompression = reader.ReadUInt32();
                bi.biSizeImage = reader.ReadUInt32();
                bi.biXPelsPerMeter = reader.ReadInt32();
                bi.biYPelsPerMeter = reader.ReadInt32();
                bi.biClrUsed = reader.ReadUInt32();
                bi.biClrImportant = reader.ReadUInt32();

                // Check whether filetype is supported
                if (bf.bfType1 != 'B' || bf.bfType2 != 'M' || bf.bfOffBits != 54 ||
                    bi.biSize != 40 || bi.biBitCount != 24 || bi.biCompression != 0 ||
                    bi.biPlanes != 1)
                {
                    throw new Exception("Unsupported file format");
                }

                // Set up the size of the pixelmap
                pixelmap = new RGBTriple[bi.biWidth * Math.Abs(bi.biHeight)];

                // Calculate padding
                padding = (4 - (bi.biWidth * RGBTriple.Size) % 4) % 4;

                // Loop over all scanlines
                for (int i = 0, biHeight = Math.Abs(bi.biHeight); i < biHeight; ++i)
                {
                    // Loop over pixels in scanline
                    for (int j = 0; j < bi.biWidth; ++j)
                    {
                        // Read pixel
                        var triple = new RGBTriple
                        {
                            rgbtBlue = reader.ReadByte(),
                            rgbtGreen = reader.ReadByte(),
                            rgbtRed = reader.ReadByte()
                        };

                        // Store pixel in pixelmap.
                        pixelmap[i * bi.biWidth + j] = triple;
                    }

                    // Jump over padding, if any
                    reader.ReadBytes(padding);
                }
            }

            _bitmap = new BitMap
            {
                bi = bi,
                bf = bf,
                pixelmap = pixelmap
            };

        }

        /// <summary>
        /// Draw the bitmap to the canvas
        /// </summary>
        public void DrawBitmap()
        {
            // Clear the canvas
            ImageCanvas.Children.Clear();

            // Don't draw if there's not bitmap to draw
            if (_bitmap == null) return;

            // Create variables for easy access
            var pixelmap = _bitmap.pixelmap;
            var width = _bitmap.bi.biWidth;
            var height = _bitmap.bi.biHeight;

            // Go through the entire pixelmap
            for (int i = 0; i < pixelmap.Length; i++)
            {
                // Convert the RGB triple to a hexadecimal string
                string hexColor = "#" + BitConverter.ToString(
                    new byte[]
                    {
                        _bitmap.pixelmap[i].rgbtRed,
                        _bitmap.pixelmap[i].rgbtGreen,
                        _bitmap.pixelmap[i].rgbtBlue
                    }).Replace("-", string.Empty);

                // Set the filcolor to the hexadecimal color
                Color color = (Color)ColorConverter.ConvertFromString(hexColor);
                SolidColorBrush colorBrush = new SolidColorBrush(color);

                // Create the current pixel
                var currentPixel = new Rectangle
                {
                    Fill = colorBrush,
                    Height = _pixelSize,
                    Width = _pixelSize
                };

                // Add the pixel to the canvas
                ImageCanvas.Children.Add(currentPixel);

                // For a bitmap with a positive height, scanlines are
                // stored bottom to top. For a negative height this is
                // the other way around.
                // Taking this into account, calculate the correct
                // position for the bitmap.
                int calculateTop = (height < 0) ?
                    ((i / width) * _pixelSize) :
                    ((height - i / width) * _pixelSize);

                // Place the pixel on the canvas
                Canvas.SetLeft(currentPixel, (i % width) * _pixelSize);
                Canvas.SetTop(currentPixel, calculateTop);
            }
        }

        #region Event handlers

        /// <summary>
        /// Adjust the zoom when the left control key is held and the mousewheel is moved
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ZoomHandler(object sender, MouseWheelEventArgs e)
        {
            // Only scroll if left control is held
            if (!Keyboard.IsKeyDown(Key.LeftCtrl)) return;

            // Change the zoom based on the mouse scroll
            if (e.Delta > 0) _pixelSize *= 2;
            else _pixelSize /= 2;

            // Min en max zoom
            if (_pixelSize < 1) _pixelSize = 1;
            if (_pixelSize > 64) _pixelSize = 64;

            // Redraw the canvas
            DrawBitmap();
        }

        /// <summary>
        /// Event handler that is called when the user tries to close the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ApplicationClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Ask for confirmation
            MessageBoxResult result = MessageBox.Show(
                "Are you sure you want to close the application?",
                "SpartaPaint",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            // If user does not want to close the application, cancel closing
            if (result == MessageBoxResult.No) e.Cancel = true;
        }

        #endregion

        #region Commands

        private void OpenCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void OpenCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            // Open file dialog window
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Restrict files that can be opened to bitmaps
            openFileDialog.Filter = "Bitmap files (*.bmp)|*.bmp";

            // Don't do anything when the user cancels opening a file
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    LoadBitmap(openFileDialog.FileName);
                    DrawBitmap();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, $"Could not load file",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        #endregion

        private void CloseApp(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CloseCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CloseCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }
    }
}
