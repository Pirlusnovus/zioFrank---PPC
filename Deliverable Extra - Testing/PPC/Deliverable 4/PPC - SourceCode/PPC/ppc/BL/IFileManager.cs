using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPC.Support_Structure;

namespace PPC.BL
{
    interface IFileManager
    {
        bool save_fileTree(Tree albero, string nome);
        Tree file_to_tree(string file);
    }
}
