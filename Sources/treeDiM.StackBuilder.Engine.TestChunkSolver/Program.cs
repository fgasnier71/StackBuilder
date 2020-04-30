#region Using directives
using System;
using System.Collections.Generic;

using Sharp3D.Math.Core;
#endregion

namespace treeDiM.StackBuilder.Engine.TestChunkSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector2D dimContent = new Vector2D(1200, 1000);
            Vector2D dimContainer = new Vector2D(13600, 2450);

            List<Chunk> chunks = ChunkSolver.BuildChunks(dimContent, dimContainer, 0, 11);

            foreach (var chunk in chunks)
                Console.WriteLine(chunk.ToString());
        }
    }
}
