using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Factor
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        persian_usercontrol factor_persian = new persian_usercontrol();

        public Window1()
        {
            InitializeComponent();
            GridPrincipal.Children.Add(factor_persian);
        }
        private void ButtonFechar_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // DragMove();
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListViewMenu.SelectedIndex = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            factor_persian.Add_item();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            factor_persian.Remove_item();
            //factor.Remove_item();

        }

        private void Discont_checkbox_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as CheckBox).IsChecked == true)
            {
                factor_persian.Discont_box(true);
            }
            else
            {
                factor_persian.Discont_box(false);
            }
        }

        private void Previous_debt_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as CheckBox).IsChecked == true)
            {
                factor_persian.Previous_debt_box(true);
            }
            else
            {
                factor_persian.Previous_debt_box(false);

            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
            }
            else
            {
                WindowState = WindowState.Maximized;

            }
        }

        //private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        openfiledialog.ShowDialog();
        //        if (openfiledialog.FileName != null)
        //            load_file_as_xaml(openfiledialog.FileName);

        //        openfiledialog.FileName = null;
        //    }
        //    catch (Exception)
        //    {
        //    }
        //}



        SaveFileDialog save_file = new SaveFileDialog() { Filter = " Image PNG | *.png " };
        private void ListViewItem_Selected_1(object sender, RoutedEventArgs e)
        {
            save_file.FileOk += Save_file_FileOk;
            save_file.ShowDialog();

        }

        private void Save_file_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Save_file_as_png(factor_persian, save_file.FileName);
            MessageBox.Show("Save successful !!");
        }

        private void Save_file_as_png(FrameworkElement control, string filename)
        {
            // Get the size of the Visual and its descendants.
            Rect rect = VisualTreeHelper.GetDescendantBounds(control);

            // Make a DrawingVisual to make a screen
            // representation of the control.
            DrawingVisual dv = new DrawingVisual();

            // Fill a rectangle the same size as the control
            // with a brush containing images of the control.
            using (DrawingContext ctx = dv.RenderOpen())
            {
                VisualBrush brush = new VisualBrush(control);
                ctx.DrawRectangle(brush, null, new Rect(rect.Size));
            }

            // Make a bitmap and draw on it.
            int width = (int)control.ActualWidth;
            int height = (int)control.ActualHeight;
            RenderTargetBitmap rtb = new RenderTargetBitmap(width * 2, height * 2, 96 * 2, 96 * 2, PixelFormats.Pbgra32);
            rtb.Render(dv);

            // Make a PNG encoder.
            PngBitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(rtb));

            // Save the file.
            using (FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                encoder.Save(fs);
            }
        }

        //public void save_file_as_xaml(persian_usercontrol factor_persian, bool append = false)
        //{
        //    try
        //    {
        //        Binary.WriteToBinaryFile<persian_usercontrol>("text.bin" ,factor_persian);
        //    }
        //    catch (Exception)
        //    {

        //        //throw;
        //    }


        //    //using (FileStream stream = new FileStream(save_file.FileName, FileMode.Create))
        //    //{
        //    //    XamlWriter.Save(factor, stream);
        //    //}
        //}

        //public persian_usercontrol load_file_as_xaml(string path)
        //{

        //    try
        //    {
        //        using (Stream stream = File.Open(openfiledialog.FileName, FileMode.Open))
        //        {
        //            var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
        //            return (persian_usercontrol)binaryFormatter.Deserialize(stream);
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }




        //    //if (File.Exists(path))
        //    //{
        //    //    using (FileStream stream = new FileStream(path, FileMode.Open))
        //    //    {
        //    //        GridPrincipal.Children.Clear();

        //    //     //   XamlReader.Load(stream);
        //    //        XamlReader xml = new XamlReader();
        //    //        xml.LoadAsync(stream);
        //    //        //GridPrincipal.Children.Add( UserControl);


        //    //    }
        //    //}
        //}

        private void Grid_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}

