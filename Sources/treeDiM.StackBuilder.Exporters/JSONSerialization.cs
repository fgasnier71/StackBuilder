using System;
using System.Collections.Generic;

namespace treeDiM.StackBuilder.Exporters.Json
{
    public class Child
    {
        public string Name { get; set; }
        public string Uuid { get; set; }
        public string Material { get; set; }
        public string Geometry { get; set; }
        public List<double> Matrix { get; set; }
        public bool Visible { get; set; }
        public string Type { get; set; }
        public int? Color { get; set; }
        public int? Intensity { get; set; }
        public int? Fov { get; set; }
        public double? Aspect { get; set; }
        public int? Near { get; set; }
        public int? Far { get; set; }

        public List<Child> Children { get; set; }
    }

    public class Object
    {
        public string Type { get; set; }
        public string Uuid { get; set; }
        public List<int> Matrix { get; set; }
        public List<Child> Children { get; set; }
    }

    public class Key
    {
        public int Time { get; set; }
        public List<double> Value { get; set; }
    }

    public class Track
    {
        public string Type { get; set; }
        public List<Key> Keys { get; set; }
        public string Name { get; set; }
    }

    public class Animation
    {
        public int Fps { get; set; }
        public string Name { get; set; }
        public List<Track> Tracks { get; set; }
    }

    public class Material
    {
        public bool VertexColors { get; set; }
        public int Specular { get; set; }
        public string Name { get; set; }
        public int Color { get; set; }
        public bool DepthTest { get; set; }
        public bool DepthWrite { get; set; }
        public int Emissive { get; set; }
        public int Ambient { get; set; }
        public int Shininess { get; set; }
        public string Type { get; set; }
        public string Uuid { get; set; }
        public string Blending { get; set; }
    }

    public class Metadata
    {
        public double Version { get; set; }
        public string Type { get; set; }
        public string Generator { get; set; }
        public string SourceFile { get; set; }
    }

    public class Data
    {
        public string Name { get; set; }
        public Metadata Metadata { get; set; }
        public List<double> Vertices { get; set; }
        public List<double> Normals { get; set; }
        public List<List<double>> Uvs { get; set; }
        public List<int> Faces { get; set; }
    }

    public class Geometry
    {
        public string Type { get; set; }
        public string Uuid { get; set; }
        public Data Data { get; set; }
    }

    public class RootObject
    {
        public Object Object { get; set; }
        public Metadata Metadata { get; set; }
        public List<Geometry> Geometries { get; set; }
        public List<Material> Materials { get; set; }
        public List<object> Textures { get; set; }
        public List<object> Images { get; set; }
        public List<Animation> Animations { get; set; }
    }
}