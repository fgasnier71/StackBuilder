using System;
using System.Text;

using Sharp3D.Math.Core;

namespace treeDiM.StackBuilder.Basics
{
    public abstract class Packable : ItemBase
    {
        public Packable(Document doc)
            : base(doc)
        {
        }

        /// <summary>
        /// Is actually formatted as "TypeName(Name)"
        /// </summary>
        public virtual string DetailedName => $"{TypeName}({ID.Name})";
        public abstract double Weight { get; }
        public abstract OptDouble NetWeight { get; }
        public abstract double Volume { get; }
        public abstract Vector3D OuterDimensions { get; }
        public virtual bool IsCase => false;
        public virtual bool IsPallet => false;
        public virtual bool IsTruck => false;
        public abstract bool IsBrick { get; }
        public bool IsCylinder => !IsBrick;

        public virtual bool InnerAnalysis(ref Analysis analysis)
        {
            analysis = null;
            return false;
        }

        public virtual bool InnerContent(ref Packable innerPackable, ref int number)
        {
            innerPackable = null;
            number = 0;
            return false;
        }

        public override string ToString()
        {
            var sBuilder = new StringBuilder();
            sBuilder.Append(base.ToString());
            sBuilder.Append($"Packable => Weight = {Weight}  NetWeight = {NetWeight}\n");
            return sBuilder.ToString();
        }

        #region Non-Public Members

        protected abstract string TypeName { get; }

        #endregion
    }
}