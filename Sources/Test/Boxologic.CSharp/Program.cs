using System;
using System.Reflection;
using System.IO;

namespace Boxologic.CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                BoxItem[] boxItem = {
                    new BoxItem() { Boxx = 190, Boxy = 200, Boxz = 420, N = 2 },
                    new BoxItem() { Boxx = 250, Boxy = 200, Boxz = 300, N = 1 },
                    new BoxItem() { Boxx = 250, Boxy = 200, Boxz = 250, N = 1 },
                    new BoxItem() { Boxx = 250, Boxy = 200, Boxz = 290, N = 1 },
                    new BoxItem() { Boxx = 80, Boxy = 200, Boxz = 210, N = 4 },
                    new BoxItem() { Boxx = 360, Boxy = 460, Boxz = 840, N = 1 },
                    new BoxItem() { Boxx = 160, Boxy = 460, Boxz = 100, N = 2 },
                    new BoxItem() { Boxx = 160, Boxy = 460, Boxz = 320, N = 2 },
                    new BoxItem() { Boxx = 200, Boxy = 300, Boxz = 150, N = 1 },
                    new BoxItem() { Boxx = 200, Boxy = 300, Boxz = 690, N = 1 },
                    new BoxItem() { Boxx = 200, Boxy = 300, Boxz = 210, N = 4 },
                    new BoxItem() { Boxx = 120, Boxy = 300, Boxz = 70, N = 12 },
                    new BoxItem() { Boxx = 520, Boxy = 600, Boxz = 420, N = 2 },
                    new BoxItem() { Boxx = 260, Boxy = 360, Boxz = 210, N = 4 },
                    new BoxItem() { Boxx = 260, Boxy = 360, Boxz = 840, N = 1 }
                };

                Boxlogic bl = new Boxlogic
                {
                    OutputFilePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "output.txt")
                };
                bl.Run(boxItem, 1200, 1000, 840);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
