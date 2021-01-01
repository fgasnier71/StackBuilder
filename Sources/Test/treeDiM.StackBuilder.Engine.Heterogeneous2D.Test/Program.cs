#region Using directives
using System;
#endregion

namespace treeDiM.StackBuilder.Engine.Heterogeneous2D.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            int binWidth = 128, binHeight = 128;

            // 256 256 30 20 50 20 10 80 90 20 90 20
            RectSize[] rectSizes = {
                new RectSize(30, 20),
                new RectSize(50, 20),
                new RectSize(10, 80),
                new RectSize(90, 20),
                new RectSize(90, 20)
            };

            Console.WriteLine("### MaxRectsBinPack ###");
            MaxRectsBinPack bin = new MaxRectsBinPack();
            bin.Init(binWidth, binHeight);
            foreach (var rectSize in rectSizes)
            {
                Rect rect = bin.Insert(rectSize.Width, rectSize.Height, MaxRectsBinPack.FreeRectChoiceHeuristic.RectBestAreaFit);
                if (0 != rect.Height)
                    Console.WriteLine($"Rect -> X={rect.X}, Y={rect.Y}, Width={rect.Width}, Height={rect.Height}, Free space left={100.0f * (1.0f - bin.Occupancy)}");
                else
                    Console.WriteLine($"Failed! -> Width = {rectSize.Width}, Height = {rectSize.Height}");
            }

            Console.WriteLine("### GuillotineBinPack ###");
            GuillotineBinPack binGuillotine = new GuillotineBinPack();
            binGuillotine.Init(binWidth, binHeight);
            foreach (var rectSize in rectSizes)
            {
                Rect rect = binGuillotine.Insert(rectSize.Width, rectSize.Height, true, GuillotineBinPack.FreeRectChoiceHeuristic.RectBestAreaFit, GuillotineBinPack.GuillotineSplitHeuristic.SplitLongerAxis);
                if (0 != rect.Height)
                    Console.WriteLine($"Rect -> X={rect.X}, Y={rect.Y}, Width={rect.Width}, Height={rect.Height}, Free space left={100.0f * (1.0f - binGuillotine.Occupancy)}");
                else
                    Console.WriteLine($"Failed! -> Width = {rectSize.Width}, Height = {rectSize.Height}");
            }

            Console.WriteLine("### ShelfBinPack ###");
            ShelfBinPack shelfBinPack = new ShelfBinPack();
            shelfBinPack.Init(binWidth, binHeight, true);
            foreach (var rectSize in rectSizes)
            {
                Rect rect = shelfBinPack.Insert(rectSize.Width, rectSize.Height, ShelfBinPack.ShelfChoiceHeuristic.ShelfBestAreaFit);
                if (0 != rect.Height)
                    Console.WriteLine($"Rect -> X={rect.X}, Y={rect.Y}, Width={rect.Width}, Height={rect.Height}, Free space left={100.0f * (1.0f - shelfBinPack.Occupancy)}");
                else
                    Console.WriteLine($"Failed! -> Width = {rectSize.Width}, Height = {rectSize.Height}");
            }

            Console.WriteLine("### ShelfNextFitBinPack ###");
            ShelfNextFitBinPack shelfNextFitBinPack = new ShelfNextFitBinPack();
            shelfNextFitBinPack.Init(binWidth, binHeight);
            foreach (var rectSize in rectSizes)
            {
                ShelfNextFitBinPack.Node node = shelfNextFitBinPack.Insert(rectSize.Width, rectSize.Height);
                if (0 != node.Width)
                    Console.WriteLine($"Rect -> X={node.X}, Y={node.Y}, Width={node.Width}, Height={node.Height}, Free space left={100.0f * (1.0f - shelfNextFitBinPack.Occupancy)}");
                else
                    Console.WriteLine($"Failed!-> Width = {node.Width}, Height = {node.Height}");
            }    

        }
    }
}
