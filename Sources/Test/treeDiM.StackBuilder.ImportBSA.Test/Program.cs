using System;
using System.IO;
using System.Collections.Generic;

using Sharp3D.Math.Core;
using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Exporters;

namespace treeDiM.StackBuilder.ImportBSA.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"D:\GitHub\StackBuilder\Sources\Samples\testFGA.csv";
            using (FileStream fs = File.OpenRead(filePath))
            {
                ExporterCSV_TechBSA exporter = new ExporterCSV_TechBSA();

                Vector3D dimCase = Vector3D.Zero;
                Vector3D dimPallet = Vector3D.Zero;
                double weightCase = 0.0, weightPallet = 0.0, maxPalletHeight = 0.0;
                List<BoxPosition> boxPositions = new List<BoxPosition>();
                bool hasInterlayerBottom = false, hasInterlayerTop = false, hasInterlayersMiddle = false, alternateLayers = false;
                ExporterCSV_TechBSA.Import(fs,
                    ref boxPositions,
                    ref dimCase, ref weightCase,
                    ref dimPallet, ref weightPallet,
                    ref maxPalletHeight,
                    ref alternateLayers,
                    ref hasInterlayerBottom, ref hasInterlayerTop, ref hasInterlayersMiddle);

                Console.WriteLine("Box positions:");
                foreach (var bp in boxPositions)
                {
                    Console.WriteLine(bp.ToString());
                }
                Console.WriteLine($"DimCase:{dimCase.ToString()}");
                Console.WriteLine($"WeightCase:{weightCase}");
                Console.WriteLine($"DimPallet:{dimPallet.ToString()}");
                Console.WriteLine($"WeightPallet:{weightPallet}");
                Console.WriteLine($"InterlayerBottom:{hasInterlayerBottom}");
                Console.WriteLine($"InterlayerTop:{hasInterlayerTop}");
                Console.WriteLine($"InterlayerMiddle:{hasInterlayersMiddle}");



            }
        }
    }
}
