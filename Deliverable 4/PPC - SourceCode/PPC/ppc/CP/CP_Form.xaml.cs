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
using PPC.Support_Structure;

namespace PPC
{
    /// <summary>
    /// Logica di interazione per CP_Form.xaml
    /// </summary>
    public partial class CP_Form : Window
    {
        public CP_Form()
        {
            InitializeComponent();
        }

        private void Quit(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void CalculatePathButton_Click(object sender, RoutedEventArgs e)
        {
            string result;
            bool ok = true;

            // Controllo sui campi
            if((CP_Type.Text!="") && (CP_VertexA.Text!="") && (CP_VertexB.Text!=""))
            {
                Engine engine = new Engine();

                MyLoader.Visibility = Visibility.Visible;
                System.Windows.Forms.Application.DoEvents();
                Result v = engine.Calculator(CP_Type.Text, CP_VertexA.Text, CP_VertexB.Text);
                if (v != null)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine(String.Join(",", v.nomi_vertici));
                    for (int i = 0; i < v.nomi_attributi_vertici.Length; i++)
                    {
                        sb.AppendLine(v.nomi_attributi_vertici[i]);
                        sb.AppendLine(v.somme_attributi_vertici[i]);
                    }
                    for (int i = 0; i < v.nomi_attributi_archi.Length; i++)
                    {
                        sb.AppendLine(v.nomi_attributi_archi[i]);
                        sb.AppendLine(v.somme_attributi_archi[i]);
                    }
                    result = sb.ToString();
                }
                else result = "Not valid input or connection parameters! Please Check them and retry!";



            } else
            {
                result = "Not valid input or connection parameters! Please Check them and retry!";
                ok = false;
            };


            MyLoader.Visibility = Visibility.Hidden;
            // se tutto è andato bene procedi con il changepage altrimenti fermati con un popup
            if (ok)
            {
                PPC_FeedBack win2 = new PPC_FeedBack();
                win2.textBox.Text = result;

                win2.Show();
                this.Close();
            } else
            {
                MessageBox.Show(result);
            }



        }

        private void Mover(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
