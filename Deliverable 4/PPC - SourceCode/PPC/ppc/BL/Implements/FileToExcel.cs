using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPC.Support_Structure;
using Microsoft.Office.Interop.Excel;

namespace PPC.BL.Implements
{
    class FileToExcel : IFileManager
    {
        public bool save_fileTree(Tree albero, string nome)
        {
            //launches the excel application

            Application excel = new Application();

            // controls if excel is installed

            if (excel == null)
            {
                System.Windows.MessageBox.Show("Excel not installed (file .xlsx)");

                return false;
            }

            // instruction for better performance

            excel.DisplayAlerts = false;

            //useful excel variables

            Workbook xlWorkBook;
            Worksheet xlWorkSheet_1;
            Worksheet xlWorkSheet_2;
            Worksheet xlWorkSheet_3;

            //useful variables

            int i;
            int vertex_edge_rows = albero.getVertex_Edge_List().Length;
            int edge_columns = albero.getEdge_attributelist().Length + 1;
            int vertex_columns = albero.getVertex_attributelist().Length + 1;

            if (vertex_edge_rows > 2097150)
            {
                System.Windows.MessageBox.Show("Trying to create a too big tree (2097150 max vertices)");
                return false;
            }

            xlWorkBook = excel.Workbooks.Add(System.Reflection.Missing.Value);

            //creates the right number of worksheets

            switch (xlWorkBook.Worksheets.Count)
            {
                case 1:
                    xlWorkSheet_3 = (Worksheet)xlWorkBook.Worksheets.get_Item(1);
                    xlWorkSheet_2 = (Worksheet)xlWorkBook.Sheets.Add();
                    xlWorkSheet_1 = (Worksheet)xlWorkBook.Sheets.Add();
                    break;
                case 2:
                    xlWorkSheet_2 = (Worksheet)xlWorkBook.Worksheets.get_Item(1);
                    xlWorkSheet_3 = (Worksheet)xlWorkBook.Worksheets.get_Item(2);
                    xlWorkSheet_1 = (Worksheet)xlWorkBook.Sheets.Add();
                    break;
                default:
                    xlWorkSheet_1 = (Worksheet)xlWorkBook.Worksheets.get_Item(1);
                    xlWorkSheet_2 = (Worksheet)xlWorkBook.Worksheets.get_Item(2);
                    xlWorkSheet_3 = (Worksheet)xlWorkBook.Worksheets.get_Item(3);
                    break;
            }

            //sets the first worksheet's columns

            xlWorkSheet_1.Cells[1, 1] = "Splitsize";
            xlWorkSheet_1.Cells[1, 2] = "Depth";
            xlWorkSheet_1.Cells[1, 3] = "Type";
            xlWorkSheet_1.Cells[1, 4] = "Uploadable";
            Range boldRange = xlWorkSheet_1.get_Range("A1", "D1");
            boldRange.Font.Bold = true;

            //sets the first worksheet's values

            xlWorkSheet_1.Cells[2, 1] = albero.getSplitsize();
            xlWorkSheet_1.Cells[2, 2] = albero.getDepth();
            xlWorkSheet_1.Cells[2, 3] = albero.getType();
            xlWorkSheet_1.Cells[2, 4] = false;

            if (vertex_edge_rows > 1048575)
            {
                //sets the second worksheet's columns

                xlWorkSheet_2.Cells[1, 1] = "Vertex";
                xlWorkSheet_2.Cells[1, 1].Font.Bold = true;
                i = 0;
                for (; i < albero.getVertex_attributelist().Length; i++)
                {
                    xlWorkSheet_2.Cells[1, i + 2] = albero.getVertex_attributelist()[i];
                    xlWorkSheet_2.Cells[1, i + 2].Font.Bold = true;
                }

                //sets an empty column

                i += 3;

                //sets the columns of the second part of the second worksheet

                int startpoint_vP2 = i;
                xlWorkSheet_2.Cells[1, i++] = "Vertex_P2";
                xlWorkSheet_2.Cells[1, i - 1].Font.Bold = true;
                for (int j = 0; j < albero.getVertex_attributelist().Length; j++)
                {
                    xlWorkSheet_2.Cells[1, i] = albero.getVertex_attributelist()[j];
                    xlWorkSheet_2.Cells[1, i].Font.Bold = true;
                    i++;
                }
                int endpoint_vP2 = i - 1;

                //sets the third worksheet's columns

                xlWorkSheet_3.Cells[1, 1] = "Edge"; //here we set the index of the edge for better legibility
                xlWorkSheet_3.Cells[1, 1].Font.Bold = true;
                i = 0;
                for (; i < albero.getEdge_attributelist().Length; i++)
                {
                    xlWorkSheet_3.Cells[1, i + 2] = albero.getEdge_attributelist()[i];
                    xlWorkSheet_3.Cells[1, i + 2].Font.Bold = true;
                }
                i += 3;

                //sets the columns of the second part of the third worksheet

                int startpoint_eP2 = i;
                xlWorkSheet_3.Cells[1, i++] = "Edge_P2";
                xlWorkSheet_3.Cells[1, i - 1].Font.Bold = true;
                for (int j = 0; j < albero.getEdge_attributelist().Length; j++)
                {
                    xlWorkSheet_3.Cells[1, i] = albero.getEdge_attributelist()[j];
                    xlWorkSheet_3.Cells[1, i].Font.Bold = true;
                    i++;
                }
                int endpoint_eP2 = i - 1;

                //add data to the second worksheet

                Range beginWrite = (Range)xlWorkSheet_2.Cells[2, 1];
                Range endWrite = (Range)xlWorkSheet_2.Cells[1048576, vertex_columns];
                Range sheetData = xlWorkSheet_2.Range[beginWrite, endWrite];
                sheetData.Value2 = matriceVertex(albero, 0, 1048575, vertex_columns);

                beginWrite = (Range)xlWorkSheet_2.Cells[2, startpoint_vP2];
                endWrite = (Range)xlWorkSheet_2.Cells[(vertex_edge_rows - 1048574), endpoint_vP2];
                sheetData = xlWorkSheet_2.Range[beginWrite, endWrite];
                sheetData.Value2 = matriceVertex(albero, 1048575, vertex_edge_rows - 1048575, vertex_columns);

                //add data to the third worksheet

                beginWrite = (Range)xlWorkSheet_3.Cells[2, 1];
                endWrite = (Range)xlWorkSheet_3.Cells[1048576, edge_columns];
                sheetData = xlWorkSheet_3.Range[beginWrite, endWrite];
                sheetData.Value2 = matriceEdge(albero, 0, 1048575, edge_columns);

                beginWrite = (Range)xlWorkSheet_3.Cells[2, startpoint_eP2];
                endWrite = (Range)xlWorkSheet_3.Cells[vertex_edge_rows - 1048574, endpoint_eP2];
                sheetData = xlWorkSheet_3.Range[beginWrite, endWrite];
                sheetData.Value2 = matriceEdge(albero, 1048575, vertex_edge_rows - 1048575, edge_columns);
            }
            else
            {
                //sets the second worksheet's columns

                xlWorkSheet_2.Cells[1, 1] = "Vertex";
                xlWorkSheet_2.Cells[1, 1].Font.Bold = true;
                i = 0;
                for (; i < albero.getVertex_attributelist().Length; i++)
                {
                    xlWorkSheet_2.Cells[1, i + 2] = albero.getVertex_attributelist()[i];
                    xlWorkSheet_2.Cells[1, i + 2].Font.Bold = true;

                }

                //sets the  third worksheet's columns

                xlWorkSheet_3.Cells[1, 1] = "Edge"; //here we set the index of the edge for better legibility
                xlWorkSheet_3.Cells[1, 1].Font.Bold = true;
                i = 0;
                for (; i < albero.getEdge_attributelist().Length; i++)
                {
                    xlWorkSheet_3.Cells[1, i + 2] = albero.getEdge_attributelist()[i];
                    xlWorkSheet_3.Cells[1, i + 2].Font.Bold = true;
                }

                ////add data to the second worksheet

                Range beginWrite = (Range)xlWorkSheet_2.Cells[2, 1];
                Range endWrite = (Range)xlWorkSheet_2.Cells[vertex_edge_rows + 1, vertex_columns];
                Range sheetData = xlWorkSheet_2.Range[beginWrite, endWrite];
                sheetData.Value2 = matriceVertex(albero, 0, vertex_edge_rows, vertex_columns);

                //add data to the third worksheet

                beginWrite = (Range)xlWorkSheet_3.Cells[2, 1];
                endWrite = (Range)xlWorkSheet_3.Cells[vertex_edge_rows + 1, edge_columns];
                sheetData = xlWorkSheet_3.Range[beginWrite, endWrite];
                sheetData.Value2 = matriceEdge(albero, 0, vertex_edge_rows, edge_columns);
            }


            //coulmn autofit
            xlWorkSheet_1.Cells.EntireColumn.AutoFit();
            xlWorkSheet_2.Cells.EntireColumn.AutoFit();
            xlWorkSheet_3.Cells.EntireColumn.AutoFit();

            //saves the file (overwrites the file if it already exists or cause an exception if it already exists and it's opened)

            try
            {
                xlWorkBook.SaveAs(nome, XlFileFormat.xlWorkbookDefault, null, null, null, null, XlSaveAsAccessMode.xlNoChange, null, null, null, null, null);
            }
            catch (Exception)
            {
                System.Windows.MessageBox.Show("file cannot be saved");
                return false;
            }

            //closes the excel application and releases the excel objects

            xlWorkBook.Close(true, null, null);
            excel.Quit();
            release_object(xlWorkSheet_1);
            release_object(xlWorkSheet_2);
            release_object(xlWorkSheet_3);
            release_object(xlWorkBook);
            release_object(excel);

            return true;
        }



        public Tree file_to_tree(string file)
        {
            //useful excel variables

            Application xlApp;
            Workbook xlWorkBook;
            Worksheet xlWorkSheet1;
            Worksheet xlWorkSheet2;
            Worksheet xlWorkSheet3;

            //useful variables

            Tree albero;
            int depth;
            int splitsize;
            string type;
            string[] vertex_attribute_list;
            string[] edge_attribute_list;
            Vertex_Edge[] vertex_edge_list;

            //launches the excel application

            xlApp = new Application();

            // controls if excel is installed

            if (xlApp == null)
            {
                System.Windows.MessageBox.Show("Excel not installed");
                return null;
            }

            // instruction for better performance

            xlApp.DisplayAlerts = false;

            //opens the file

            xlWorkBook = xlApp.Workbooks.Open(file, 0, true, 5, "", "", true, XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);

            //takes the first worksheet data(tree property)

            xlWorkSheet1 = (Worksheet)xlWorkBook.Worksheets.get_Item(1);
            Range xlWorkSheetT = xlWorkSheet1.UsedRange;
            release_object(xlWorkSheet1);

            //check if the file is uploadable

            if (Boolean.Equals(false, xlWorkSheetT.Cells[2, 4].Value))
            {
                System.Windows.MessageBox.Show("File cannot be uploaded, check the uploadable field in the file");
                return null;
            }

            //stores tree property

            splitsize = (int)xlWorkSheetT.Cells[2, 1].Value;
            depth = (int)xlWorkSheetT.Cells[2, 2].Value;
            type = xlWorkSheetT.Cells[2, 3].Value;
            release_object(xlWorkSheetT);

            //find and check the number of tree's vertices and ch

            int cardinalità = ((int)Math.Pow(splitsize, depth + 1) - 1) / (splitsize - 1);
            if (cardinalità <= 1048575)
            {
                //takes the second worksheet

                xlWorkSheet2 = (Worksheet)xlWorkBook.Worksheets.get_Item(2);
                Range xlWorkSheetV = xlWorkSheet2.UsedRange;
                release_object(xlWorkSheet2);

                //takes the attributes of the vertices

                vertex_attribute_list = new string[xlWorkSheetV.Columns.Count - 1];
                for (int i = 0; i < vertex_attribute_list.Length; i++)
                    vertex_attribute_list[i] = xlWorkSheetV.Cells[1, i + 2].Value;

                //takes the third worksheet

                xlWorkSheet3 = (Worksheet)xlWorkBook.Worksheets.get_Item(3);
                Range xlWorkSheetE = xlWorkSheet3.UsedRange;
                release_object(xlWorkSheet3);

                //takes the attributes of the edges 

                edge_attribute_list = new string[xlWorkSheetE.Columns.Count - 1];
                for (int i = 0; i < edge_attribute_list.Length; i++)
                    edge_attribute_list[i] = xlWorkSheetE.Cells[1, i + 2].Value;

                //Creates the vertices/edges array

                vertex_edge_list = new Vertex_Edge[xlWorkSheetV.Rows.Count - 1];

                //creates the tree object

                albero = new Tree(splitsize, depth, type, vertex_attribute_list, edge_attribute_list, vertex_edge_list);

                //creates matrices in order to store the data from the file

                var matriceV = new object[xlWorkSheetV.Rows.Count - 1, xlWorkSheetV.Columns.Count];
                var matriceE = new object[xlWorkSheetE.Rows.Count - 1, xlWorkSheetE.Columns.Count - 1];

                //fills the vertices matrix with data

                Range dataV = xlWorkSheetV.Offset[1, 0].Resize[xlWorkSheetV.Rows.Count - 1, xlWorkSheetV.Columns.Count];
                matriceV = dataV.Value2;

                //fills the edges matrix with data

                Range dataE = xlWorkSheetE.Offset[1, 1].Resize[xlWorkSheetE.Rows.Count - 1, xlWorkSheetE.Columns.Count - 1];
                matriceE = dataE.Value2;

                //fills the tree object

                for (int i = 0; i < albero.getVertex_Edge_List().Length; i++)
                {
                    albero.getVertex_Edge_List().SetValue(new Vertex_Edge((string)matriceV[i + 1, 1], new string[xlWorkSheetV.Columns.Count - 1], new string[xlWorkSheetE.Columns.Count - 1]), i);
                    for (int j = 0; j < albero.getVertex_Edge_List()[i].getVertex_Attribute_Value_List().Length; j++)
                    {
                        albero.getVertex_Edge_List()[i].getVertex_Attribute_Value_List()[j] = matriceV[i + 1, j + 2].ToString();
                    }
                    for (int j = 0; j < albero.getVertex_Edge_List()[i].getEdge_Attribute_Value_List().Length; j++)
                    {
                        if (matriceE[i + 1, j + 1] != null)
                            albero.getVertex_Edge_List()[i].getEdge_Attribute_Value_List()[j] = matriceE[i + 1, j + 1].ToString();
                    }
                }


                //closes the excel application and releases the excel objects

                xlWorkBook.Close(true, null, null);
                xlApp.Quit();
                release_object(dataV);
                release_object(dataE);
                release_object(xlWorkSheetT);
                release_object(xlWorkSheetV);
                release_object(xlWorkSheetE);
                release_object(xlWorkBook);
                release_object(xlApp);

                return albero;
            }
            else
            {
                int i = 0;

                //takes the second worksheet

                xlWorkSheet2 = (Worksheet)xlWorkBook.Worksheets.get_Item(2);
                Range xlWorkSheetV = xlWorkSheet2.UsedRange;

                //sets useful variables

                int numero_attributi_vertici = (xlWorkSheetV.Columns.Count - 3) / 2;
                int numero_colonne_totali_foglio_vertici = xlWorkSheetV.Columns.Count;

                //takes the attributes of the vertices

                vertex_attribute_list = new string[numero_attributi_vertici];
                for (i = 0; i < vertex_attribute_list.Length; i++)
                    vertex_attribute_list[i] = xlWorkSheetV.Cells[1, i + 2].Value;
                release_object(xlWorkSheetV);

                //takes the third worksheet

                xlWorkSheet3 = (Worksheet)xlWorkBook.Worksheets.get_Item(3);
                Range xlWorkSheetE = xlWorkSheet3.UsedRange;

                //sets useful variables

                int numero_attributi_archi = (xlWorkSheetE.Columns.Count - 3) / 2;
                int numero_colonne_totali_foglio_archi = xlWorkSheetE.Columns.Count;

                //takes the attributes of the edges

                edge_attribute_list = new string[numero_attributi_archi];
                for (i = 0; i < edge_attribute_list.Length; i++)
                    edge_attribute_list[i] = xlWorkSheetE.Cells[1, i + 2].Value;
                release_object(xlWorkSheetE);

                //Creates the vertices/edges array

                vertex_edge_list = new Vertex_Edge[cardinalità];

                //creates the tree object

                albero = new Tree(splitsize, depth, type, vertex_attribute_list, edge_attribute_list, vertex_edge_list);

                //creates matrices in order to store the data from the file

                var matriceV1 = new object[1048575, numero_attributi_vertici + 1];
                var matriceE1 = new object[1048575, numero_attributi_archi];
                var matriceV2 = new object[(cardinalità - 1048576), numero_attributi_vertici + 1];
                var matriceE2 = new object[(cardinalità - 1048576), numero_attributi_archi];

                //fills vertices matrices with data 

                Range beginWrite = (Range)xlWorkSheet2.Cells[2, 1];
                Range endWrite = (Range)xlWorkSheet2.Cells[1048576, numero_attributi_vertici + 1];
                Range sheetData = xlWorkSheet2.Range[beginWrite, endWrite];
                matriceV1 = sheetData.Value2;

                beginWrite = (Range)xlWorkSheet2.Cells[2, numero_attributi_vertici + 3];
                endWrite = (Range)xlWorkSheet2.Cells[cardinalità - 1048574, 11];
                sheetData = xlWorkSheet2.Range[beginWrite, endWrite];
                matriceV2 = sheetData.Value2;
                release_object(xlWorkSheet2);

                //fills edges matrices with data 

                beginWrite = (Range)xlWorkSheet3.Cells[2, 2];
                endWrite = (Range)xlWorkSheet3.Cells[1048576, numero_attributi_archi + 1];
                sheetData = xlWorkSheet3.Range[beginWrite, endWrite];
                matriceE1 = sheetData.Value2;

                beginWrite = (Range)xlWorkSheet3.Cells[2, numero_attributi_archi + 4];
                endWrite = (Range)xlWorkSheet3.Cells[cardinalità - 1048574, 9];
                sheetData = xlWorkSheet3.Range[beginWrite, endWrite];
                matriceE2 = sheetData.Value2;
                release_object(xlWorkSheet3);

                //fills the tree object

                for (i = 0; i < 1048575; i++)
                {
                    albero.getVertex_Edge_List().SetValue(new Vertex_Edge((string)matriceV1[i + 1, 1], new string[numero_attributi_vertici], new string[numero_attributi_archi]), i);
                    for (int j = 0; j < numero_attributi_vertici; j++)
                    {
                        albero.getVertex_Edge_List()[i].getVertex_Attribute_Value_List()[j] = matriceV1[i + 1, j + 2].ToString();
                    }
                    for (int j = 0; j < numero_attributi_archi; j++)
                    {
                        if (matriceE1[i + 1, j + 1] == null)
                        {
                            albero.getVertex_Edge_List()[i].getEdge_Attribute_Value_List()[j] = "NULL";
                            System.Windows.MessageBox.Show("arco null");
                        }
                        else {
                            albero.getVertex_Edge_List()[i].getEdge_Attribute_Value_List()[j] = matriceE1[i + 1, j + 1].ToString();
                        }
                    }
                }
                for (int c = 0; i < cardinalità; c++)
                {
                    albero.getVertex_Edge_List().SetValue(new Vertex_Edge((string)matriceV2[c + 1, 1], new string[numero_attributi_vertici], new string[numero_attributi_archi]), i);
                    for (int j = 0; j < numero_attributi_vertici; j++)
                    {
                        albero.getVertex_Edge_List()[i].getVertex_Attribute_Value_List()[j] = matriceV2[c + 1, j + 2].ToString();
                    }
                    for (int j = 0; j < numero_attributi_archi; j++)
                    {
                        if (matriceE1[c + 1, j + 1] != null)
                            albero.getVertex_Edge_List()[i].getEdge_Attribute_Value_List()[j] = matriceE2[c + 1, j + 1].ToString();
                    }
                    i++;
                }

                //closes the excel application and releases the excel objects

                xlWorkBook.Close(true, null, null);
                xlApp.Quit();
                release_object(xlWorkBook);
                release_object(xlApp);

                return albero;
            }
        }

        ///////////////////////////////////////////////////////////////////////////////method for the release of excel objects////////////////////////////////////////////////////////////////////////////////////

        public void release_object(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                Console.WriteLine("Eccezione durante il rilascio dell'oggetto: " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        ///////////////////////////////////////////////////////////////////////////method for filling a matrix with vertices values///////////////////////////////////////////////////////////////////////////

        private object[,] matriceVertex(Tree albero, int i, int numRow, int numCol)
        {
            var matrice = new object[numRow, numCol];
            for (int c = 0; c < numRow; c++)
            {
                matrice[c, 0] = albero.getVertex_Edge_List()[i].getNome();
                for (int j = 0; j < numCol - 1; j++)
                    matrice[c, j + 1] = albero.getVertex_Edge_List()[i].getVertex_Attribute_Value_List()[j];
                i++;
            }
            return matrice;
        }

        ///////////////////////////////////////////////////////////////////////////method for filling a matrix with edges values///////////////////////////////////////////////////////////////////////////

        private object[,] matriceEdge(Tree albero, int i, int numRow, int numCol)
        {
            var matrice = new object[numRow, numCol];
            for (int c = 0; c < numRow; c++)
            {
                matrice[c, 0] = i;
                for (int j = 0; j < numCol - 1; j++)
                    matrice[c, j + 1] = albero.getVertex_Edge_List()[i].getEdge_Attribute_Value_List()[j];
                i++;
            }
            return matrice;
        }
    }
}
