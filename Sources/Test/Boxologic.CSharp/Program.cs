using System;

namespace Boxologic.CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                BoxItem[] boxItem = {
                    new BoxItem() { Boxx = 19, Boxy = 20, Boxz = 42, N = 2 },
                    new BoxItem() { Boxx = 25, Boxy = 20, Boxz = 30, N = 1 },
                    new BoxItem() { Boxx = 25, Boxy = 20, Boxz = 25, N = 1 },
                    new BoxItem() { Boxx = 25, Boxy = 20, Boxz = 29, N = 1 },
                    new BoxItem() { Boxx = 8, Boxy = 20, Boxz = 21, N = 4 },
                    new BoxItem() { Boxx = 36, Boxy = 46, Boxz = 84, N = 1 },
                    new BoxItem() { Boxx = 16, Boxy = 46, Boxz = 10, N = 2 },
                    new BoxItem() { Boxx = 16, Boxy = 46, Boxz = 32, N = 2 },
                    new BoxItem() { Boxx = 20, Boxy = 30, Boxz = 15, N = 1 },
                    new BoxItem() { Boxx = 20, Boxy = 30, Boxz = 69, N = 1 },
                    new BoxItem() { Boxx = 20, Boxy = 30, Boxz = 21, N = 4 },
                    new BoxItem() { Boxx = 12, Boxy = 30, Boxz = 7, N = 12 },
                    new BoxItem() { Boxx = 52, Boxy = 60, Boxz = 42, N = 2 },
                    new BoxItem() { Boxx = 26, Boxy = 36, Boxz = 21, N = 4 },
                    new BoxItem() { Boxx = 26, Boxy = 36, Boxz = 84, N = 1 }
                };

                Boxlogic bl = new Boxlogic();
                bl.Run(boxItem, 104.0, 96.0, 84.0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
