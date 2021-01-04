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

            // 128 128 30 20 50 20 10 80 90 20 90 20
            RectSize[] rectSizes = {
                new RectSize(30, 20),
                new RectSize(50, 20),
                new RectSize(10, 80),
                new RectSize(90, 20),
                new RectSize(90, 20)
            };

            Console.WriteLine("### MaxRectsBinPack ###");
            MaxRectsBinPack maxRectsBinPack = new MaxRectsBinPack();
            maxRectsBinPack.Init(binWidth, binHeight);
            foreach (var rectSize in rectSizes)
            {
                Rect rect = maxRectsBinPack.Insert(rectSize, new MaxRectsBinPack.Option() { Method = MaxRectsBinPack.FreeRectChoiceHeuristic.RectBestAreaFit });
                if (0 != rect.Height)
                    Console.WriteLine($"Rect -> {rect}, Free space left={maxRectsBinPack.FreeSpaceLeft}");
                else
                    Console.WriteLine($"Failed!-> {rectSize}");
            }

            Console.WriteLine("### GuillotineBinPack ###");
            GuillotineBinPack binGuillotine = new GuillotineBinPack();
            binGuillotine.Init(binWidth, binHeight);
            foreach (var rectSize in rectSizes)
            {
                Rect rect = binGuillotine.Insert(rectSize, new GuillotineBinPack.Option()
                {
                    Merge = true,
                    FreeRectChoice = GuillotineBinPack.FreeRectChoiceHeuristic.RectBestAreaFit,
                    GuillotineSplit = GuillotineBinPack.GuillotineSplitHeuristic.SplitLongerAxis
                });
                if (0 != rect.Height)
                    Console.WriteLine($"Rect -> {rect}, Free space left={binGuillotine.FreeSpaceLeft}");
                else
                    Console.WriteLine($"Failed!-> {rectSize}");
            }

            Console.WriteLine("### ShelfBinPack ###");
            ShelfBinPack shelfBinPack = new ShelfBinPack
            {
                UseWasteMap = true
            };
            shelfBinPack.Init(binWidth, binHeight);
            foreach (var rectSize in rectSizes)
            {
                Rect rect = shelfBinPack.Insert(rectSize, new ShelfBinPack.Option() { Method = ShelfBinPack.ShelfChoiceHeuristic.ShelfBestAreaFit } );
                if (0 != rect.Height)
                    Console.WriteLine($"Rect -> {rect}, Free space left= {shelfBinPack.FreeSpaceLeft}");
                else
                    Console.WriteLine($"Failed!-> {rectSize}");
            }

            Console.WriteLine("### ShelfNextFitBinPack ###");
            ShelfNextFitBinPack shelfNextFitBinPack = new ShelfNextFitBinPack();
            shelfNextFitBinPack.Init(binWidth, binHeight);
            foreach (var rectSize in rectSizes)
            {
                Rect rect = shelfNextFitBinPack.Insert(rectSize, new OptionNone());
                if (0 != rect.Width)
                    Console.WriteLine($"Rect -> {rect}, Free space left={shelfNextFitBinPack.FreeSpaceLeft}");
                else
                    Console.WriteLine($"Failed!-> {rectSize}");
            }
            Console.WriteLine("### SkylineBinPack ###");
            SkylineBinPack skylineBinPack = new SkylineBinPack();
            skylineBinPack.Init(binWidth, binHeight);
            foreach (var rectSize in rectSizes)
            {
                Rect rect = skylineBinPack.Insert(rectSize, new SkylineBinPack.Option() { Method = SkylineBinPack.LevelChoiceHeuristic.LevelBottomLeft });

                if (0 != rect.Height)
                    Console.WriteLine($"Rect -> {rect}, Free space left= {skylineBinPack.FreeSpaceLeft}");
                else
                    Console.WriteLine($"Failed! -> {rectSize}");
            }
        }
    }
}
