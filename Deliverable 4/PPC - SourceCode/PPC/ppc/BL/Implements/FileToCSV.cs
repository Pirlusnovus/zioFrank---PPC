using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPC.Support_Structure;
using Microsoft.VisualBasic.FileIO;
using System.IO;

namespace PPC.BL.Implements
{
    class FileToCSV : IFileManager
    {
        public bool save_fileTree(Tree albero, string nome)
        {
            string filePath = nome;

            try
            {
                //creates the file if it doesn't already exists

                if (!File.Exists(filePath))
                {
                    File.Create(filePath).Close();
                }
                else
                {
                    System.Windows.MessageBox.Show("File already exists (Change Tree's type)");
                    return false;
                }

                //set delimiter for CSV file

                string delimiter = ",";

                //creates the data

                StringBuilder sb = new StringBuilder();
                sb.Append(albero.getType() + ",");
                sb.Append(albero.getDepth().ToString() + ",");
                sb.Append(albero.getSplitsize().ToString() + ",");
                sb.AppendLine("FALSO");
                sb.AppendLine(string.Join(delimiter, albero.getVertex_attributelist()));
                sb.AppendLine(string.Join(delimiter, albero.getEdge_attributelist()));
                for (int index = 0; index < albero.getVertex_Edge_List().Length; index++)
                {
                    sb.AppendLine(albero.getVertex_Edge_List()[index].getNome());
                    sb.AppendLine(string.Join(delimiter, albero.getVertex_Edge_List()[index].getVertex_Attribute_Value_List()));
                    sb.AppendLine(string.Join(delimiter, albero.getVertex_Edge_List()[index].getEdge_Attribute_Value_List()));
                }

                //stores the data in the file

                File.AppendAllText(filePath, sb.ToString());

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }


        public Tree file_to_tree(string file)
        {
            //declarations of variables for tree object constructor

            string[] vertex_attribute_list;
            string[] edge_attribute_list;
            string[] valori_albero;
            Tree albero = null;
            try
            {
                //parses the file 
                using (TextFieldParser csvReader = new TextFieldParser(file))
                {
                    csvReader.SetDelimiters(new string[] { "," });
                    csvReader.HasFieldsEnclosedInQuotes = false;
                    csvReader.CommentTokens = new string[] { "#" };
                    valori_albero = csvReader.ReadFields();
                    if (String.Equals(valori_albero[3], "FALSO"))
                    {                      
                        return albero;
                    }

                    //creates the tree object 

                    string type = valori_albero[0];
                    int depth = Convert.ToInt32(valori_albero[1]);
                    int splitsize = Convert.ToInt32(valori_albero[2]);
                    vertex_attribute_list = csvReader.ReadFields();
                    edge_attribute_list = csvReader.ReadFields();
                    int cardinalità = ((int)Math.Pow(splitsize, depth + 1) - 1) / (splitsize - 1);
                    albero = new Tree(splitsize, depth, type, vertex_attribute_list, edge_attribute_list, new Vertex_Edge[cardinalità]);

                    //fills the tree object with data
                    for (int i = 0; i < cardinalità && !csvReader.EndOfData; i++)
                        albero.getVertex_Edge_List()[i] = new Vertex_Edge(csvReader.ReadLine(), csvReader.ReadFields(), csvReader.ReadFields());

                    return albero;
                }

            }

            catch (Exception)
            {
                return null;
            }

        }

    }
}
