using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPC.Support_Structure
{
    class Tree
    {
        //class Attributes 

        private int splitsize;
        private int depth;
        private string type;
        private string[] vertex_attributelist;
        private string[] edge_attributelist;
        private Vertex_Edge[] Vertex_EdgeList;

        //constructor

        public Tree(int splitsize, int depth, string type, string[] vertex_attributelist, string[] edge_attributelist, Vertex_Edge[] Vertex_EdgeList)
        {
            this.splitsize = splitsize;
            this.depth = depth;
            this.type = type;
            this.vertex_attributelist = vertex_attributelist;
            this.edge_attributelist = edge_attributelist;
            this.Vertex_EdgeList = Vertex_EdgeList;
        }

        //methods

        public int getSplitsize()
        {
            return this.splitsize;
        }
        public int getDepth()
        {
            return this.depth;
        }
        public string getType()
        {
            return this.type;
        }
        public string[] getVertex_attributelist()
        {
            return this.vertex_attributelist;
        }
        public string[] getEdge_attributelist()
        {
            return this.edge_attributelist;
        }
        public Vertex_Edge[] getVertex_Edge_List()
        {
            return this.Vertex_EdgeList;

        }
        public void stampaAlbero()
        {
            Console.WriteLine(this.getSplitsize());
            Console.WriteLine(this.getDepth());
            Console.WriteLine(this.getType());
            int i = 0;
            foreach (Vertex_Edge oggetto in this.getVertex_Edge_List())
            {
                Console.WriteLine("Valori nodo nome" + this.getVertex_Edge_List()[i].getNome() + ":");
                Console.WriteLine(string.Join(",", this.getVertex_Edge_List()[i].getVertex_Attribute_Value_List()));
                Console.WriteLine("Valori arco " + (i + 1).ToString() + ":");
                Console.WriteLine(string.Join(",", this.getVertex_Edge_List()[i].getEdge_Attribute_Value_List()));
                i++;
            }
        }

    }
}
