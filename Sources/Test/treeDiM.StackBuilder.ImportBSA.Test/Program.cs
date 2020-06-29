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
                bool layerMirrorX = false, layerMirrorY = false;
                List<bool> interlayers = new List<bool>();
                ExporterCSV_TechBSA.Import(fs,
                    ref boxPositions,
                    ref dimCase, ref weightCase,
                    ref dimPallet, ref weightPallet,
                    ref maxPalletHeight,
                    ref layerMirrorX, ref layerMirrorY,
                    ref interlayers);

                Console.WriteLine("Box positions:");
                foreach (var bp in boxPositions)
                {
                    Console.WriteLine(bp.ToString());
                }
                Console.WriteLine($"DimCase:{dimCase}");
                Console.WriteLine($"WeightCase:{weightCase}");
                Console.WriteLine($"DimPallet:{dimPallet}");
                Console.WriteLine($"WeightPallet:{weightPallet}");



            }
        }
    }
}
