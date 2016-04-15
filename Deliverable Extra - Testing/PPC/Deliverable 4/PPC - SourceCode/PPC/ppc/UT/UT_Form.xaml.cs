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
using System.Windows.Shapes;
using System.Windows.Forms;
using PPC.BL.Implements;
using PPC.Support_Structure;
using System.Windows.Threading;
using System.ComponentModel;


namespace PPC
{
    /// <summary>
    /// Logica di interazione per UT_Form.xaml
    /// </summary>
    public partial class UT_Form : Window
    {
        string result;

        public UT_Form()
        {
            InitializeComponent();



        }

        private void UT_FileName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Quit(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Mover(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void UploadTreeButton_Click(object sender, RoutedEventArgs e)
        {


            // Controllo sui campi
            if (UT_FileName.Text != "")
            {

                MyLoader.Visibility = Visibility.Visible;
                System.Windows.Forms.Application.DoEvents();

                Engine engine = new Engine();

                if (engine.Uploader(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\FileTreeFolder\\" + UT_FileName.Text + ".csv")) result = "correctly uploaded";
                else result = "cannot upload the tree (check the file uploadable fields or change connection parameters)";

                MyLoader.Visibility = Visibility.Hidden;

                changePage();
            }
            else
            {
                result = "Not valid input! Please Check it and retry!";
            }
        }

        public void changePage()
        {
            this.Close();
            PPC_FeedBack win2 = new PPC_FeedBack();
            win2.textBox.Text = result;

            win2.Show();

        }
    }
}

        // se tutto è andato bene procedi con il changepage altrimenti fermati con un popup

    





   

    


    



