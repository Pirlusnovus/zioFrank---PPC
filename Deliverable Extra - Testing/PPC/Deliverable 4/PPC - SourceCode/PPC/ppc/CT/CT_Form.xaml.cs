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
using PPC.BL.Implements;

namespace PPC
{
    /// <summary>
    /// Logica di interazione per CT_Form.xaml
    /// </summary>
    public partial class CT_Form : Window
    {

        TabObj[] Attrs = Engine.sendAttributes(); // questo è l'array di attributi...boh per ora lo tengo così;

        public CT_Form()
        {
            InitializeComponent();
            expander.Height = 30;
        }

        private void CreateTreeButton_Click(object sender, RoutedEventArgs e)
        {
            // istanzio un po di variabili di appoggio
            int resultLenght = 5; // tiene traccia della lunghezza della matrice dei risultati, 5 campi sono sempre sicuri
            int x, y;

            if ((CT_Type.Text != "") && (CT_Depth.Text != "") && (CT_SplitSize.Text != "") && (Int32.TryParse(CT_SplitSize.Text, out x)) && (Int32.TryParse(CT_Depth.Text, out y))) // Controllo sulla coerenza dei campi
            {
                // istanzio un po di variabili di appoggio utili
                int V_AttNumb = 0;
                int E_AttNumb = 0;
                int i=0;

                // conto quanti checkbox sono stati spuntati nelle due liste per vedere la lunghezza della matrice dei risultati
                foreach(CheckBox item in V_AL.Items)
                {
                    if (item.IsChecked == true) V_AttNumb++;
                }

                foreach (CheckBox item in E_AL.Items)
                {
                    if (item.IsChecked == true) E_AttNumb++;
                }

                string[] VertexAttr = new string[V_AttNumb];
                string[] EdgeAttr = new string[E_AttNumb];

                // verifico la Generation Rule per vedere quanti spazi mi occorrono nella matrice dei risultati
                if (radioButton1.IsChecked == true) resultLenght = resultLenght + 1;
                if (radioButton2.IsChecked == true) resultLenght = resultLenght + 2;

                // dichiaro la matrice dei risultati (la matrice dei risultati è la matrice di tutti i valori che vengono raccolti in input)
                string[][] result = new string[resultLenght][];

                // istanzio le righe statiche
                result[0] = new[] { "SplitSize", CT_SplitSize.Text };
                result[1] = new[] { "Depth", CT_Depth.Text };
                result[2] = new[] { "Type", CT_Type.Text };

                // continuo ad inserire valori nella matirce dei risultati
                i = 0;
                foreach (CheckBox item in V_AL.Items)
                {
                    if(item.IsChecked == true)
                    {
                        VertexAttr[i] = item.Content.ToString();
                        i++;
                    }
                }
                i = 0;
                foreach (CheckBox item in E_AL.Items)
                {
                    if (item.IsChecked == true)
                    {
                        EdgeAttr[i] = item.Content.ToString();
                        i++;
                    }
                }

                result[3] = VertexAttr;
                result[4] = EdgeAttr;
                i = 5;

                if (radioButton1.IsChecked == true)
                {
                    result[i] = new[] { "DefaultVal", "...ancora devo farlo inserire..." }; //questi valori sono solo momentanei, verranno presto rimpiazzati
                    i++;

                    CT.CT_Dialog_DefVal win2 = new CT.CT_Dialog_DefVal(); // creo la nuova finestra
                    win2.keepResult(result); // le passo i valori raccolti fino ad ora

                    win2.Show(); // la mostro a schermo
                    this.Close(); // chiudo la finestra attuale che non mi occorre più
                }

                if (radioButton2.IsChecked == true)
                {
                    result[i] = new[] { "RangeStartVal", "..primo valore.." }; //questi valori sono solo momentanei, verranno presto rimpiazzati
                    i++;
                    result[i] = new[] { "RangeEndVal", "..secondo valore.." }; //questi valori sono solo momentanei, verranno presto rimpiazzati
                    i++;

                    CT.CT_Dialog_RangeVal win2 = new CT.CT_Dialog_RangeVal(); // creo la nuova finestra
                    win2.keepResult(result); // le passo i valori raccolti fino ad ora

                    win2.Show(); // la mostro a schermo
                    this.Close(); // chiudo la finestra attuale che non mi occorre più
                }
            }
            else
            {
                // Mi occupo di comunicare all'utente che il suo tentativo non è andato a buon fine e rimando il controllo sulla finestra
                MessageBox.Show("Not valid input! Please Check it and retry!");
            }
        }

        private void Quit(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Mover(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void OnLoading(object sender, RoutedEventArgs e)
        {
            if(Attrs!=null)
            LoadAttr(Attrs);
            else MessageBox.Show("Cannot find attributes(Check connection parameters)");
        }

        private void LoadAttr(TabObj[] Attrs)
        {
            //ricevi Array di Attributi per ora io mi limito a simularlo così
            int i;

    
            // Ora che abbiamo il nostro Array di attributi creo un checkbox per ognuno
            for (i = 0; i < Attrs.Length; i++)
            {
                CheckBox newCbx = new CheckBox();
                CheckBox newCbx2 = new CheckBox();


                newCbx.Content = Attrs[i].name;
                newCbx2.Content = Attrs[i].name;
                newCbx.Name = "CheckBox_Vertex_" + Attrs[i].name.Replace(" ","_");
                newCbx2.Name = "CheckBox_Edge_" + Attrs[i].name.Replace(" ", "_");
                newCbx.Height = 21;
                newCbx2.Height = 21;
                newCbx.FontFamily = new FontFamily("Raavi");
                newCbx2.FontFamily = new FontFamily("Raavi");
                newCbx.VerticalContentAlignment = System.Windows.VerticalAlignment.Center;
                newCbx2.VerticalContentAlignment = System.Windows.VerticalAlignment.Center;
                newCbx.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Left;
                newCbx2.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Left;
                newCbx.Padding = new Thickness(0, -4, 0, 0);
                newCbx2.Padding = new Thickness(0, -4, 0, 0);
                newCbx.Checked += disableAtt;
                newCbx2.Checked += disableAtt;
                newCbx.Unchecked += enableAtt;
                newCbx2.Unchecked += enableAtt;


                V_AL.Items.Add(newCbx);
                E_AL.Items.Add(newCbx2);
            }
        }

        private void AddAttr(object sender, RoutedEventArgs e)
        {
            // ho bisogno di catturarmi gli attributi presenti in almeno una delle due liste
           // string[] attr = new string[V_AL.Items.Count + 1];
            bool go = true;

            if (Attrs != null)
            {
                foreach (TabObj item in Attrs)
                    if (String.Equals(item.name, ATTR_Name.Text)) go = false;
            }

       

            if (!(String.Equals(ATTR_Name.Text, "")) && go)
            {
                expander.IsExpanded = false;
                
                //qui si deve chiamare la funzione che aggiunge il nuovo attributo su DB e se funziona va avanti come segue
                if (Engine.saveAttribute(ATTR_Name.Text))
                {

                    //qui refresh di tutta la finestra
                    V_AL.Items.Clear();
                    E_AL.Items.Clear();
                    LoadAttr(Attrs = Engine.sendAttributes());
                }
                else
                {
                    MessageBox.Show("Cannot insert the attribute(Check connection parameters)");
                }

            }
            else
            {
                MessageBox.Show("Invalid Name! Retry!");
            }

        }

        private void schiacciati(object sender, RoutedEventArgs e)
        {
            expander.Height = 30;
        }

        private void rialzati(object sender, RoutedEventArgs e)
        {
            expander.Height = 210;
        }

        private void disableAtt(object sender, RoutedEventArgs e)
        {
            CheckBox Cbx = new CheckBox();
            Cbx = (CheckBox)sender;

            if (String.Equals(Cbx.Name, "CheckBox_Vertex_NOattributes"))
            {
                foreach (CheckBox item in V_AL.Items)
                {
                    if (!String.Equals(item.Name,"CheckBox_Vertex_NOattributes"))
                    {
                        item.IsChecked = false;
                        item.IsEnabled = false;
                    }
                }
            }
            else if (String.Equals(Cbx.Name,"CheckBox_Edge_NOattributes"))
            {
                foreach (CheckBox item in E_AL.Items)
                {
                    if (!String.Equals(item.Name,"CheckBox_Edge_NOattributes"))
                    {
                        item.IsChecked = false;
                        item.IsEnabled = false;
                    }
                }
            }
        }

        private void enableAtt(object sender, RoutedEventArgs e)
        {
            CheckBox Cbx = new CheckBox();
            Cbx = (CheckBox)sender;

            if (Cbx.Name == "CheckBox_Vertex_NOattributes")
            {
                foreach (CheckBox item in V_AL.Items)
                {
                    item.IsEnabled = true;
                }
            }
            else if (Cbx.Name == "CheckBox_Edge_NOattributes")
            {
                foreach (CheckBox item in E_AL.Items)
                {
                    item.IsEnabled = true;
                }
            }
        }


    }
}
