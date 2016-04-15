using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using PPC.Support_Structure;

namespace PPC.BL
{
    interface IDBManager
    {
        bool insert_tree(Tree albero);
        int[] select_tree_property(string tree);
        Guid insert_vertex(Vertex_Edge vertex, string Tree, int index);
        TabObj select_vertex_from_tree_name(string tree, string name);
        TabObj select_vertex_from_tree_indice(string tree, int indice);
        Guid insert_edge(string tree, int index);
        TabObj select_edge(int indice, string tree);
        bool insert_attribute(string name);
        TabObj[] select_attributes();
        bool insert_vertex_attributes(Tree albero);
        bool insert_edge_attributes(Tree albero);
        TabPath[] select_vertex_path(string clausola);
        TabPath[] select_edge_path(string clausola);
    }
}
