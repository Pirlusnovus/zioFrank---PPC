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

namespace PPC
{
    /// <summary>
    /// Logica di interazione per PPC_Home.xaml
    /// </summary>
    public partial class PPC_Home : Window
    {
        bool DB_connection = false;

        public PPC_Home()
        {
            InitializeComponent();

            if (DB_connection == false)
            {
                CalculatePathButton.IsEnabled = false;
                CreateTreeButton.IsEnabled = false;
                UploadTreeButton.IsEnabled = false;
            }
        }

        private void EnableButton()
        {
            if (DB_connection)
            {
                CalculatePathButton.IsEnabled = true;
                CreateTreeButton.IsEnabled = true;
                UploadTreeButton.IsEnabled = true;
            }
        }

        private void SelectionButton_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;

            

            switch (btn.Name)
            {
                case "CreateTreeButton":
                    CT_Form win2 = new CT_Form();
                    win2.Show();
                    break;
                case "UploadTreeButton":
                    UT_Form win3 = new UT_Form();
                    win3.Show();
                    break;
                case "CalculatePathButton":
                    CP_Form win4 = new CP_Form();
                    win4.Show();
                    break;
                default:
                    MessageBox.Show("Invalid Command");
                    break;
            }
        }

        private void ShowNewText(object sender, MouseEventArgs e)
        {
            string textdefault = "Welcome to PPC . This Software supports the Micron's production process. From this menu you can access 3 different functions. Remember also to config DB parameters before doing anything else (look in the upper right corner).";
            string text;
            var btn = sender as Button;

            //            MessageBox.Show(e.RoutedEvent.ToString());
            //            MessageBox.Show("Siamo in Galera");

            if (e.RoutedEvent.ToString() == "Mouse.MouseEnter")
            {
                switch (btn.Name)
                {
                    case "CreateTreeButton":
                        text = "This feature allows the user to generate a new file tree by inserting appropriate parameters.";
                        break;
                    case "UploadTreeButton":
                        text = "This feature allows you to upload a given file tree on DataBase.";
                        break;
                    case "CalculatePathButton":
                        text = "This function indicates a sub-branch of a tree and performs calculations on the attributes of the path.";
                        break;
                    default:
                        text = textdefault;
                        break;
                }
            }
            else
            {
                text = textdefault;
            }

             Manual.Text = text;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string text = "Welcome to PPC . This Software supports the Micron's production process. From this menu you can access 3 different functions. Remember also to config DB parameters before doing anything else (look in the upper right corner).";
            Manual.Text = text;
        }

        private void ExitApp(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Connect(object sender, RoutedEventArgs e)
        {
            string Server = TB_SERVER.Text;
            string DataBase = TB_DB.Text;
            string User = TB_UID.Text;
            string pwd = TB_PWD.Password;
            Engine engine = new Engine();
            if (engine.updateConfigFile(Server, DataBase, User, pwd))
            {
                MessageBox.Show("Configuration parameters inserted");

                TB_PWD.Password = "";

                expander.IsExpanded = false;
                DB_connection = true;
                EnableButton();
            }
            else {
                MessageBox.Show("Cannot confing! You must insert parameters");
            }
            
        }
    }
}
