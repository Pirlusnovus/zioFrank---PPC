using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows;
using PPC.Support_Structure;

namespace PPC.BL.Implements
{
    class Connection : IDBManager
    {
        //insert query for the tree table
        public bool insert_tree(Tree albero)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["PPC"].ConnectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO Tree (Type, Depth, Splitsize, NumAttrVertex, NumAttrEdge) VALUES(@param1,@param2,@param3,@param4,@param5)", cnn))
                    {
                        cmd.Parameters.AddWithValue("@param1", albero.getType());
                        cmd.Parameters.AddWithValue("@param2", albero.getDepth());
                        cmd.Parameters.AddWithValue("@param3", albero.getSplitsize());
                        cmd.Parameters.AddWithValue("@param4", albero.getVertex_attributelist().Length);
                        cmd.Parameters.AddWithValue("@param5", albero.getEdge_attributelist().Length);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("cannot insert the tree!(check connection parameters)");
                return false;
            }
        }

        //select tree's property from the tree table
        public int[] select_tree_property(string tree)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["PPC"].ConnectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(" SELECT Splitsize, NumAttrVertex, NumAttrEdge FROM Tree WHERE Type=@param1", cnn))
                    {
                        cmd.Parameters.AddWithValue("@param1", tree);

                        //invokes the reader

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (!reader.HasRows)
                            {
                                MessageBox.Show("cannot find the tree: " + tree);
                                return null;
                            }
                            int[] tree_property = new int[3];
                            while (reader.Read())
                            {
                                tree_property[0] = reader.GetInt32(0);
                                tree_property[1] = reader.GetInt32(1);
                                tree_property[2] = reader.GetInt32(2);
                            }
                            return tree_property;
                        }
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        //insert query for the vertex table (returns the identifier of the inserted vertex)
        public Guid insert_vertex(Vertex_Edge vertex, string Tree, int index)
        {
            try
            {
                Guid id;
                using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["PPC"].ConnectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(" INSERT INTO Vertex (Tree, Name, Indice) OUTPUT INSERTED.VertexUid VALUES(@param1,@param2,@param3)", cnn))
                    {
                        cmd.Parameters.AddWithValue("@param1", Tree);
                        cmd.Parameters.AddWithValue("@param2", vertex.getNome());
                        cmd.Parameters.AddWithValue("@param3", index);
                        id = (Guid)cmd.ExecuteScalar();
                    }
                }
                return id;
            }
            catch (Exception)
            {
                MessageBox.Show("cannot insert vertex with index " + index + "(check connection parameters)");
                return Guid.Empty;
            }
        }

        //select a vertex with tree's name and vertex name from vertex table
        public TabObj select_vertex_from_tree_name(string tree, string name)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["PPC"].ConnectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Vertex WHERE Tree=@tree AND Name=@Name", cnn))
                    {
                        cmd.Parameters.AddWithValue("@tree", tree);
                        cmd.Parameters.AddWithValue("@name", name);

                        //invokes the reader

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (!reader.HasRows)
                            {
                                MessageBox.Show("cannot find vertex with name: " + name);
                                return null;
                            }
                            var row = new TabObj();
                            while (reader.Read())
                            {
                                row.idoggetto = reader.GetGuid(0);
                                row.name = reader.GetString(1);
                                row.Tree = reader.GetString(2);
                                row.indice = reader.GetInt32(3);
                            }
                            return row;
                        }

                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("cannot find vertex with name: " + name + "(check connection parameters)");
                return null;
            }


        }

        //select a vertex with tree's name and vertex index from vertex table
        public TabObj select_vertex_from_tree_indice(string tree, int indice)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["PPC"].ConnectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Vertex WHERE Tree=@tree AND Indice=@indice", cnn))
                    {
                        cmd.Parameters.AddWithValue("@tree", tree);
                        cmd.Parameters.AddWithValue("@indice", indice);

                        //invokes the reader

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (!reader.HasRows)
                            {
                                MessageBox.Show("cannot find vertex with index: " + indice);
                                return null;
                            }
                            var row = new TabObj();
                            while (reader.Read())
                            {
                                row.idoggetto = reader.GetGuid(0);
                                row.name = reader.GetString(1);
                                row.Tree = reader.GetString(2);
                                row.indice = reader.GetInt32(3);
                            }
                            return row;
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("cannot find vertex with index: " + indice + "(check connection parameters)");
                return null;
            }
        }

        //insert query for the edge table (returns the identifier of the inserted edge)
        public Guid insert_edge(string tree, int index)
        {
            try
            {
                Guid id;
                using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["PPC"].ConnectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(" INSERT INTO Edge (Indice,Tree) OUTPUT INSERTED.EdgeUid VALUES(@param1,@param2)", cnn))
                    {
                        cmd.Parameters.AddWithValue("@param1", index);
                        cmd.Parameters.AddWithValue("@param2", tree);
                        id = (Guid)cmd.ExecuteScalar();
                    }
                }
                return id;
            }
            catch (Exception)
            {
                MessageBox.Show("cannot insert edge with index " + index + "(check connection parameters)");
                return Guid.Empty;
            }

        }

        //select an edge with tree's name and edge index from edge table
        public TabObj select_edge(int indice, string tree)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["PPC"].ConnectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Edge WHERE Indice=@indice AND Tree=@tree", cnn))
                    {
                        cmd.Parameters.AddWithValue("@tree", tree);
                        cmd.Parameters.AddWithValue("@indice", indice);

                        // Invokes the reader

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (!reader.HasRows)
                            {
                                MessageBox.Show("Cannot find edge with index: " + indice);
                                return null;
                            }
                            var row = new TabObj();
                            while (reader.Read())
                            {
                                row.idoggetto = reader.GetGuid(0);
                                row.indice = reader.GetInt32(1);
                                row.Tree = reader.GetString(2);
                            }
                            return row;
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Cannot find the edge with index: " + indice + "(controllare la stringa di connessione)");
                return null;
            }
        }

        //Insert attribute in Attrdef table
        public bool insert_attribute(string name)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["PPC"].ConnectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(" INSERT INTO AttrDef (Name) VALUES(@param1)", cnn))
                    {
                        cmd.Parameters.AddWithValue("@param1", name);

                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        //select all the attributes from the attrdef table
        public TabObj[] select_attributes()
        {
            TabObj[] allRecords = null;
            try
            {
                using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["PPC"].ConnectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM AttrDef", cnn))
                    {
                        // Invokes the reader

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            var list = new List<TabObj>();
                            while (reader.Read())
                                list.Add(new TabObj { idoggetto = reader.GetGuid(0), name = reader.GetString(1) });
                            allRecords = list.ToArray();
                            return allRecords;
                        }
                        }
                }
            }
            catch (Exception)
            {
                return allRecords;
            }
        }

        //insert the vertices and vertices attributes in the DB
        public bool insert_vertex_attributes(Tree albero)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["PPC"].ConnectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(" INSERT INTO AttrVertexUsage (ObjectVertexUid, AttrDefVertexUid, Value)  VALUES(@param1,@param2,@param3)", cnn))
                    {
                        TabObj[] attributi = select_attributes();
                        Guid[] id_attributi = new Guid[albero.getVertex_attributelist().Length];
                        for (int i = 0; i < id_attributi.Length; i++)
                        {
                            for (int j = 0; j < attributi.Length; j++)
                            {
                                if (String.Equals(albero.getVertex_attributelist()[i], attributi[j].name))
                                {
                                    id_attributi[i] = attributi[j].idoggetto;
                                    j = attributi.Length;
                                }
                            }
                        }
                        Guid id = new Guid();
                        cmd.Parameters.Add("@param1", SqlDbType.UniqueIdentifier, 16);
                        cmd.Parameters.Add("@param2", SqlDbType.UniqueIdentifier, 16);
                        cmd.Parameters.Add("@param3", SqlDbType.VarChar, 100);
                        for (int i = 0; i < albero.getVertex_Edge_List().Length; i++)
                        {
                            id = insert_vertex(albero.getVertex_Edge_List()[i], albero.getType(), i + 1);
                            cmd.Parameters["@param1"].Value = id;
                            for (int j = 0; j < id_attributi.Length; j++)
                            {
                                cmd.Parameters["@param2"].Value = id_attributi[j];
                                cmd.Parameters["@param3"].Value = albero.getVertex_Edge_List()[i].getVertex_Attribute_Value_List()[j];
                                cmd.ExecuteNonQuery();
                            }
                        }
                        return true;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("cannot insert vertices attributes(check connection parameters)");
                return false;
            }
        }

        //insert the edges and edges attributes in the DB
        public bool insert_edge_attributes(Tree albero)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["PPC"].ConnectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(" INSERT INTO AttrEdgeUsage (ObjectEdgeUid, AttrDefEdgeUid, Value)  VALUES(@param1,@param2,@param3)", cnn))
                    {
                        TabObj[] attributi = select_attributes();
                        Guid[] id_attributi = new Guid[albero.getEdge_attributelist().Length];
                        for (int i = 0; i < id_attributi.Length; i++)
                        {
                            for (int j = 0; j < attributi.Length; j++)
                            {
                                if (String.Equals(albero.getEdge_attributelist()[i], attributi[j].name))
                                {
                                    id_attributi[i] = attributi[j].idoggetto;
                                    j = attributi.Length;
                                }
                            }
                        }
                        Guid id = new Guid();
                        cmd.Parameters.Add("@param1", SqlDbType.UniqueIdentifier, 16);
                        cmd.Parameters.Add("@param2", SqlDbType.UniqueIdentifier, 16);
                        cmd.Parameters.Add("@param3", SqlDbType.VarChar, 100);
                        for (int i = 1; i < albero.getVertex_Edge_List().Length; i++)
                        {
                            id = insert_edge(albero.getType(), i);
                            cmd.Parameters["@param1"].Value = id;
                            for (int j = 0; j < id_attributi.Length; j++)
                            {
                                cmd.Parameters["@param2"].Value = id_attributi[j];
                                cmd.Parameters["@param3"].Value = albero.getVertex_Edge_List()[i].getEdge_Attribute_Value_List()[j];
                                cmd.ExecuteNonQuery();
                            }
                        }
                        return true;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("cannot insert edges attributes(check connection parameters)");
                return false;
            }

        }

        //select a vertices path in the tree with a where clause
        public TabPath[] select_vertex_path(string clausola)
        {
            TabPath[] path = null;
            try
            {
                using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["PPC"].ConnectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT VertexUid, Vertex.Name,Value, AttrDef.Name FROM Vertex LEFT JOIN AttrVertexUsage ON  VertexUid=ObjectVertexUid LEFT JOIN AttrDef ON AttrDefVertexUid=AttrDefUid WHERE " + clausola+ " ORDER BY Indice DESC", cnn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            var list = new List<TabPath>();
                            while (reader.Read())
                                list.Add(new TabPath { idoggetto = reader.GetGuid(0), vertex_name = reader.GetString(1), value = reader.GetString(2), attribute_name = reader.GetString(3) });
                            path = list.ToArray();
                            return path;
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("cannot find the vertices path(check connection parameters)");
                return null;
            }
        }


        //select an edges path in the tree with a where clause
        public TabPath[] select_edge_path(string clausola)
        {
            TabPath[] path = null;
            try
            {
                using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["PPC"].ConnectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT EdgeUid, Value, AttrDef.Name FROM Edge LEFT JOIN AttrEdgeUsage ON  EdgeUid=ObjectEdgeUid LEFT JOIN AttrDef ON AttrDefEdgeUid=AttrDefUid WHERE " + clausola+ " ORDER BY Indice DESC", cnn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            var list = new List<TabPath>();
                            while (reader.Read())
                                list.Add(new TabPath { idoggetto = reader.GetGuid(0), value = reader.GetString(1), attribute_name = reader.GetString(2) });
                            path = list.ToArray();
                            return path;
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("cannot find the edges path(check connection parameters)");
                return null;
            }
        }
    }
}
