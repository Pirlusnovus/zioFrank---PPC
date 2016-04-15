using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPC.Support_Structure;

namespace PPC
{
    interface IEngine
    {

        bool Uploader(string file);

        Result Calculator(string tree, string vertexA, string vertexB);
 
        bool updateConfigFile(string server, string database, string User_ID, string password);
     
    }
}
