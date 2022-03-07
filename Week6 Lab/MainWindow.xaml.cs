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

namespace Week6_Lab
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //referencing database
       
        Model1Container db = new Model1Container(); 

        public MainWindow()
        {
            InitializeComponent();
        }

      


        //runs on window load for startup ations
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            var result = from a in db.Bands
                         select a;

            lbxBands.ItemsSource = result.ToList();
          


        }


        //reacts to selecting an album from the bands listbox
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //determine whatss is selected
            Band selectedBand = lbxBands.SelectedItem as Band;
           // int id = (int)lbxBands.SelectedValue;

            //check it's not null
            if (selectedBand != null)
            {
                
                var result = from a in db.Albums
                             where a.Band.Id == selectedBand.Id
                             select a.Name;

                //update second listbox
                lbxAlbums.ItemsSource = result.ToList();

            }


        }
    }


   


}
