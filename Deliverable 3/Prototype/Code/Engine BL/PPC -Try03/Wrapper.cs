using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Questo è l'entry point del nostro BL*/
namespace PPC___Try03.BL
{
    class Wrapper
    {
        /*Qui chiama Uploader*/

        class callUploader
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Qui si chiama Uploader");
                Console.ReadLine();
            }
        }

        /*Qui chiama Creator*/

        class callCreator
        {

            static void Main(string[] args)
            {

                 Console.WriteLine("Qui si chiama Creator");
                Console.ReadLine();

            }
        }

       

  

        /*Qui chiama Calculator*/
        class callCalculator
        {
            static void Main(string[] args)
                
            {

                Console.WriteLine("Qui si chiama Calculator");
                Console.ReadLine();
            }
        }
    }
}
