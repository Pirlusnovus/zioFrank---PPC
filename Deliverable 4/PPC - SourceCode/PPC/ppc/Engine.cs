using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using System.Xml;
using System.Configuration;
using PPC.BL.Implements;
using PPC.Support_Structure;

namespace PPC
{
    class Engine:IEngine
    {
        /////////////////////////////////////////////////////////////////////////////////////*Creator*////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static bool Creator(string[][] valori)
        {
            int splitsize = Convert.ToInt32(valori[0][1]);
            int depth = Convert.ToInt32(valori[1][1]);
            string type = valori[2][1];

           
                //generates the tree
                int cardinalità = ((int)Math.Pow(splitsize, depth + 1) - 1) / (splitsize - 1);
                Vertex_Edge[] Vertex_Edge_List = new Vertex_Edge[cardinalità];


            if (valori.GetLength(0) == 7)
            {

                int n = Math.Min(Convert.ToInt32(valori[5][1]), Convert.ToInt32(valori[6][1]));
                int m = Math.Max(Convert.ToInt32(valori[5][1]), Convert.ToInt32(valori[6][1]));

                Random random = new Random();
                int count = 0;
                foreach (Vertex_Edge oggetto in Vertex_Edge_List)
                {
                    Vertex_Edge_List.SetValue(new Vertex_Edge("Nome Vertice" + (count + 1), new string[valori[3].Length], new string[valori[4].Length]), count);
                    int i = 0;
                    foreach (string vertice in Vertex_Edge_List[count].getVertex_Attribute_Value_List())
                    {
                        Vertex_Edge_List[count].getVertex_Attribute_Value_List()[i] = (random.Next(n, m).ToString());
                        i++;
                    }
                    i = 0;
                    foreach (string arco in Vertex_Edge_List[count].getEdge_Attribute_Value_List())
                    {
                        Vertex_Edge_List[count].getEdge_Attribute_Value_List()[i] = (random.Next(n, m).ToString());
                        i++;
                    }
                    count++;
                }
                count = 0;
                foreach (string arco in Vertex_Edge_List[0].getEdge_Attribute_Value_List())
                {
                    Vertex_Edge_List[0].getEdge_Attribute_Value_List()[count] = "NULL";
                    count++;
                }
            }
            else
            {
                string value = valori[5][1];
                int count = 0;
                foreach (Vertex_Edge oggetto in Vertex_Edge_List)
                {
                    Vertex_Edge_List.SetValue(new Vertex_Edge("Nome Vertice" + (count + 1), new string[valori[3].Length], new string[valori[4].Length]), count);
                    int i = 0;
                    foreach (string vertice in Vertex_Edge_List[count].getVertex_Attribute_Value_List())
                    {
                        Vertex_Edge_List[count].getVertex_Attribute_Value_List()[i] =value;
                        i++;
                    }
                    i = 0;
                    foreach (string arco in Vertex_Edge_List[count].getEdge_Attribute_Value_List())
                    {
                        Vertex_Edge_List[count].getEdge_Attribute_Value_List()[i] = value;
                        i++;
                    }
                    count++;
                }
                count = 0;
                foreach (string arco in Vertex_Edge_List[0].getEdge_Attribute_Value_List())
                {
                    Vertex_Edge_List[0].getEdge_Attribute_Value_List()[count] = "NULL";
                    count++;
                }
            }

                Tree albero = new Tree(splitsize, depth, type, valori[3], valori[4], Vertex_Edge_List);

            //save the tree in a file 
            string dir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\FileTreeFolder\\";

            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);


            FileToCSV tree = new FileToCSV();
                return tree.save_fileTree(albero, dir + albero.getType() + ".csv");

            
            
        }



        /////////////////////////////////////////////////////////////////////////////////////*Uploader*////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public  bool Uploader(string file)
        {
            Tree albero;
   
                FileToCSV up = new FileToCSV();
                albero = up.file_to_tree(file);

            if (albero == null) return false;

            Connection cnn = new Connection();
            if (cnn.insert_tree(albero))
                if (cnn.insert_vertex_attributes(albero))
                {
                    cnn.insert_edge_attributes(albero);
                    return true;
                }
                else
                {
                    return false;
                }
            else
            {
                return false;
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////*Calculator*////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public  Result Calculator(string tree, string vertexA, string vertexB)
        {
            Connection cnn = new Connection();

            //useful variable

            TabPath[] pathv;
            TabPath[] pathe;
            TabObj start, end;

            //takes the tree's property 

            int[] tree_property = cnn.select_tree_property(tree);
            if (tree_property == null) return null;
            int splitsize = tree_property[0];
            int numero_attributi_vertici = tree_property[1];
            int numero_attributi_archi = tree_property[2];

            //takes vertices
            TabObj A = cnn.select_vertex_from_tree_name(tree, vertexA);
            TabObj B = cnn.select_vertex_from_tree_name(tree, vertexB);

            if (A == null || B == null) return null;

            string[] nomi_vertici;
            string[] nomi_attributi_vertici = new string[numero_attributi_vertici];           
            string[] nomi_attributi_archi = new string[numero_attributi_archi];
            string[] somme_attributi_archi = new string[numero_attributi_archi];
            string[] somme_attributi_vertici = new string[numero_attributi_vertici];
            int [] somme_attributi_vertici_int = new int[numero_attributi_vertici];
            int [] somme_attributi_archi_int = new int[numero_attributi_archi];

            //Search for the starting vertex

            if (A.indice > B.indice)
            {
                start = B;
                end = A;
            }
            else
            {
                start = A;
                end = B;
            }

            //builds the where clause for the query

            StringBuilder sbv = new StringBuilder();
            StringBuilder sbe = new StringBuilder();
            int i = end.indice;
            int c;
            sbv.Append("Tree= '" + tree + "' AND (");
            sbe.Append("Tree= '" + tree + "' AND (");
            for (c = 0; i > start.indice; c++)
            {
                sbv.Append("Indice=" + i + " OR ");
                if (c == 0) sbe.Append("Indice=" + (i - 1));
                else sbe.Append(" OR " + "Indice=" + (i - 1));
                i = (int)Math.Ceiling((double)(i - 1) / splitsize);
            }

            //last check;if a path exists the last index will be added

            if (i == start.indice)
            {
                sbv.Append("Indice=" + i + ")");
                sbe.Append(")");
                c++;
            }
            else
            {
                return null;
            }

            //takes the paths

            pathv = cnn.select_vertex_path(sbv.ToString());
            pathe = cnn.select_edge_path(sbe.ToString());

            //check if pathv and pathe aren't null

            if (pathv == null || pathe == null) return null;          
           
            nomi_vertici = new string[c];
            Result r = new Result();

            //instantiate the rulsts

            for (i = 0; i < numero_attributi_vertici; i++)
            {
                nomi_attributi_vertici[i] = pathv[i].attribute_name;
            }
            r.nomi_attributi_vertici = nomi_attributi_vertici;
            int j = 0;
            for (i = 0; i < pathv.Length; i = i + numero_attributi_vertici)
            {
                nomi_vertici[j++] = pathv[i].vertex_name;
            }
            r.nomi_vertici = nomi_vertici;
            for (i = 0; i < pathv.Length; i++)
            {
                if (Int32.TryParse(pathv[i].value, out j))
               somme_attributi_vertici_int[i % numero_attributi_vertici] += j;
                else
                    somme_attributi_vertici[i % numero_attributi_vertici] += pathv[i].value;
            }          
            for (i = 0; i < numero_attributi_archi; i++)
            {
                nomi_attributi_archi[i] = pathe[i].attribute_name;
            }
            r.nomi_attributi_archi = nomi_attributi_archi;
            for (i = 0; i < pathe.Length; i++)
            {
                if (Int32.TryParse(pathe[i].value, out j))
                    somme_attributi_archi_int[i % numero_attributi_archi] += j;
                else
                    somme_attributi_archi[i % numero_attributi_archi] += pathe[i].value;
            }
            //r.somme_attributi_archi = somme_attributi_archi;

            if (somme_attributi_vertici[0] == null) { 
           
                for (i = 0; i < somme_attributi_vertici_int.Length; i++) somme_attributi_vertici[i] = somme_attributi_vertici_int[i].ToString();
            }
            if (somme_attributi_archi[0] == null)
            {

                for (i = 0; i < somme_attributi_archi_int.Length; i++) somme_attributi_archi[i] = somme_attributi_archi_int[i].ToString();
            }
            r.somme_attributi_vertici = somme_attributi_vertici;
            r.somme_attributi_archi = somme_attributi_archi;
            return r;
        }

        /////////////////////////////////////////////////////////////////////////////////////*Change connection string*////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public  bool updateConfigFile(string server, string database, string User_ID, string password)
        {
            try
            {
                // creates the new connection string
                if (server != "" && database != "" && User_ID != "" && password != "")
                {
                    string newconnstr = "Data Source=" + server + ";Initial Catalog=" + database + ";Persist Security Info = False;User ID=" + User_ID + ";Password=" + password;
                    var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
                    connectionStringsSection.ConnectionStrings["PPC"].ConnectionString = newconnstr;
                    config.Save();
                    ConfigurationManager.RefreshSection("connectionStrings");
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static TabObj[] sendAttributes()
        {
            Connection cnn = new Connection();
            return cnn.select_attributes();
        }
        
        public static bool saveAttribute(string name)
        {
            Connection cnn = new Connection();
            return cnn.insert_attribute(name);
        }
    }
}






