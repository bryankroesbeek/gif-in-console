using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GifInConsole
{
    class Program
    {
        const string WhiteToBlack = " .:-=+*#%@";

        static void Main(string[] args)
        {
            if (args.Length != 1) return;

            // This should be the pathname of the gif that one wants to view in the console
            string path = args[0];

            GicConsole console = new GicConsole(path);
            console.Run();
        }
    }
}