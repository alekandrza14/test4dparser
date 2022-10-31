using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _4d_parser;
using System.IO;

namespace _4d_test
{
    class Program
    {
        static public format_4d f4 = new format_4d();
        static void Main(string[] args)
        {
            string[] path = new string[]
            {
                "cube_layer_4.obj",
                "cube_layer_3.obj",
                "cube_layer_2.obj",
                "cube_layer_1.obj",
                "cube_layer_2.obj",
                "cube_layer_3.obj",
                "cube_layer_4.obj"
            };
            f4.loadobjs(path);
            Console.WriteLine(f4.objs.Count());
            Console.WriteLine(f4.objs[0].objstring);
            Console.WriteLine("gotovo?");
            Console.ReadLine(); 
            Console.WriteLine("gotovo");
            Console.ReadLine();
            f4.save("spherecube");
            Console.WriteLine("gotovo");
            Console.ReadLine();
            Console.WriteLine("load");
            f4.load("spherecube.4d");
            Console.WriteLine(f4.objs[0].objstring);
            Console.WriteLine("gotovo?"); 
            Console.ReadLine();
        }
    }
}
