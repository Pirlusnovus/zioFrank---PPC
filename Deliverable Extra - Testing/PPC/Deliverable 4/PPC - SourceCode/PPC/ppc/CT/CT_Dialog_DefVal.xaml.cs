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

namespace PPC.CT
{
    /// <summary>
    /// Logica di interazione per CT_Dialog_DefVal.xaml
    /// </summary>
    public partial class CT_Dialog_DefVal : Window
    {
        private string[][] myResult;

        public CT_Dialog_DefVal()
        {
            InitializeComponent();
        }

        public void keepResult(string[][] results)
        {
            myResult = results;
        }

        private void ok(object sender, RoutedEventArgs e)
        {
            if(textBox.Text != "")
            {
                int i = myResult.Length - 1;
                myResult[i] = new[] { "DefaultVal", textBox.Text };

                string output;

                MyLoader.Visibility = Visibility.Visible;
                System.Windows.Forms.Application.DoEvents();
                if (Engine.Creator(myResult)) output = "Operation Succeeded";
                else output = "Error: Cannot create the tree";

                MyLoader.Visibility = Visibility.Hidden;
                PPC_FeedBack win2 = new PPC_FeedBack();
                win2.keepResultString(output);
                win2.showResult();

                win2.Show();
                this.Close();
            } else
            {
                MessageBox.Show("Not valid input! Please Check it and retry!");
            }
        }

        private void Mover(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
