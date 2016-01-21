using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPC___Try03.Support_Structure
{
    class Vertex_Edge
    {

        private string nome;
        private string[] vertex_attribute_value_list;
        private string[] edge_attribute_value_list;

        public Vertex_Edge(string nome, string[] vertex_attribute_value_list, string[] edge_attribute_value_list)
        {
            this.nome = nome;
            this.vertex_attribute_value_list = vertex_attribute_value_list;
            this.edge_attribute_value_list = edge_attribute_value_list;
        }

        public string getNome()
        {
            return this.nome;
        }

        public string[] getVertex_Attribute_Value_List()
        {
            return this.vertex_attribute_value_list;
        }

        public string[] getEdge_Attribute_Value_List()
        {
            return this.edge_attribute_value_list;
        }



    }
}
