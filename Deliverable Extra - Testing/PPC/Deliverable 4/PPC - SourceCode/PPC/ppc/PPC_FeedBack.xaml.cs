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

namespace PPC
{
    /// <summary>
    /// Logica di interazione per PPC_FeedBack.xaml
    /// </summary>
    public partial class PPC_FeedBack : Window
    {
        private string[][] myResult = null;
        private string output = "";

        public PPC_FeedBack()
        {
            InitializeComponent();
        }

        public void keepResult(string[][] results)
        {
            myResult = results;
        }

        public void keepResultString(string results)
        {
            output = results;
        }


        public void showResult()
        {
            if (myResult != null) output = "";          
            this.textBox.Text = output;
        }



        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Ok(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Mover(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
