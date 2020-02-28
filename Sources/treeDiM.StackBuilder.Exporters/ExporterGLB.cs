#region Using directives
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Numerics;

using SharpGLTF.Scenes;
using SharpGLTF.Geometry;
using SharpGLTF.Materials;
using SharpGLTF.Geometry.VertexTypes;

using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Graphics;
#endregion

namespace treeDiM.StackBuilder.Exporters
{
    using VERTEX = VertexPosition;
    using PRIMITIVE = PrimitiveBuilder<MaterialBuilder, VertexPosition, VertexEmpty, VertexEmpty>;

    #region ExporterGLB
    public class ExporterGLB : Exporter
    {
        #region Static members
        public static string FormatName => "glb";
        #endregion

        #region Constructor
        public ExporterGLB() {}
        #endregion

        #region Override Exporter
        public override string Name => FormatName;
        public override string Extension => "glb";
        public override string Filter => "GL Transmission Format (*.glb)";
        public override void Export(AnalysisLayered analysis, ref Stream stream) { }
        public void Export(AnalysisLayered analysis, string filePath)
        {
            if (analysis.Content is BoxProperties boxProperties)
            {
                Color[] colors = Enumerable.Repeat(Color.Beige, 6).ToArray();
                Color colorFilet = Color.Beige;

                var meshPallet = BuildPalletMesh(analysis.Container as PalletProperties);
                var meshCase = BuildCaseMesh("Case", (float)boxProperties.Length, (float)boxProperties.Width, (float)boxProperties.Height,
                    /*boxProperties.Colors*/colors, 10.0f, colorFilet/*boxProperties.Colors[0]*/,
                    boxProperties.TapeWidth.Activated ? (float)boxProperties.TapeWidth.Value : 0.0f, Color.LightGray/*boxProperties.TapeColor*/);

                // scene 
                var scene = new SceneBuilder();
                // add pallet mesh
                scene.AddRigidMesh(meshPallet, Matrix4x4.Identity);
                // add cases (+ interlayers) mesh 
                SolutionLayered sol = analysis.SolutionLay;
                List<ILayer> layers = sol.Layers;
                foreach (ILayer layer in layers)
                {
                    if (layer is Layer3DBox layerBox)
                    {
                        foreach (BoxPosition bPosition in layerBox)
                        {
                            scene.AddRigidMesh(meshCase, BoxPositionToMatrix4x4(bPosition));
                        }
                    }
                }
                var model = scene.ToGltf2();
                model.Save(filePath);
            }
        }
        #endregion


        #region Helpers
        private Matrix4x4 BoxPositionToMatrix4x4(BoxPosition boxPosition)
        {
            var m = boxPosition.Transformation.Matrix;
            m.Transpose();
            return new Matrix4x4(
                (float)m.M11, (float)m.M12, (float)m.M13, (float)m.M14,
                (float)m.M21, (float)m.M22, (float)m.M23, (float)m.M24,
                (float)m.M31, (float)m.M32, (float)m.M33, (float)m.M34,
                (float)m.M41, (float)m.M42, (float)m.M43, (float)m.M44
                );
        }
        private MeshBuilder<VERTEX> BuildCaseMesh(
            string meshName,
            float length, float width, float height,
            Color[] colorFaces,
            float filet,  Color colorFilet, 
            float tapeWidth, Color colorTape
            )
        {
            var mesh = new MeshBuilder<VERTEX>(meshName);
            //
            //        7--------------- 6                 T              { 3,0,4,7 }  // Left
            //       /|               /|                 | K            { 1,2,6,5 }  // Right 
            //      / |              / |                 |/             { 0,1,5,4 }  // Front
            //     /  3-------------/- 2           L---- | ----R        { 2,3,7,6 }  // Rear
            //    4--/------------ 5  /                 /|              { 0,3,2,1 }  // Bottom
            //    | /              | /                 F |              { 4,5,6,7 }  // Top
            //    |/               |/                    B      
            //    0----------------1
            //
            VERTEX[] vertices1 = new VERTEX[]
            {
                new VERTEX(0.0f, 0.0f, 0.0f),
                new VERTEX(length, 0.0f, 0.0f),
                new VERTEX(length, width, 0.0f),
                new VERTEX(0.0f, width, 0.0f),
                new VERTEX(0.0f, 0.0f, height),
                new VERTEX(length, 0.0f, height),
                new VERTEX(length, width, height),
                new VERTEX(0.0f, width, height)
            };

            VERTEX[] vertices = new VERTEX[]
            {
                // 0
                new VERTEX(0.0f, 0.0f, 0.0f),                           // 0
                new VERTEX(0.0f + filet, 0.0f + filet, 0.0f), // B      // 1
                new VERTEX(0.0f + filet, 0.0f, 0.0f + filet), // F      // 2
                new VERTEX(0.0f, 0.0f + filet, 0.0f + filet), // L      // 3
                // 1
                new VERTEX(length, 0.0f, 0.0f),                         // 4
                new VERTEX(length - filet, 0.0f + filet, 0.0f), // B    // 5    
                new VERTEX(length - filet, 0.0f, 0.0f + filet), // F    // 6
                new VERTEX(length, 0.0f + filet, 0.0f + filet), // R    // 7
                // 2
                new VERTEX(length, width, 0.0f),                        // 8
                new VERTEX(length - filet, width - filet, 0.0f), // B   // 9
                new VERTEX(length - filet, width, 0.0f + filet), // K   // 10
                new VERTEX(length, width - filet, 0.0f + filet), // R   // 11
                // 3
                new VERTEX(0.0f, width, 0.0f),                          // 12
                new VERTEX(0.0f + filet, width - filet, 0.0f), // B     // 13
                new VERTEX(0.0f + filet, width, 0.0f + filet), // K     // 14
                new VERTEX(0.0f, width - filet, 0.0f + filet), // L     // 15
                // 4
                new VERTEX(0.0f, 0.0f, height),                         // 16
                new VERTEX(0.0f + filet, 0.0f + filet, height), // T    // 17
                new VERTEX(0.0f + filet, 0.0f, height - filet), // F    // 18    
                new VERTEX(0.0f, 0.0f + filet, height - filet), // L    // 19
                // 5
                new VERTEX(length, 0.0f, height),                       // 20
                new VERTEX(length - filet, 0.0f + filet, height), // T  // 21
                new VERTEX(length - filet, 0.0f, height - filet), // F  // 22
                new VERTEX(length, 0.0f + filet, height - filet), // R  // 23
                // 6
                new VERTEX(length, width, height),                      // 24
                new VERTEX(length - filet, width - filet, height), // T // 25
                new VERTEX(length - filet, width, height - filet), // K // 26
                new VERTEX(length, width - filet, height - filet), // R // 27    
                // 7
                new VERTEX(0.0f, width, height),                        // 28
                new VERTEX(0.0f + filet, width - filet, height), // T   // 29
                new VERTEX(0.0f + filet, width, height - filet), // K   // 30
                new VERTEX(0.0f, width - filet, height - filet),  // L   // 31
                // 8
                new VERTEX(0.0f + filet, 0.5f*(width - tapeWidth), height), // 32
                new VERTEX(length - filet, 0.5f*(width - tapeWidth), height), // 33
                new VERTEX(length - filet, 0.5f*(width + tapeWidth), height), // 34
                new VERTEX(0.0f + filet, 0.5f*(width + tapeWidth), height) //35
            };

            int[,] qFace = new int[,]
            {
                { 15,  3, 19, 31 }, // left
                {  7, 11, 27, 23 }, // right
                {  2,  6, 22, 18 }, // front
                { 10, 14, 30, 26 }, // rear
                { 1,  13,  9,  5 }, // bottom
                { 17, 21, 33, 32 },  // top1
                { 35, 34, 25, 29 },  // top2
                { 32, 33, 34, 35 }   // tape

            };

            int[,] qFaceFilet = new int[,]
            {
                {  1,  5,  6,  2 },
                {  5,  9, 11,  7 },
                {  9, 13, 14, 10 },
                { 13,  1,  3, 15 },
                { 18, 22, 21, 17 },
                { 23, 27, 25, 21 },
                { 26, 30, 29, 25 },
                { 31, 19, 17, 29 },
                {  3,  2, 18, 19 },
                {  6,  7, 23, 22 },
                { 11, 10, 26, 27 },
                { 14, 15, 31, 30 }
            };
            for (int i = 0; i < 7; ++i)
            {
                var materialColor = new MaterialBuilder()
                    .WithDoubleSide(true)
                    .WithMetallicRoughnessShader()
                    .WithChannelParam("BaseColor", ColorToVector4(colorFaces[i < 6 ? i : 5]));

                var primFace = mesh.UsePrimitive(materialColor);
                primFace.AddQuadrangle(vertices[qFace[i, 0]], vertices[qFace[i, 1]], vertices[qFace[i, 2]], vertices[qFace[i, 3]]);
            }
            if (tapeWidth > 0.0f)
            { 
                var materialTape = new MaterialBuilder()
                    .WithDoubleSide(true)
                    .WithMetallicRoughnessShader()
                    .WithChannelParam("BaseColor", ColorToVector4(colorTape));

                var primFace = mesh.UsePrimitive(materialTape);
                primFace.AddQuadrangle(vertices[qFace[7, 0]], vertices[qFace[7, 1]], vertices[qFace[7, 2]], vertices[qFace[7, 3]]);

                var materialBlack = new MaterialBuilder()
                    .WithUnlitShader()
                    .WithChannelParam("BaseColor", ColorToVector4(Color.Black));

                var primTapeBorder = mesh.UsePrimitive(materialBlack, 2);
                primTapeBorder.AddLine(vertices[qFace[7, 0]], vertices[qFace[7, 1]]);
                primTapeBorder.AddLine(vertices[qFace[7, 1]], vertices[qFace[7, 2]]);
                primTapeBorder.AddLine(vertices[qFace[7, 2]], vertices[qFace[7, 3]]);
                primTapeBorder.AddLine(vertices[qFace[7, 3]], vertices[qFace[7, 0]]);
            }

            var materialFilet = new MaterialBuilder()
                .WithDoubleSide(true)
                .WithMetallicRoughnessShader()
                .WithChannelParam("BaseColor", ColorToVector4(colorFilet));

            var prim = mesh.UsePrimitive(materialFilet);
            for (int i = 0; i < 12; ++i)
                prim.AddQuadrangle(
                    vertices[qFaceFilet[i, 0]],
                    vertices[qFaceFilet[i, 1]],
                    vertices[qFaceFilet[i, 2]],
                    vertices[qFaceFilet[i, 3]]
                    );
            return mesh;
        }
        private MeshBuilder<VERTEX> BuildPalletMesh(PalletProperties palletProperties)
        {
            var mesh = new MeshBuilder<VERTEX>("mesh1");
            Pallet pallet = new Pallet(palletProperties);

            var material = new MaterialBuilder()
                .WithDoubleSide(true)
                .WithChannelParam("BaseColor", ColorToVector4(palletProperties.Color));

            var prim = mesh.UsePrimitive(material);
            foreach (var b in pallet.BuildListOfBoxes())
            {
                AddBox(prim, (float)b.Length, (float)b.Width, (float)b.Height, 2.0f, b.BPosition);
            }
            return mesh;
        }
        private void AddBox(PRIMITIVE primitive, float length, float width, float height, float filet, BoxPosition boxPosition)
        {
            VERTEX[] vertices = new VERTEX[]
            {
                // 0
                new VERTEX(0.0f, 0.0f, 0.0f),                           // 0
                new VERTEX(0.0f + filet, 0.0f + filet, 0.0f), // B      // 1
                new VERTEX(0.0f + filet, 0.0f, 0.0f + filet), // F      // 2
                new VERTEX(0.0f, 0.0f + filet, 0.0f + filet), // L      // 3
                // 1
                new VERTEX(length, 0.0f, 0.0f),                         // 4
                new VERTEX(length - filet, 0.0f + filet, 0.0f), // B    // 5    
                new VERTEX(length - filet, 0.0f, 0.0f + filet), // F    // 6
                new VERTEX(length, 0.0f + filet, 0.0f + filet), // R    // 7
                // 2
                new VERTEX(length, width, 0.0f),                        // 8
                new VERTEX(length - filet, width - filet, 0.0f), // B   // 9
                new VERTEX(length - filet, width, 0.0f + filet), // K   // 10
                new VERTEX(length, width - filet, 0.0f + filet), // R   // 11
                // 3
                new VERTEX(0.0f, width, 0.0f),                          // 12
                new VERTEX(0.0f + filet, width - filet, 0.0f), // B     // 13
                new VERTEX(0.0f + filet, width, 0.0f + filet), // K     // 14
                new VERTEX(0.0f, width - filet, 0.0f + filet), // L     // 15
                // 4
                new VERTEX(0.0f, 0.0f, height),                         // 16
                new VERTEX(0.0f + filet, 0.0f + filet, height), // T    // 17
                new VERTEX(0.0f + filet, 0.0f, height - filet), // F    // 18    
                new VERTEX(0.0f, 0.0f + filet, height - filet), // L    // 19
                // 5
                new VERTEX(length, 0.0f, height),                       // 20
                new VERTEX(length - filet, 0.0f + filet, height), // T  // 21
                new VERTEX(length - filet, 0.0f, height - filet), // F  // 22
                new VERTEX(length, 0.0f + filet, height - filet), // R  // 23
                // 6
                new VERTEX(length, width, height),                      // 24
                new VERTEX(length - filet, width - filet, height), // T // 25
                new VERTEX(length - filet, width, height - filet), // K // 26
                new VERTEX(length, width - filet, height - filet), // R // 27    
                // 7
                new VERTEX(0.0f, width, height),                        // 28
                new VERTEX(0.0f + filet, width - filet, height), // T   // 29
                new VERTEX(0.0f + filet, width, height - filet), // K   // 30
                new VERTEX(0.0f, width - filet, height - filet)  // L   // 31
            };

            VERTEX[] tVertices = new VERTEX[32];
            int index = 0;
            foreach (var v in vertices)
            {
                v.ApplyTransform(BoxPositionToMatrix4x4(boxPosition));
                tVertices[index++] = v;
            }

            int[,] qFace = new int[,]
            {
                { 15,  3, 19, 31 }, // left
                {  7, 11, 27, 23 }, // right
                {  2,  6, 22, 18 }, // front
                { 10, 14, 30, 26 }, // rear
                { 1,  13,  9,  5 }, // bottom
                { 17, 21, 25, 29 }  // top
            };
            int[,] qFaceFilet = new int[,]
            {
                {  1,  5,  6,  2 },
                {  5,  9, 11,  7 },
                {  9, 13, 14, 10 },
                { 13,  1,  3, 15 },
                { 18, 22, 21, 17 },
                { 23, 27, 25, 21 },
                { 26, 30, 29, 25 },
                { 31, 19, 17, 29 },
                {  3,  2, 18, 19 },
                {  6,  7, 23, 22 },
                { 11, 10, 26, 27 },
                { 14, 15, 31, 30 }
            };
            for (int i = 0; i < 6; ++i)
            {
                primitive.AddQuadrangle(tVertices[qFace[i, 0]], tVertices[qFace[i, 1]], tVertices[qFace[i, 2]], tVertices[qFace[i, 3]]);
            }

            for (int i = 0; i < 12; ++i)
                primitive.AddQuadrangle(
                    tVertices[qFaceFilet[i, 0]],
                    tVertices[qFaceFilet[i, 1]],
                    tVertices[qFaceFilet[i, 2]],
                    tVertices[qFaceFilet[i, 3]]
                    );
        }
        static Vector4 ColorToVector4(Color color) => new Vector4((float)color.R / 255.0F, (float)color.G / 255.0F, (float)color.B / 255.0F, 1.0F);
        #endregion
    }
    #endregion
}
