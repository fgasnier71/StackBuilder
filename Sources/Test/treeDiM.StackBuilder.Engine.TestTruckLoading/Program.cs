#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.Engine.TestTruckLoading
{
    class Program
    {
        static void Main(string[] args)
        {
            Document doc = new Document("TestTruckLoading", "Test heterogeneous pallet/truck loading", "treeDiM", DateTime.Now, null);

            // build test analysis
            var analysis = new AnalysisHPalletTruck(doc);
            // test column building
            analysis.GeneratePalletColumns();
            // test column sorting

            // test chunk to column

            // test chunk assembly

            // test build solution

            // test draw solution
        }
    }
}
