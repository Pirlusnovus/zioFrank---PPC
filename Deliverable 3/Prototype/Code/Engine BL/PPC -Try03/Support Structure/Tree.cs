using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PPC___Try03.Support_Structure
{
    class Tree
    {
        /* ATTRIBUTI DELLA CLASSE */
        private int splitsize;
        private int depth;
        private string type;
        private string[] vertex_attributelist;
        private string[] edge_attributelist;
        private Vertex_Edge[] Vertex_EdgeList;

        /* METODI DELLA CLASSE */
        public Tree(int splitsize, int depth, string type, string[] vertex_attributelist, string[] edge_attributelist, Vertex_Edge[] Vertex_EdgeList)
        {
            this.splitsize = splitsize;
            this.depth = depth;
            this.type = type;
            this.vertex_attributelist = vertex_attributelist;
            this.edge_attributelist = edge_attributelist;
            this.Vertex_EdgeList = Vertex_EdgeList;
        }

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

        public static int random(int n, int k)
        {
            Random random = new Random();
            if (n >= k)
                return random.Next(k, n);
            else return random.Next(n, k);
        }

        public static string inString(int x)
        {
            return x.ToString();
        }

    }

}

    
       

